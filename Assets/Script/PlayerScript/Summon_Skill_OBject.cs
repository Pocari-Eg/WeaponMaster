using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon_Skill_OBject : MonoBehaviour
{
    public Transform Player; // �÷��̾� ��ġ �տ� �����ϱ� ����

    public GameObject ObjPrefab; // ��ų ������� ���� ������Ʈ ground_tile32.png

    private int count = 0; // ���� Ƚ��

    public float CoolTime; // ��ų ��Ÿ��

    private void Start()
    {
        Player = this.gameObject.transform;
    }
    private void Update()
    {
        // Ƚ���� 3ȸ �̻��̶�� ���̻� �ð��� ���� ��ų �ʿ䰡 ����
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

     
        // ��Ÿ�� �ð��� 5�ʰ� �����ٸ� ��� ����

        // ���� 0�ʷ� �ʱ�ȭ

        // ī��Ʈ Ƚ�� 3���� �� �� ���� ����

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
