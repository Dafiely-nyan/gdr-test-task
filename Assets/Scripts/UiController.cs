using System;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    
    [SerializeField]
    private TextMeshProUGUI GameOverStatusText;
    [SerializeField]
    private Canvas GameOverCanvas;

    private GameplayFlow _gameplayFlow;

    private void Awake()
    {
        _gameplayFlow = SceneContext.Instance.GameplayFlow;
    }

    public void SetScore()
    {
        ScoreText.text = $"{_gameplayFlow.Score}";
    }

    public void SetGameOver(bool failed)
    {
        if (failed)
        {
            GameOverStatusText.text = "Failed!";
        }
        else GameOverStatusText.text = "Victory!";
        
        GameOverCanvas.gameObject.SetActive(true);

        _gameplayFlow.SetTimescale(0);
    }

    public void HideGameoverCanvas()
    {
        GameOverCanvas.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        _gameplayFlow.StartGame();
    }
}
