using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private float endYPosition = 1000f; // The Y position to trigger menu load

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Move credits upwards
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed + Time.deltaTime);

        // Check if credits have passed the end position
        // Triggers on Credits game object
        if (endYPosition != 0 && rectTransform.anchoredPosition.y >= endYPosition)
        {
            SceneManager.LoadScene("0_menu");
        }
    }
}
