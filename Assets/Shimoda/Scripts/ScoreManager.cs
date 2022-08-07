using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour

{
    private Text ScoreText;//スコアを表示するテキスト
    private Text HighScoreText;//これまでのハイスコアを表示する
    private Text KillEnemyText;//殺した敵の数のテキスト

    public int TotalScore = 0;//スコアの合計
    [HideInInspector] public int EndScore;//プレイヤーが死んだときのスコア
    private int HighScore = 0;//前回までのハイスコア
    private int TotalKill = 0;//総キル数

    GameObject ScoreRanking;//ランキングのゲームオブジェクトを取得
    private GameObject ResultCanvas;//リザルトキャンバス

    public static ScoreManager instance;//instanceで呼び出す用

    [SerializeField] GameObject SkillPanel;
    [SerializeField] Text skillCountText;
    public int skillCount;

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
        newHighScore = PlayerPrefs.GetInt("SCORE1", 1000);
        HighScore = newHighScore;


        int newScore;
        newScore = PlayerPrefs.GetInt("SCORE2", 0);
        ResultCanvas = GameObject.Find("ResultCanvas");//リザルトキャンバスを無効化

        ResultCanvas.SetActive(false);

        if (ServiceLocator.i.charaManager.specialSkill.skill1)
        {
            SkillPanel.SetActive(true);
        }

        
    }
    // 削除時の処理


    // 更新
    void Update()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();//スコアテキストを名前で取得
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();//名前で取得
        KillEnemyText = GameObject.Find("KillEnemyText").GetComponent<Text>();//名前で取得
        ScoreText.text = "スコア:" + TotalScore.ToString();//スコアを更新、表示
        HighScoreText.text = "ハイスコア:" + HighScore;//ハイスコアの表示
        KillEnemyText.text = "倒したウイルス\n" + TotalKill.ToString();//キル数の表示
    }
    public void ScoreCount(int e)//スコア加算のメソッド
    {
        TotalScore += e;//引数入れればスコア加算できる
    }
    public void KillCount()//キル数加算のメソッド
    {
        TotalKill++;//呼べばスコア加算できる
    }
    public void PlayerDeath()//プレイヤーが死んだzら
    {
        EndScore = TotalScore;//最終スコアを格納
        Debug.Log("EndScoreは" + EndScore);
        if (EndScore >= HighScore)//今回とハイスコアを比べる
        {
            HighScore = EndScore;//ハイスコアを更新
        }
        // スコアを保存
        PlayerPrefs.SetInt("SCORE1", HighScore);
        PlayerPrefs.SetInt("SCORE2", EndScore);
        PlayerPrefs.Save();


        ResultCanvas.SetActive(true);//リザルトキャンバスを召喚
    }
    void OnDestroy()
    {

    }
}
