using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon_Skill_OBject : MonoBehaviour
{
    public Transform Player; // 플레이어 위치 앞에 생성하기 위해

    public GameObject ObjPrefab; // 스킬 사용으로 인한 오브젝트 ground_tile32.png

    private int count = 0; // 제한 횟수

    public float CoolTime; // 스킬 쿨타임

    private void Start()
    {
        Player = this.gameObject.transform;
    }
    private void Update()
    {
        // 횟수가 3회 이상이라면 더이상 시간을 증가 시킬 필요가 없음
        if (count >= 3)
        {

        }
        else
        {
            CoolTime += Time.deltaTime;
        }
    }
    public void On_Skill_Button()
    {

     
        // 쿨타임 시간이 5초가 지났다면 사용 가능

        // 사용시 0초로 초기화

        // 카운트 횟수 3이하 일 시 생성 가능

        if(CoolTime >= 5f)
        {
            CoolTime = 0f;

            if (count <= 3)
            {
                

                if (Script_WeaponManager.instance.isInfinity==false)
                    count++;
                if (Player.transform.localRotation == new Quaternion(0,1,0,0)|| Player.transform.localRotation == new Quaternion(0, -1, 0, 0)) 
                {
                    GameObject Skill_Obj = Instantiate(ObjPrefab, Player.position + new Vector3(-3f, 0f, 0f), transform.rotation);

                }
                else if (Player.transform.localRotation==new Quaternion(0, 0, 0, 1))
                {
                    GameObject Skill_Obj = Instantiate(ObjPrefab, Player.position + new Vector3(3f, 0f, 0f), transform.rotation);

                }
                Player.GetComponent<Script_MainPlayer>().SkillUse = true;
            }
            else
            {
             
            }
        }
    }

   
}
