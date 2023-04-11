using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_WeaponManager : MonoBehaviour
{
    public static Script_WeaponManager instance;

    public bool isInfinity = false;
    enum WeaponType{Hammer,Rapier };
    [SerializeField]
    WeaponType weapon;
    int LastUInum = 0;
    [SerializeField]
    GameObject[] WeaponData;
    [SerializeField]
    GameObject[] WeaponUI;
    [SerializeField]
    GameObject[] SkillBT;
    [SerializeField]
    GameObject WeaponSpawn;
    [SerializeField]
    bool isSpawn = true;

    public bool SkillOn = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (isSpawn)
        {
            WeaponCreate();
        }
    }

    public void WeaponCreate()
    {
       
        Instantiate(WeaponData[((int)weapon)], new Vector3(WeaponSpawn.transform.position.x, WeaponSpawn.transform.position.y, -1.0f), Quaternion.identity);
     
    }

    public void SetWeaponUI(int num)
    {
        DeleteWeaponUi(LastUInum);
          WeaponUI[num].SetActive(true);
        if (SkillOn&&num==0)
        {
           
            SkillBT[num].SetActive(true);
        }
        LastUInum = num;
    }
    public void DeleteWeaponUi(int num)
    {
        WeaponUI[num].SetActive(false);
    }

    public GameObject[] GetWeaponData() { return WeaponData; }

}
