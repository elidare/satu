using UnityEngine;

public class FireHintTrigger : MonoBehaviour
{
    [SerializeField] private CatGuide catGuide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            catGuide.ShowMessage("Avoid traps and delete enemies! To fire, press Left Control! Good luck!");
        }
    }
}
