using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text ScoreText;//スコアを表示するテキスト
    private Text HighScoreText;//これまでのハイスコアを表示する

    private int TotalScore = 0;//スコアの合計
    private int EndScore;//プレイヤーが死んだときのスコア
    private int HighScore = 0;//前回までのハイスコア

    GameObject ScoreRanking;//ランキングのゲームオブジェクトを取得
   
    public static ScoreManager instance;//instanceで呼び出す用

    // Start is called before the first frame update
    public void Awake()//外から呼び出せるように
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    
}
