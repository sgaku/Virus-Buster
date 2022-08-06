using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text resultScore;
    // Start is called before the first frame update
    void Start()
    {

        resultScore = this.gameObject.GetComponent<Text>();
        resultScore.text = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().EndScore.ToString();
    }
    

    // Update is called once per frame
    void Update()
    {

            resultScore.text = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().EndScore.ToString();//
        
    }
}
