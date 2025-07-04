using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!pauseScreen.activeInHierarchy); // Pause if not paused and vice versa
        }
    }

    #region Game Over
    // Activate Game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    // Game over functions
    public void Restart() // TODO: This should either respawn or be deleted
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the current scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // Menu
    }

    public void Quit()
    {
        Application.Quit(); // Quits the game

        // Exits play mode in the Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        Time.timeScale = status ? 0 : 1; // If Paused, stop the game
    }
    #endregion
}
