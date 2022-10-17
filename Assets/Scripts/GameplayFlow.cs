using UnityEngine;

public class GameplayFlow : MonoBehaviour
{
    private PathVisualizer _pathVisualizer;
    private PlayerController _playerController;
    private UiController _uiController;
    private LevelGenerator _levelGenerator;

    public int Score { get; set; }

    private void Start()
    {
        _pathVisualizer = SceneContext.Instance.PathVisualizer;
        _playerController = SceneContext.Instance.PlayerController;
        _uiController = SceneContext.Instance.UiController;
        _levelGenerator = SceneContext.Instance.LevelGenerator;
        
        StartGame();
    }

    public void StartGame()
    {
        SetTimescale(1);
        
        Score = 0;
        
        _playerController.ResetPosition();
        _pathVisualizer.ClearPath();
        _levelGenerator.ClearLevel();
        _levelGenerator.GenerateLevel();
        _uiController.HideGameoverCanvas();
        _uiController.SetScore();
    }

    public void SetTimescale(float ts)
    {
        Time.timeScale = ts;
    }
}
