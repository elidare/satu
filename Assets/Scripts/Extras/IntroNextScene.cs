using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNextScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene(GameConstants.LevelRoom, LoadSceneMode.Single);
    }
}
