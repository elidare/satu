using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); // Load First scene
    }
    public void Quit()
    {
        Application.Quit(); // Quits the game

        // Exits play mode in the Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
