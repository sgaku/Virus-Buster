using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CharaManager charaManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ウイルスと衝突したとき
        if (collision.gameObject.tag == "Virus")
        {
            //死亡時のメソッド呼び出し
            charaManager.startCoroutineDead();
        }
        Debug.Log("OnCollisionEnter2D: " + collision.gameObject.name);
    }

}
