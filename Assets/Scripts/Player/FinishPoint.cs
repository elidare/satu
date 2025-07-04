using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelname;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player can not leave Scene 1 without weapon and essay
            WeaponManager player = collision.GetComponent<WeaponManager>();
            if (player != null && !player.HasEssay() || !player.HasWeapon())
            {
                return;
            }

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
