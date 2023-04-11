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
        int WeaponIndex;  //���� ��ȣ
        [SerializeField]
        string WeaponName;
        [SerializeField]
        int UseCount;//������ ��� Ƚ��
 
        [SerializeField]
        float Weapon_Power;
        [SerializeField]
        string[] AttackType;

        //���� ����ü�� get set�Լ���
        public int GetWeaponIndex() { return WeaponIndex; }
        public void SetWeaponIndex(int m) { WeaponIndex = m; }

        public int GetUseCount() { return UseCount; }
        public void SetUseCount(int m) { UseCount = m; }

        public string GetAttackType(int a) { return AttackType[a]; }
        public float GetWeaponPower() { return Weapon_Power; }
    }


}
