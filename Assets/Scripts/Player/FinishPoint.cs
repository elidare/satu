using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelname;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (goNextLevel)
            {
                // Go to next scene
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelname);
            }
        }
    }
}
