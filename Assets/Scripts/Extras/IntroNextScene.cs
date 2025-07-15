using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNextScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("1_room", LoadSceneMode.Single);
    }
}
