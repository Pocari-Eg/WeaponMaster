using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Script_WeaponData : MonoBehaviour
{
  
    [Serializable]
    public struct WeaponData
    {
        [SerializeField]
        int WeaponIndex;  //무기 번호
        [SerializeField]
        string WeaponName;
        [SerializeField]
        int UseCount;//무기의 사용 횟수
 
        [SerializeField]
        float Weapon_Power;
        [SerializeField]
        string[] AttackType;

        //무기 구조체의 get set함수들
        public int GetWeaponIndex() { return WeaponIndex; }
        public void SetWeaponIndex(int m) { WeaponIndex = m; }

        public int GetUseCount() { return UseCount; }
        public void SetUseCount(int m) { UseCount = m; }

        public string GetAttackType(int a) { return AttackType[a]; }
        public float GetWeaponPower() { return Weapon_Power; }
    }


}
