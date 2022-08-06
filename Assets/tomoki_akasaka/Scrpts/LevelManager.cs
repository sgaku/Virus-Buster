using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float initMoveSpeed;
    public float initFireRate;
    public float initBulletPower;
    [SerializeField] private int pointUnit;
    [SerializeField] private int[] expTable;
    [SerializeField] private Text speedLevelText;
    [SerializeField] private Text rateLevelText;
    [SerializeField] private Text powerLevelText;
    [SerializeField] private Text skillLevelText;
    [SerializeField] private Text speedLevelPointText;
    [SerializeField] private Text rateLevelPointText;
    [SerializeField] private Text powerLevelPointText;
    [SerializeField] private Text skillLevelPointText;
    [SerializeField] private Text totalScoreText;


    // Start is called before the first frame update
    void Start()
    {
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointUpFireRate()
    {
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
        if(scorePoint < 100)
        {

            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();


        int fireRatePoint = PlayerPrefs.GetInt("FireRatePoint", 0);
        int fireRateLevel = PlayerPrefs.GetInt("FireRateLevel", 0);
        int nowPoint = int.Parse(rateLevelPointText.text) - pointUnit;
        rateLevelPointText.text = nowPoint.ToString();

        PlayerPrefs.SetInt("FireRatePoint", fireRatePoint + pointUnit);
        if(nowPoint == 0)
        {
            PlayerPrefs.SetInt("FireRatePoint", 0);
            LevelUpFireRate();
        }
        else
        {
            PlayerPrefs.SetInt("FireRatePoint", fireRatePoint + pointUnit);
        }
    }

    public void PointUpMoveSpeed()
    {
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
        if(scorePoint < 100)
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();

        int moveSpeedPoint = PlayerPrefs.GetInt("MoveSpeedPoint", 0);
        int moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        int nowPoint = int.Parse(rateLevelPointText.text) - pointUnit;
        speedLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("MoveSpeedPoint",  moveSpeedPoint + pointUnit);
        if(moveSpeedPoint + pointUnit >= expTable[moveSpeedLevel])
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
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
        if(scorePoint < 100)
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();

        int bulletPowerPoint = PlayerPrefs.GetInt("BulletPowerPoint", 0);
        int bulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        int nowPoint = int.Parse(rateLevelPointText.text) - pointUnit;
        powerLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("BulletPowerPoint", bulletPowerPoint + pointUnit);
        if(bulletPowerPoint + pointUnit >= expTable[bulletPowerLevel])
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
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
        if(scorePoint < 100)
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();
        
        int skillPoint = PlayerPrefs.GetInt("SkillPoint", 0);
        int skillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        int nowPoint = int.Parse(rateLevelPointText.text) - pointUnit;
        skillLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("SkillPoint", skillPoint + pointUnit);
        if(skillPoint + pointUnit >= expTable[skillLevel])
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
        rateLevelText.text = "LV." + (nowFireRateLevel + 1).ToString();
        rateLevelPointText.text = expTable[nowFireRateLevel+1].ToString();
        
    }
    
    public void LevelUpMoveSpeed()
    {
        float nowMoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", initMoveSpeed);
        PlayerPrefs.SetFloat("MoveSpeed", nowMoveSpeed + 0.1f);
        int nowMoveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedLevel", nowMoveSpeedLevel+1);
        speedLevelText.text = "LV." + (nowMoveSpeedLevel+1).ToString();
        speedLevelPointText.text = expTable[nowMoveSpeedLevel+1].ToString();
    }

    public void LevelUpBulletPower()
    {
        float nowBulletPower = PlayerPrefs.GetFloat("BulletPower", initBulletPower);
        PlayerPrefs.SetFloat("BulletPower", nowBulletPower + 1);
        int nowBulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        PlayerPrefs.SetInt("BulletPowerLevel", nowBulletPowerLevel+1);
        powerLevelText.text = "LV." + (nowBulletPowerLevel+1).ToString();
        powerLevelPointText.text = expTable[nowBulletPowerLevel+1].ToString();
    }

    public void LevelUpSkill()
    {
        float skillLevel = PlayerPrefs.GetFloat("SkillLevel", 0);
        PlayerPrefs.SetFloat("SkillLevel", skillLevel+1);
        int nowSkillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        PlayerPrefs.SetInt("SkillLevel", nowSkillLevel+1);
        skillLevelText.text = "LV." + (nowSkillLevel+1).ToString();
        skillLevelPointText.text = expTable[nowSkillLevel+1].ToString();
    }


}
