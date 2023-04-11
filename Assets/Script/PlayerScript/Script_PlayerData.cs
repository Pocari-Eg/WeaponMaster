using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�÷��̾�ĳ������ ������ ���� ����ü
public class Script_PlayerData : MonoBehaviour
{
    [Serializable]
    public struct PlayerData
    {
        [SerializeField]
         int Player_Hp;  //�÷��̾��� ü��
        [SerializeField]
      float Player_Speed; //�÷��̾��� �̵��ӵ�
        [SerializeField]
        float Attack_Power;

        [SerializeField]
        float Player_JumpPower; //�÷��̾��� ���� ũ��
        [SerializeField]
           Sprite Player_Sprite; //�÷��̾��� sprite
        [SerializeField]
        Script_WeaponData.WeaponData PlayerWeapon;

        [HideInInspector]
        bool AttackActive;


        //�÷��̾� ����ü�� get�Լ���
        public  int GetPlayerHp() { return Player_Hp; } 
        public float GetPlayerSpeed() { return Player_Speed; }
       public float GetPlayerJumpPower() { return Player_JumpPower; }
        public  Sprite GetPlayerSprite() { return Player_Sprite; }

        public Script_WeaponData.WeaponData GetWeaponData() { return PlayerWeapon; }
        public bool GetAttackActive() { return AttackActive; }

        public float GetAttackPower() { return Attack_Power; }

        //set �Լ��餤
        public void SetPlayerHp(int m) {  Player_Hp=m; }
        public void SetPlayerSpeed(float m) {  Player_Speed=m; }
        public void SetPlayerJumpPower(float m) {  Player_JumpPower=m; }
        public void SetPlayerSprite(Sprite m) {  Player_Sprite=m; }

        public void SetWeaponData(Script_WeaponData.WeaponData m) {  PlayerWeapon=m; }
        public void SetAttackActive(bool m) {  AttackActive=m; }

        public void SetAttckPower(float m) { Attack_Power = m; }

    }



}
