using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint; // Storing last checkpoint
    //private PlayerHealth playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
        //playerHealth = GetComponent<PlayerHealth>();
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void RespawnPlayer()
    {
        // Check if checkpoint available, otherwise Game Over
        if (currentCheckpoint == null)
        {
            // Show Game over
            uiManager.GameOver();

            return;
        }

        // Restore player health and reset animation
        PlayerHealthManager.instance.Respawn();
        transform.position = currentCheckpoint.position; // Move player to the respawn position
    }

    // Activate checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.CheckpointTag))
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; // Deactivate checkpoint collider
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
