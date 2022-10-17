using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private UiController _uiController;
    private GameplayFlow _gameplayFlow;
    private LevelGenerator _levelGenerator;

    private void Start()
    {
        _uiController = SceneContext.Instance.UiController;
        _gameplayFlow = SceneContext.Instance.GameplayFlow;
        _levelGenerator = SceneContext.Instance.LevelGenerator;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            _levelGenerator.RemoveCoin(other.gameObject);
            _gameplayFlow.Score++;
            _uiController.SetScore();
            
            if (_levelGenerator.CoinsLeft == 0)
                _uiController.SetGameOver(false);
        }
        else
        {
            _uiController.SetGameOver(true);
        }
    }
}