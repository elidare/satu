using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isPlayerInRange = false;

    private void Update()
    {
        // Only allow picking up when the Player is nere
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void PickUp()
    {
        // Deactivate the weapon in the closet
        gameObject.SetActive(false);
        // Call EquipPlayer
        // Find the player GameObject (must be tagged "Player")
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            WeaponManager weaponManager = player.GetComponent<WeaponManager>();

            if (weaponManager != null)
            {
                weaponManager.EquipWeapon();
            }
        }
    }
}
