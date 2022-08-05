using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class ScoreManage : MonoBehaviour

{
    private Text ScoreText;//スコアを表示するテキスト
    private Text HighScoreText;//これまでのハイスコアを表示する

    private int TotalScore = 0;//スコアの合計
    private int EndScore;//プレイヤーが死んだときのスコア
    private int HighScore = 0;//前回までのハイスコア

    GameObject ScoreRanking;//ランキングのゲームオブジェクトを取得

    public static ScoreManage instance;//instanceで呼び出す用

    public GameObject score_object = null; // Textオブジェクト
    private int score_num = 0; // スコア変数

    public void Awake()//外から呼び出せるように
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // 初期化時の処理
    void Start()
    {






        int newHighScore;
        // スコアのロード
        newHighScore = PlayerPrefs.GetInt("SCORE1",1000);
        Debug.Log("hoge" + newHighScore);
    }
    // 削除時の処理
    

    // 更新
    void Update()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();//スコアテキストを名前で取得
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();//名前で取得
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();



        ScoreText.text = "Score:" + TotalScore.ToString();//スコアを更新、表示
        HighScoreText.text = "HighScore:" + HighScore;//ハイスコアの表示
        
    }
    public void ScoreCount(int e)//スコア加算のメソッド
    {
        TotalScore += e;//引数入れればスコア加算できる
    }
    public void PlayerDeath()//プレイヤーが死んだzら
    {
        EndScore = TotalScore;//最終スコアを格納
        if (EndScore >= HighScore)//今回とハイスコアを比べる
        {
            HighScore = EndScore;//ハイスコアを更新
        }
    }
    void OnDestroy()
    {
        // スコアを保存
        PlayerPrefs.SetInt("SCORE1", HighScore);
        PlayerPrefs.Save();
    }
}
