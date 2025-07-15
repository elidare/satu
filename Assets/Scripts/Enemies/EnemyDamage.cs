using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
