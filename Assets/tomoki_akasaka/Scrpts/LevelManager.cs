using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float initMoveSpeed;
    public float initFireRate;
    public float initBulletPower;
    [SerializeField] private int pointUnit;
    [SerializeField] private int[] expTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointUpFireRate()
    {
        int fireRatePoint = PlayerPrefs.GetInt("FireRatePoint", 0);
        int fireRateLevel = PlayerPrefs.GetInt("FireRateLevel", 0);
        PlayerPrefs.SetInt("FiraRatePoint", fireRatePoint + pointUnit);
        if(fireRatePoint >= expTable[fireRateLevel])
        {
            PlayerPrefs.SetInt("FiraRatePoint", 0);
            LevelUpFireRate();
        }
        else
        {
            PlayerPrefs.SetInt("FiraRatePoint", fireRatePoint + pointUnit);
        }
    }

    public void PointUpMoveSpeed()
    {
        int moveSpeedPoint = PlayerPrefs.GetInt("MoveSpeedPoint", 0);
        int moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedPoint",  moveSpeedPoint + pointUnit);
        if(moveSpeedPoint >= expTable[moveSpeedLevel])
        {
            PlayerPrefs.SetInt("MoveSpeedPoint", 0);
            LevelUpMoveSpeed();
        }
        else
        {
            PlayerPrefs.SetInt("MoveSpeedPoint", moveSpeedPoint + pointUnit);
        }
    }

    public void PointUpBulletPower()
    {
        int bulletPowerPoint = PlayerPrefs.GetInt("BulletPowerPoint", 0);
        int bulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        PlayerPrefs.SetInt("BulletPowerPoint", bulletPowerPoint + pointUnit);
        if(bulletPowerPoint >= expTable[bulletPowerLevel])
        {
            PlayerPrefs.SetInt("bulletPowerPoint", 0);
            LevelUpBulletPower();
        }
        else
        {
            PlayerPrefs.SetInt("bulletPowerPoint", bulletPowerPoint + pointUnit);
        }
    }

    public void PointUpSkill()
    {
        int skillPoint = PlayerPrefs.GetInt("SkillPoint", 0);
        int skillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        PlayerPrefs.SetInt("SkillPoint", skillPoint + pointUnit);
        if(skillPoint >= expTable[skillLevel])
        {
            PlayerPrefs.SetInt("skillPoint", 0);
            LevelUpSkill();
        }
        else
        {
            PlayerPrefs.SetInt("skillPoint", skillPoint + pointUnit);
        }
    }

    public void LevelUpFireRate()
    {
        float nowFireRate = PlayerPrefs.GetFloat("FireRate", 0.3f);
        PlayerPrefs.SetFloat("FireRate", nowFireRate - 0.05f);
        int nowFireRateLevel = PlayerPrefs.GetInt("FireRateLevel", 0);
        PlayerPrefs.SetInt("FireRateLevel", nowFireRateLevel+1);
    }
    
    public void LevelUpMoveSpeed()
    {
        float nowMoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", initMoveSpeed);
        PlayerPrefs.SetFloat("MoveSpeed", nowMoveSpeed + 0.1f);
        int nowMoveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedLevel", nowMoveSpeedLevel+1);
    }

    public void LevelUpBulletPower()
    {
        float nowBulletPower = PlayerPrefs.GetFloat("BulletPower", initBulletPower);
        PlayerPrefs.SetFloat("BulletPower", nowBulletPower + 1);
        int nowBulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        PlayerPrefs.SetInt("BulletPowerLevel", nowBulletPowerLevel+1);
    }

    public void LevelUpSkill()
    {
        float skillLevel = PlayerPrefs.GetFloat("SkillLevel", 0);
        PlayerPrefs.SetFloat("SkillLevel", skillLevel+1);
        int nowSkillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        PlayerPrefs.SetInt("SkillLevel", nowSkillLevel+1);
    }

}
