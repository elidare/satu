using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //[SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = PlayerHealthManager.instance.startingHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = PlayerHealthManager.instance.currentHealth / 10;
    }
}
