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
        if (Input.GetKeyDown(KeyCode.Space))//ìGÇ™éÄÇÒÇæê›íË
        {
            ScoreManager.instance.ScoreCount(Score);
           // Debug.Log("Ç®Ç¢Ç¢Ç¢Ç¢Ç¢Ç¢Ç¢Ç∑");
        }

    }
}
