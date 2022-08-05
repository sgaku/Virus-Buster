using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の追跡機能を実装
/// </summary>
public class Enemy : MonoBehaviour
{
    public int score;
    //追跡するターゲット
    [SerializeField] Transform targetObject;
    //移動に使うrigidBody
    [SerializeField] Rigidbody2D rigidBody2d;
    //移動スピード
    float speed = 4f;
    //移動する際の角度
    float angle;
    //前フレームの位置情報
    Vector2 prePosition;
    //ターゲットの方向
    Vector2 direction;
    //前のフレームとの位置の差
    Vector2 diffPos;



    // Start is called before the first frame update
    void Start()
    {
        prePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        VirusMove();
    }
    void VirusMove()
    {
        float x = targetObject.transform.position.x;
        float y = targetObject.transform.position.y;
        //方向の取得
        direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        rigidBody2d.velocity = direction * speed;

        //Vector2に変換
        Vector2 Position = transform.position;
        //フレーム間の位置の差を計算
        diffPos = Position - prePosition;
        //移動する際に、ターゲットの方を向くように計算
        if (diffPos.magnitude > 0.01f)
        {
            angle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //位置の更新
        prePosition = Position;
    }
}
