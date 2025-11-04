using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverPanel;

    private bool _isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Ensure the game runs at normal speed when starting
        Time.timeScale = 1f;
        _gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        // Show the Game Over UI
        _gameOverPanel.SetActive(true);

        _isGameOver = true;

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
