using UnityEngine;

public class MapHintTrigger : MonoBehaviour
{
    [SerializeField] private CatGuide catGuide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameConstants.PlayerTag))
        {
            catGuide.ShowMessage("You can always look at the map to see how far the Harbour is! Use M to open it.");
        }
    }
}
