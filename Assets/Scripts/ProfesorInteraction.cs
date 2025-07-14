using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class ProfessorInteraction : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private TMP_Text speechText;
    [SerializeField] private GameObject essayObject;
    [SerializeField] private GameObject balloonObject;

    [Header("Vars")]
    [SerializeField] private float messageDuration = 5f;
    [SerializeField] private float gravityScale = -0.1f;
    [SerializeField] private float velocity = 1f;


    private bool isPlayerInRange = false;
    private bool hasInteracted = false;
    private Coroutine currentMessage;

    private void Start()
    {
        essayObject.SetActive(false);
        balloonObject.SetActive(false);
        speechBubble.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.Return))
        {
            GameObject player = GameObject.FindWithTag("Player");
            hasInteracted = true;
            StartCoroutine(HandleInteraction(player));
        }
    }

    private IEnumerator HandleInteraction(GameObject player)
    {
        essayObject.SetActive(true);

        ShowMessage("Excellent! A perfect score! Now you may go home! I'll give you some transport!");

        // Wait so the essay stays visible a bit
        yield return new WaitForSeconds(3f);

        essayObject.SetActive(false);

        // Show balloons and fly away
        balloonObject.SetActive(true);

        // Player disable movement
        player.GetComponent<PlayerMovement>().enabled = false;

        // Float up with balloons
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = gravityScale; // float up
            rb.linearVelocity = new Vector2(0, velocity); // upward motion
        }

        // Load next scene
        //SceneManager.LoadScene(nextSceneName);
    }

    private void ShowMessage(string message)
    {
        if (currentMessage != null)
        {
            StopCoroutine(currentMessage);
        }

        //SoundManager.instance.PlaySound(); // TODO
        currentMessage = StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        speechBubble.SetActive(true);
        speechText.text = message;

        yield return new WaitForSeconds(messageDuration);

        speechBubble.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            ShowMessage("Hello! You brought your essay? Let me see!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
