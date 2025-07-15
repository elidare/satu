using UnityEngine;

public class ClosetHintTrigger : MonoBehaviour
{
    [SerializeField] private CatGuide catGuide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            catGuide.ShowMessage("Come up to the closet and open it using Enter. After this you will need to pick up the weapon!");
        }
    }
}
