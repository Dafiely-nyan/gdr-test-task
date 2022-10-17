using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private int _coinsAmount;
    [SerializeField]
    private int _obstaclesAmount;

    [SerializeField]
    private GameObject _obstacleGameObject;
    [SerializeField]
    private GameObject _coinGameObject;

    [SerializeField]
    private float _skipRadius = 0.5f;

    private List<GameObject> _obstacles = new List<GameObject>();
    private List<GameObject> _coins = new List<GameObject>();
    public int CoinsLeft { get => _coins.Count; }

    // чуть в более серьезной ситуации использовался бы пул, также 
    // создание / удаление не происходит с большой частотой то большого влияния
    // на производительность оказывать не должно
    public void GenerateLevel()
    {
        var maxX = SceneContext.Instance.VisibleArea.x;
        var maxY = SceneContext.Instance.VisibleArea.y;
        
        _coins = new List<GameObject>();
        _obstacles = new List<GameObject>();

        for (int i = 0; i < _coinsAmount; i++)
        {
            var signX = Mathf.Sign(Random.Range(-1f, 1f));
            var signY = Mathf.Sign(Random.Range(-1f, 1f));
            
            Vector2 spawnPos = new Vector2(signX * Random.Range(_skipRadius, maxX), signY * Random.Range(_skipRadius, maxY));
            var g = Instantiate(_coinGameObject, spawnPos, Quaternion.identity);
            
            g.SetActive(true);
            _coins.Add(g);
        }

        for (int i = 0; i < _obstaclesAmount; i++)
        {
            var signX = Mathf.Sign(Random.Range(-1f, 1f));
            var signY = Mathf.Sign(Random.Range(-1f, 1f));
            
            Vector2 spawnPos = new Vector2(signX * Random.Range(_skipRadius, maxX), signY * Random.Range(_skipRadius, maxY));
            var g = Instantiate(_obstacleGameObject, spawnPos, Quaternion.identity);
            
            g.SetActive(true);
            _obstacles.Add(g);
        }
    }

    public void ClearLevel()
    {
        foreach (var coin in _coins)
        {
            Destroy(coin);
        }

        foreach (var obstacle in _obstacles)
        {
            Destroy(obstacle);
        }
    }

    public void RemoveCoin(GameObject coin)
    {
        _coins.Remove(coin);
        Destroy(coin);
    }
}