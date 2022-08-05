using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ����܂��傤

public class ScoreManage : MonoBehaviour

{
    private Text ScoreText;//�X�R�A��\������e�L�X�g
    private Text HighScoreText;//����܂ł̃n�C�X�R�A��\������

    private int TotalScore = 0;//�X�R�A�̍��v
    private int EndScore;//�v���C���[�����񂾂Ƃ��̃X�R�A
    private int HighScore = 0;//�O��܂ł̃n�C�X�R�A

    GameObject ScoreRanking;//�����L���O�̃Q�[���I�u�W�F�N�g���擾

    public static ScoreManage instance;//instance�ŌĂяo���p

    public GameObject score_object = null; // Text�I�u�W�F�N�g
    private int score_num = 0; // �X�R�A�ϐ�

    public void Awake()//�O����Ăяo����悤��
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // ���������̏���
    void Start()
    {






        int newHighScore;
        // �X�R�A�̃��[�h
        newHighScore = PlayerPrefs.GetInt("SCORE1",1000);
        Debug.Log("hoge" + newHighScore);
    }
    // �폜���̏���
    

    // �X�V
    void Update()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();//�X�R�A�e�L�X�g�𖼑O�Ŏ擾
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();//���O�Ŏ擾
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();



        ScoreText.text = "Score:" + TotalScore.ToString();//�X�R�A���X�V�A�\��
        HighScoreText.text = "HighScore:" + HighScore;//�n�C�X�R�A�̕\��
        
    }
    public void ScoreCount(int e)//�X�R�A���Z�̃��\�b�h
    {
        TotalScore += e;//���������΃X�R�A���Z�ł���
    }
    public void PlayerDeath()//�v���C���[������z��
    {
        EndScore = TotalScore;//�ŏI�X�R�A���i�[
        if (EndScore >= HighScore)//����ƃn�C�X�R�A���ׂ�
        {
            HighScore = EndScore;//�n�C�X�R�A���X�V
        }
    }
    void OnDestroy()
    {
        // �X�R�A��ۑ�
        PlayerPrefs.SetInt("SCORE1", HighScore);
        PlayerPrefs.Save();
    }
}
