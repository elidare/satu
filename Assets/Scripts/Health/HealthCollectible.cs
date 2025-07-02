using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    [SerializeField] private AudioClip collectibleSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(collectibleSound);
            PlayerHealthManager.instance.AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
