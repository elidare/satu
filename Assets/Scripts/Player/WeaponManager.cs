using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController unarmedOverride;
    [SerializeField] private RuntimeAnimatorController baseController;
    private Animator anim;
    private bool hasWeapon = false;
    private bool hasEssay = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = unarmedOverride;
    }

    public void EquipWeapon()
    {
        hasWeapon = true;
        anim.runtimeAnimatorController = baseController;
    }

    // Also placing picking up Essay here because I do not want to create another script. 
    // Not nice but quick solution
    public void PickEssay()
    {
        hasEssay = true;
    }

    public bool HasEssay()
    {
        return hasEssay;
    }

    public bool HasWeapon()
    {
        return hasWeapon;
    }
}
