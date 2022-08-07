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
    [SerializeField] private int[] expTableSkill;
    [SerializeField] private Text speedLevelText;
    [SerializeField] private Text rateLevelText;
    [SerializeField] private Text powerLevelText;
    [SerializeField] private Text skillLevelText;
    [SerializeField] private Text speedLevelPointText;
    [SerializeField] private Text rateLevelPointText;
    [SerializeField] private Text powerLevelPointText;
    [SerializeField] private Text skillLevelPointText;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private int a;
    [SerializeField] private AudioClip levelUpAudio;
    [SerializeField] private GameObject skillGetPanel;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        int scorePoint = PlayerPrefs.GetInt("SCORE2", a);
        totalScoreText.text = scorePoint.ToString();
        if(expTable.Length <= PlayerPrefs.GetInt("FireRateLevel", 0))
        {
            rateLevelText.text = "MAX";
            rateLevelPointText.text = "0";
        }
        else
        {
            int fireRateLevel = PlayerPrefs.GetInt("FireRateLevel", 0);
            rateLevelText.text = "LV." + (fireRateLevel+1).ToString();
            int fireRatePoint = expTable[PlayerPrefs.GetInt("FireRateLevel")] - PlayerPrefs.GetInt("FireRatePoint", 0);
            rateLevelPointText.text = fireRatePoint.ToString();
        }

        if (expTable.Length <= PlayerPrefs.GetInt("MoveSpeedLevel", 0))
        {
            speedLevelText.text = "MAX";
            speedLevelPointText.text = "0";
        }
        else
        {
            int moveSpeedPoint = expTable[PlayerPrefs.GetInt("MoveSpeedLevel")] - PlayerPrefs.GetInt("MoveSpeedPoint", 0);
            int moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
            speedLevelText.text = "LV." + (moveSpeedLevel+1).ToString();
            speedLevelPointText.text = moveSpeedPoint.ToString();
        }

        if(expTable.Length <= PlayerPrefs.GetInt("BulletPowerLevel", 0))
        {
            powerLevelText.text = "MAX";
            powerLevelPointText.text = "0";
        }
        else
        {
            int bulletPowerPoint = expTable[PlayerPrefs.GetInt("BulletPowerLevel")] - PlayerPrefs.GetInt("BulletPowerPoint", 0);
            int bulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
            powerLevelText.text = "LV." + (bulletPowerLevel+1).ToString();
            powerLevelPointText.text = bulletPowerPoint.ToString();
        }

        if(expTableSkill.Length <= PlayerPrefs.GetInt("SkillLevel", 0))
        {
            skillLevelText.text = "MAX";
            skillLevelPointText.text = "0";
        }
        else
        {
            int skillPoint = expTableSkill[PlayerPrefs.GetInt("SkillLevel")] - PlayerPrefs.GetInt("SkillPoint", 0);
            int skillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
            skillLevelText.text = "LV." + (skillLevel+1).ToString();
            skillLevelPointText.text = skillPoint.ToString();
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointUpFireRate()
    {
        int scorePoint = PlayerPrefs.GetInt("SCORE2", 0);
        if(scorePoint < 100 || expTable.Length <= PlayerPrefs.GetInt("FireRateLevel", 0))
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
        if(scorePoint < 100 || expTable.Length <= PlayerPrefs.GetInt("MoveSpeedLevel", 0))
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();

        int moveSpeedPoint = PlayerPrefs.GetInt("MoveSpeedPoint", 0);
        int moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        int nowPoint = int.Parse(speedLevelPointText.text) - pointUnit;
        speedLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("MoveSpeedPoint",  moveSpeedPoint + pointUnit);
        if(nowPoint == 0)
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
        if(scorePoint < 100 || expTable.Length <= PlayerPrefs.GetInt("BulletPowerLevel", 0))
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();

        int bulletPowerPoint = PlayerPrefs.GetInt("BulletPowerPoint", 0);
        int bulletPowerLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        int nowPoint = int.Parse(skillLevelPointText.text) - pointUnit;
        powerLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("BulletPowerPoint", bulletPowerPoint + pointUnit);
        if(nowPoint == 0)
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
        if(scorePoint < 100 || expTable.Length <= PlayerPrefs.GetInt("SkillLevel", 0))
        {
            
            return;
        }
        scorePoint -= 100;
        PlayerPrefs.SetInt("SCORE2", scorePoint);
        totalScoreText.text = scorePoint.ToString();

        int skillPoint = PlayerPrefs.GetInt("SkillPoint", 0);
        int skillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        int nowPoint = int.Parse(skillLevelPointText.text) - pointUnit;
        skillLevelPointText.text = nowPoint.ToString();
        PlayerPrefs.SetInt("SkillPoint", skillPoint + pointUnit);
        if(nowPoint == 0)
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
        audio.PlayOneShot(levelUpAudio);

        //float nowFireRate = PlayerPrefs.GetFloat("FireRate", 0.3f);
        //PlayerPrefs.SetFloat("FireRate", nowFireRate - 0.05f);
        int nowLevel = PlayerPrefs.GetInt("FireRateLevel", 0);
        PlayerPrefs.SetInt("FireRateLevel", nowLevel+1);
        rateLevelText.text = "LV." + (nowLevel + 2).ToString();
        if(nowLevel + 1 >= expTable.Length)
        {
            rateLevelText.text = "MAX";
            return;
        }
        //PlayerPrefs.SetInt("FireRatePoint", expTable[nowLevel+1]);

        rateLevelPointText.text = expTable[nowLevel+1].ToString();
    }
    
    public void LevelUpMoveSpeed()
    {
        audio.PlayOneShot(levelUpAudio);

        float nowMoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", initMoveSpeed);
        PlayerPrefs.SetFloat("MoveSpeed", nowMoveSpeed + 0.1f);
        int nowLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        PlayerPrefs.SetInt("MoveSpeedLevel", nowLevel+1);

        speedLevelText.text = "LV." + (nowLevel+2).ToString();

        if(nowLevel + 1 >= expTable.Length)
        {
            speedLevelText.text = "MAX";
            return;
        }
        //PlayerPrefs.SetInt("MoveSpeedPoint", expTable[nowLevel+1]);

        speedLevelPointText.text = expTable[nowLevel+1].ToString();

    }

    public void LevelUpBulletPower()
    {
        audio.PlayOneShot(levelUpAudio);

        float nowBulletPower = PlayerPrefs.GetFloat("BulletPower", initBulletPower);
        PlayerPrefs.SetFloat("BulletPower", nowBulletPower + 1);
        int nowLevel = PlayerPrefs.GetInt("BulletPowerLevel", 0);
        PlayerPrefs.SetInt("BulletPowerLevel", nowLevel+1);

        powerLevelText.text = "LV." + (nowLevel+2).ToString();

        if(nowLevel + 1 >= expTable.Length)
        {
            speedLevelText.text = "MAX";
            return;
        }
        //PlayerPrefs.SetInt("BulletPowerPoint", expTable[nowLevel+1]);


        powerLevelPointText.text = expTable[nowLevel+1].ToString();
    }

    public void LevelUpSkill()
    {
        audio.PlayOneShot(levelUpAudio);
        float skillLevel = PlayerPrefs.GetFloat("SkillLevel", 0);
        if(skillLevel == 0)
        {
            skillGetPanel.SetActive(true);
        }
        PlayerPrefs.SetFloat("SkillLevel", skillLevel+1);
        int nowLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        PlayerPrefs.SetInt("SkillLevel", nowLevel+1);

        skillLevelText.text = "LV." + (nowLevel+2).ToString();
        if(nowLevel + 1 >= expTableSkill.Length)
        {
            skillLevelText.text = "MAX";
            return;
        }
        //PlayerPrefs.SetInt("skillPoint", expTableSkill[nowLevel+1]);


        skillLevelPointText.text = expTableSkill[nowLevel+1].ToString();

    }

    public void CloseGetSkillPanel()
    {
        skillGetPanel.SetActive(false);
    }




}
