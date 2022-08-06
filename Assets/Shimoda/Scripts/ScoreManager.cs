using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // �ǉ����܂��傤

public class ScoreManager : MonoBehaviour

{
    private Text ScoreText;//�X�R�A��\������e�L�X�g
    private Text HighScoreText;//����܂ł̃n�C�X�R�A��\������

    private int TotalScore = 0;//�X�R�A�̍��v
    [HideInInspector] public int EndScore;//�v���C���[�����񂾂Ƃ��̃X�R�A
    private int HighScore = 0;//�O��܂ł̃n�C�X�R�A

    GameObject ScoreRanking;//�����L���O�̃Q�[���I�u�W�F�N�g���擾
    private GameObject ResultCanvas;//���U���g�L�����o�X

    public static ScoreManager instance;//instance�ŌĂяo���p


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

        newHighScore = PlayerPrefs.GetInt("SCORE1",0);

        Debug.Log("hoge" + newHighScore);
        HighScore = newHighScore;

        ResultCanvas = GameObject.Find("ResultCanvas");//���U���g�L�����o�X�𖳌���
        ResultCanvas.SetActive(false);
    }

    // �폜���̏���
    

    // �X�V
    void Update()
    {

        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();//�X�R�A�e�L�X�g�𖼑O�Ŏ擾
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();//���O�Ŏ擾
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
        Debug.Log("EndScore��" + EndScore);
        if (EndScore >= HighScore)//����ƃn�C�X�R�A���ׂ�
        {
            HighScore = EndScore;//�n�C�X�R�A���X�V
        }
        // �X�R�A��ۑ�
        PlayerPrefs.SetInt("SCORE1", HighScore);
        PlayerPrefs.Save();
        ResultCanvas.SetActive(true);//���U���g�L�����o�X������
    }
    void OnDestroy()
    {

    }
}
