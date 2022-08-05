using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の追跡機能を実装
/// </summary>
public class Enemy : MonoBehaviour
{
    //敵のスコアをつける？？
    // public int score;

    //追跡するターゲット
    [SerializeField] Transform targetObject;
    //移動に使うrigidBody
    [SerializeField] Rigidbody2D rigidBody2d;
    //死亡したらこのオブジェクトを親にする
    [SerializeField] Transform deadParent;
    //移動スピード
    [SerializeField] float speed;
    //移動する際の角度
    float angle;
    //前フレームの位置情報
    Vector2 prePosition;
    //ターゲットの方向
    Vector2 direction;
    //前のフレームとの位置の差
    Vector2 diffPos;

    //ウイルスの状態管理（いらないかも？）
    public enum VirusState
    {
        Alive,
        Dead,
    }
    //現在のウイルスの状態を格納するプロパティ
    public VirusState currentVirusState { get; set; }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        //死亡判定
        if (other.gameObject.CompareTag("Bullet"))
        {
            //当たってきた球も消す
            other.gameObject.SetActive(false);
            other.transform.SetParent(deadParent);

            currentVirusState = VirusState.Dead;
            //Destroyは重くなるのでsetActiveを使用
            gameObject.SetActive(false);
            //シーンのヒエラルキー整理のため、死亡したらこのオブジェクトの子にする
            transform.SetParent(deadParent);
        }

    }
   
    // Start is called before the first frame update
    void Start()
    {
        currentVirusState = VirusState.Alive;
        prePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //SetActiveで無効にしているのでいらないかも？
        if (currentVirusState == VirusState.Dead) return;
        VirusMove();

    }

    /// <summary>
    /// ターゲットを追跡するメソッド
    /// </summary>
    void VirusMove()
    {
        float x = targetObject.transform.position.x;
        float y = targetObject.transform.position.y;
        //方向の取得
        direction = new Vector2(x - transform.position.x, y - transform.position.y).normalized;
        rigidBody2d.velocity = direction * speed;

        //Vector2に変換
        Vector2 Position = transform.position;
        //フレーム間の位置の差
        diffPos = Position - prePosition;
        //移動する際に、ターゲットの方を向くように計算
        if (diffPos.magnitude > 0.01f)
        {
            //ラジアンを角度に変更
            angle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //位置の更新
        prePosition = Position;
    }
}
