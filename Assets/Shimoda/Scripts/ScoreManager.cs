using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text ScoreText;//�X�R�A��\������e�L�X�g
    private Text HighScoreText;//����܂ł̃n�C�X�R�A��\������

    private int TotalScore = 0;//�X�R�A�̍��v
    private int EndScore;//�v���C���[�����񂾂Ƃ��̃X�R�A
    private int HighScore = 0;//�O��܂ł̃n�C�X�R�A

    GameObject ScoreRanking;//�����L���O�̃Q�[���I�u�W�F�N�g���擾
   
    public static ScoreManager instance;//instance�ŌĂяo���p

    // Start is called before the first frame update
    public void Awake()//�O����Ăяo����悤��
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
