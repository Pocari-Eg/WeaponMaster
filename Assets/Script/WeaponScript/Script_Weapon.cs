using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon : MonoBehaviour
{


    [SerializeField]
    Script_WeaponData.WeaponData Weapon;

    [SerializeField]
    string GFX_DATANUM;

    public string GetPlayerGFX()
    {

        return GFX_DATANUM;
    }

    public Script_WeaponData.WeaponData GetWeaponData() { return Weapon; }
    public void SetWeaponData(Script_WeaponData.WeaponData m) { Weapon = m; }
}
