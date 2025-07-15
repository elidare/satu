using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float damage;

    private Animator anim;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            PlayerHealthManager.instance.TakeDamage(damage);
        }
    }
}
