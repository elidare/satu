using UnityEngine;
using System.Collections;
using TMPro; // if you're using TextMeshPro

public class CatGuide : MonoBehaviour
{
    [SerializeField] private GameObject speechBubble; // UI panel or speech bubble
    [SerializeField] private TMP_Text messageText; // The text inside it

    [SerializeField] private float messageDuration = 5f;
    [SerializeField] private AudioClip meowSound;

    private Coroutine currentMessage;

    private void Start()
    {
        speechBubble.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (currentMessage != null)
        {
            StopCoroutine(currentMessage);
        }

        SoundManager.instance.PlaySound(meowSound);
        currentMessage = StartCoroutine(ShowMessageCoroutine(message));
    }

    private IEnumerator ShowMessageCoroutine(string message)
    {
        speechBubble.SetActive(true);
        messageText.text = message;

        yield return new WaitForSeconds(messageDuration);

        speechBubble.SetActive(false);
    }
}