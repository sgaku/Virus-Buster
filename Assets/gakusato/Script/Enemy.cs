using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵の追跡機能を実装
/// </summary>
public class Enemy : MonoBehaviour
{
    //敵のスコアをつける？？
    public int score;

    //追跡するターゲット
    Transform targetObject;
    //移動に使うrigidBody
    [SerializeField] Rigidbody2D rigidBody2d;
    [SerializeField] SpriteRenderer spriteRenderer;
    //移動スピード
    [SerializeField] float speed;
    //死亡エフェクト
    [SerializeField] GameObject deadEffect;
    // [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deadAudio;
    //移動する際の角度
    float angle;
    //前フレームの位置情報
    Vector2 prePosition;
    //ターゲットの方向
    Vector2 direction;
    //前のフレームとの位置の差
    Vector2 diffPos;

    float _time;

    bool isChangeStatus = false;

    float currentTime;

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
        // Debug.Log(other.gameObject.name);
        //死亡判定
        if (other.gameObject.CompareTag("Bullet"))
        {

            //当たってきた球も消す
            Instantiate(deadEffect, transform.position, Quaternion.Euler(-45, 0, 0));
            other.gameObject.SetActive(false);
            ServiceLocator.i.scoreManager.ScoreCount(score);
            currentVirusState = VirusState.Dead;
            // deadEffect.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(deadAudio, transform.position);

            //Destroyは重くなるのでsetActiveを使用
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("ChargeBullet"))
        {
            ServiceLocator.i.scoreManager.ScoreCount(score);
            currentVirusState = VirusState.Dead;
            // deadEffect.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(deadAudio, transform.position);
            //Destroyは重くなるのでsetActiveを使用
            gameObject.SetActive(false);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        targetObject = ServiceLocator.i.virusCreator.TargetPosition;
        currentVirusState = VirusState.Alive;
        prePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ServiceLocator.i.charaManager.currentCharaState == CharaManager.CharaState.Dead) gameObject.SetActive(false);
        currentTime += Time.deltaTime;
        if (currentTime >= 10)
        {
            //スプライトのアルファ値を点滅させる
            var color = spriteRenderer.color;
            //0~1 -> 0.5~1
            color.a = (Mathf.Sin(Time.time * 6f) / 2 + 0.5f) / 2 + 0.5f;

            // Debug.Log(color.a);
            spriteRenderer.color = color;
            if (!isChangeStatus) ChangeVirusStatus();
        }
    }

    void FixedUpdate()
    {
        if (currentVirusState == VirusState.Dead) return;
        VirusMove();
    }
    void ChangeVirusStatus()
    {

        speed += 1.5f;
        isChangeStatus = true;
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
