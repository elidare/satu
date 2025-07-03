using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController unarmedOverride;
    [SerializeField] private RuntimeAnimatorController baseController;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = unarmedOverride;
    }

    public void EquipWeapon()
    {
        anim.runtimeAnimatorController = baseController;
    }
}
