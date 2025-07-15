using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Used for enemies
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt"); // For enemies
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                // Deactivate all attached components (Enemy, EnemyPatrol)
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                anim.SetTrigger("die");
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
