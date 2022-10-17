using System;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class SceneContext : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCam;
    [SerializeField]
    private UiController _uiController;
    [SerializeField]
    private GameplayFlow _gameplayFlow;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private LevelGenerator _levelGenerator;
    [SerializeField]
    private PathVisualizer _pathVisualizer;

    public Camera MainCamera { get; private set; }
    public PathVisualizer PathVisualizer { get; private set; }
    public UiController UiController { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public LevelGenerator LevelGenerator { get; private set; }
    public GameplayFlow GameplayFlow { get; private set; }
    
    public Vector3 CursorWorldPosition { get; private set; }
    public Vector2 VisibleArea { get; private set; }

    private float _cameraDistance;

    private void Update()
    {
        CursorWorldPosition =
            MainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraDistance));
        
        SetVisibleArea();
    }
    
    void SetVisibleArea()
    {
        float screenAspectRation = (float)_mainCam.pixelWidth / _mainCam.pixelHeight;
        float orthographicSize = _mainCam.orthographicSize;
            
        VisibleArea = new Vector2(orthographicSize * screenAspectRation, orthographicSize);
    }
    
    public static SceneContext Instance;

    private void Awake()
    {
        Instance = this;

        MainCamera = _mainCam;
        UiController = _uiController;
        GameplayFlow = _gameplayFlow;
        PathVisualizer = _pathVisualizer;
        PlayerController = _playerController;
        LevelGenerator = _levelGenerator;

        _cameraDistance = Mathf.Abs(_mainCam.transform.position.z);
        
        SetVisibleArea();
    }
}