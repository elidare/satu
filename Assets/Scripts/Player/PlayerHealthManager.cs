using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float startingHealth;
    public float currentHealth { get; private set; }
    public static PlayerHealthManager instance;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private Animator anim;

    [Header("Components")]
    private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            currentHealth = startingHealth;
        }
        else
        {
            Destroy(gameObject);
        }

        ReconnectToPlayer(); // Initial scene connection
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == GameConstants.LevelCity) // Dirty hack to make full lives on Restart
        {
            dead = false;
            currentHealth = startingHealth;
        }
        ReconnectToPlayer();
    }

    private void ReconnectToPlayer()
    {
        GameObject player = GameObject.FindWithTag(GameConstants.PlayerTag);
        if (player != null)
        {
            components = new Behaviour[]
            {
                player.GetComponent<PlayerMovement>(),
                player.GetComponent<PlayerAttack>()
            };

            anim = player.GetComponent<Animator>();
            spriteRend = player.GetComponent<SpriteRenderer>();
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invulnerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                // Deactivate all attached components (Player, Enemy, EnemyPatrol)
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                if (CompareTag(GameConstants.PlayerTag))
                {
                    anim.SetBool("grounded", true); // only on Player
                }
                anim.SetTrigger("die");
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle_weapon");
        StartCoroutine(Invulnerability());
        // Activate all attached components (Player)
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
