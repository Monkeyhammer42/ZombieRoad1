using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weapons_Unlocked;

    public WeaponController[] total_Weapons;
    [HideInInspector]
    public WeaponController current_Weapon;
    private int current_Weapon_Index;


    private TypeControlAttack current_Type_Control;
    private PlayerArmController[] armController;
    private PlayerAnimations playerAnim;
    private bool isShooting;

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        LoadActiveWeapons();
        current_Weapon_Index = 1;

    }
    void Start()
    {
        armController = GetComponentsInChildren<PlayerArmController>();
        playerAnim.SwitchWeaponAnimation((int)weapons_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);

    }

    void LoadActiveWeapons()
    {
        weapons_Unlocked.Add(total_Weapons[0]);
        for(int i = 1; i < total_Weapons.Length; i++)
        {
            weapons_Unlocked.Add(total_Weapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        current_Weapon_Index++;
        current_Weapon_Index = (current_Weapon_Index >= weapons_Unlocked.Count) ? 0 : current_Weapon_Index;

        playerAnim.SwitchWeaponAnimation((int)weapons_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
    }





}
