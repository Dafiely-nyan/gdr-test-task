using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    
    private Rigidbody2D _rigidbody2D;
    
    private PathVisualizer _pathVisualizer;

    List<Vector2> _movePoints = new List<Vector2>();

    private Vector2 _startMovingPoint;
    private float _lerpAmount;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _pathVisualizer = SceneContext.Instance.PathVisualizer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _movePoints.Add(SceneContext.Instance.CursorWorldPosition);

            _pathVisualizer.AddPosition(SceneContext.Instance.CursorWorldPosition);
        }

        if (_movePoints.Count > 0)
        {
            _lerpAmount += Time.deltaTime * _speed / (Vector2.Distance(_startMovingPoint, _movePoints[0]));
        }

        if (_movePoints.Count > 0 &&
            _lerpAmount >= 1)
        {
            _startMovingPoint = _movePoints[0];
            _lerpAmount = 0;
            _movePoints.RemoveAt(0);
            
            _pathVisualizer.RemoveFirstPosition();
        }
    }

    private void FixedUpdate()
    {
        if (_movePoints.Count == 0) return;

        var nPos = Vector2.Lerp(_startMovingPoint, _movePoints[0], _lerpAmount);

        _rigidbody2D.MovePosition(nPos);
    }

    public void ResetPosition()
    {
        _movePoints = new List<Vector2>();
        
        transform.position = Vector2.zero;
        
        _startMovingPoint = Vector2.zero;
        _lerpAmount = 0;
    }

}
