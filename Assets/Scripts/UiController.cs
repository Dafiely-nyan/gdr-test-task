using System;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    
    [SerializeField]
    private TextMeshProUGUI _gameOverStatusText;
    [SerializeField]
    private Canvas _gameOverCanvas;

    private GameplayFlow _gameplayFlow;

    private void Awake()
    {
        _gameplayFlow = SceneContext.Instance.GameplayFlow;
    }

    public void SetScore()
    {
        _scoreText.text = $"{_gameplayFlow.Score}";
    }

    public void SetGameOver(bool failed)
    {
        if (failed)
        {
            _gameOverStatusText.text = "Failed!";
        }
        else _gameOverStatusText.text = "Victory!";
        
        _gameOverCanvas.gameObject.SetActive(true);

        _gameplayFlow.SetTimescale(0);
    }

    public void HideGameoverCanvas()
    {
        _gameOverCanvas.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        _gameplayFlow.StartGame();
    }
}
