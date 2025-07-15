using UnityEngine;

public class Trap_Steady : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            PlayerHealthManager.instance.TakeDamage(damage);
        }
    }
}
