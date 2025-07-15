using UnityEngine;

public class ClosetOpener : MonoBehaviour
{
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private GameObject weapon;
    private bool isPlayerInRange = false;
    private bool isOpened = false;
    private SpriteRenderer spriteRend;


    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        if (spriteRend.sprite != closedSprite)
        {
            spriteRend.sprite = closedSprite;
        }
        weapon.SetActive(false);
    }

    private void Update()
    {
        // Only allow opening if player is nearby AND closet hasn't been opened
        if (isPlayerInRange && !isOpened && Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            OpenCloset();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            isPlayerInRange = false;
        }
    }

    private void OpenCloset()
    {
        isOpened = true;
        spriteRend.sprite = openedSprite;

        // Show weapon
        if (weapon != null)
        {
            weapon.SetActive(true);
        }

        // Make closet not active for opening anymore
        GetComponent<Collider2D>().enabled = false;
    }
}
