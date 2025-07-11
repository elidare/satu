using UnityEngine;

public class FireHintTrigger : MonoBehaviour
{
    [SerializeField] private CatGuide catGuide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            catGuide.ShowMessage("Use Space to jump over the traps! To fire, press Left Control! Good luck!");
        }
    }
}
