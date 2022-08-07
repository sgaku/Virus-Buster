using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatusUI : MonoBehaviour
{
    Text StatusTextMoveSpeed;
    Text StatusTextFireRate;
    Text StatusTextSpeciallSkill;

    
    // Start is called before the first frame update
    void Start()
    {
        StatusTextMoveSpeed = GameObject.Find("StatusTextMoveSpeed").GetComponent<Text>();
        StatusTextFireRate = GameObject.Find("StatusTextFireRate").GetComponent<Text>();
//        StatusTextSpeciallSkill = GameObject.Find("StatusTextSpeciallSkill").GetComponent<Text>();

        int inMoveSpeedLevel;
        inMoveSpeedLevel =  PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        inMoveSpeedLevel += 1;
        StatusTextMoveSpeed.text = "移動速度　LV." + inMoveSpeedLevel;

        int inrFireRateLevel;
        inrFireRateLevel =  PlayerPrefs.GetInt("FireRateLevel", 0);
        inrFireRateLevel += 1;
        StatusTextFireRate.text = "連射速度 LV." + inrFireRateLevel;

      //  int SpeciallSkillLevel;
    //    SpeciallSkillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
  //      SpeciallSkillLevel += 1;
//        StatusTextSpeciallSkill.text = "必殺技　LV." + SpeciallSkillLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
