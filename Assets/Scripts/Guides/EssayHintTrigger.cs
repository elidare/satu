using UnityEngine;

public class EssayHintTrigger : MonoBehaviour
{
    [SerializeField] private CatGuide catGuide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            catGuide.ShowMessage("Did you take your essay? It is on the table.");
        }
    }
}
