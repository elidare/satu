using UnityEngine;
using UnityEngine.SceneManagement;

public class SkippableScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if (string.IsNullOrWhiteSpace(sceneName))
        {
            Debug.LogWarning("SkippableScene: No scene name set!");
            return;
        }

        // Skip Intro and Credits by Enter or Escape
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
