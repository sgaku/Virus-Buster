using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    int Score = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//敵が死んだ設定
        {
            ScoreManager.instance.ScoreCount(Score);//スコアを引数に入れて合計スコアを増やすメソッド
            ScoreManager.instance.KillCount();//キル数増やす
        }

    }
}
