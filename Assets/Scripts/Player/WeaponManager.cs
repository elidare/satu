using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Animator anim;
    public AnimatorOverrideController unarmedOverride;
    public RuntimeAnimatorController baseController;

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
