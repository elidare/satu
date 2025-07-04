using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelname;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "1_room")
            {
                // Player can not leave Scene 1 without weapon and essay
                WeaponManager weaponManager = collision.GetComponent<WeaponManager>();
                if (weaponManager == null || !weaponManager.HasEssay() || !weaponManager.HasWeapon())
                {
                    return;
                }
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
