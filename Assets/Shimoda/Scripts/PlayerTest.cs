using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))//プレイヤーが死んだ設定
        {
            ScoreManager.instance.PlayerDeath();//ScoreMangaerから呼び出す
            //Debug.Log("aaaa");
        }
    }
}
