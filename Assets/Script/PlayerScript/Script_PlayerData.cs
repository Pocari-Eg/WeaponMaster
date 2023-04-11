using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//플레이어캐릭터의 정보를 담을 구조체
public class Script_PlayerData : MonoBehaviour
{
    [Serializable]
    public struct PlayerData
    {
        [SerializeField]
         int Player_Hp;  //플레이어의 체력
        [SerializeField]
      float Player_Speed; //플레이어의 이동속도
        [SerializeField]
        float Attack_Power;

        [SerializeField]
        float Player_JumpPower; //플레이어의 점프 크기
        [SerializeField]
           Sprite Player_Sprite; //플레이어의 sprite
        [SerializeField]
        Script_WeaponData.WeaponData PlayerWeapon;

        [HideInInspector]
        bool AttackActive;


        //플레이어 구조체의 get함수들
        public  int GetPlayerHp() { return Player_Hp; } 
        public float GetPlayerSpeed() { return Player_Speed; }
       public float GetPlayerJumpPower() { return Player_JumpPower; }
        public  Sprite GetPlayerSprite() { return Player_Sprite; }

        public Script_WeaponData.WeaponData GetWeaponData() { return PlayerWeapon; }
        public bool GetAttackActive() { return AttackActive; }

        public float GetAttackPower() { return Attack_Power; }

        //set 함수들ㄴ
        public void SetPlayerHp(int m) {  Player_Hp=m; }
        public void SetPlayerSpeed(float m) {  Player_Speed=m; }
        public void SetPlayerJumpPower(float m) {  Player_JumpPower=m; }
        public void SetPlayerSprite(Sprite m) {  Player_Sprite=m; }

        public void SetWeaponData(Script_WeaponData.WeaponData m) {  PlayerWeapon=m; }
        public void SetAttackActive(bool m) {  AttackActive=m; }

        public void SetAttckPower(float m) { Attack_Power = m; }

    }



}
