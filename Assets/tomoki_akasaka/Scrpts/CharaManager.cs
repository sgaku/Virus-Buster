using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharaManager : MonoBehaviour
{
    //プレイヤーのパラメータ
    //プレイヤーの速度
    public float speed = 0.5f;
    //弾の連射速度
    public float fireRate;
    
    GameObject [] childObject;
    private int o_max = 4;
    public GameObject nowObj;

    //効果音関係
    AudioSource audioSource;
    public AudioClip shootAudio;
    public AudioClip deadAudio;

    //移動方法のオプション
    public int moveOption;
    public Rigidbody playerRigidbody;

    //弾の生成に使用
    
    public BulletController bullet;
    Plane plane = new Plane();
	float distance = 0;

    public Vector3 diffCamera;
    public GameObject camera;
    public Special specialSkill;


    

    // Start is called before the first frame update
    void Start()
    {



        //カメラ追従の設定
        //camera = GameObject.FindWithTag("MainCamera");
        //diffCamera = camera.transform.position;

        audioSource = transform.GetComponent<AudioSource>();
        childObject = new GameObject[o_max];

		for(int i = 0; i < o_max ; i++){
			childObject[i] = transform.GetChild(i).gameObject;
		}
		
        //子オブジェクトを無効に
		foreach(GameObject gamObj in childObject)
        {
			gamObj.SetActive(false);
		}
        //rlfleupオブジェクトだけ有効
        nowObj = gameObject.transform.Find("rifle_down").gameObject;
        nowObj.SetActive(true);

        //playerRigidbody = nowObj.GetComponent<Rigidbody>();
        //plane.SetNormalAndPosition (Vector3.back, transform.localPosition);

        //コルーチンで弾の生成
         StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ww");
        if(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Z))
        {
            Debug.Log("a");
            specialSkill.chargeShot();
        }
        Move();
        //カメラをキャラクターに追従させる
        //camera.transform.position = transform.position + diffCamera;


        
    }

    void Move()
    {
                //マウスカーソルの位置に方向を向ける。実装できたらよし
        if (moveOption== 1)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 charaPos = transform.position;

            float a = (mousePos.y - charaPos.y) / (mousePos.x - charaPos.x);
            float angle = MathF.Atan(a);

            nowObj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle*360);
            Vector2 position1 = transform.position;
            //Debug.Log(MathF.Sin(angle));
            //Debug.Log(MathF.Cos(angle));


            var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            var pos = Camera.main.WorldToScreenPoint (nowObj.transform.position);
		    var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            
            //Debug.Log(rotation.z);
            nowObj.transform.rotation = rotation;
            //position1.x += speed * MathF.Sin(angle);
            //position1.y += speed * MathF.Sin(angle);
            //transform.position = position1;
        }

        //audioSource.PlayOneShot(sound1);

        //基本的な移動
        Vector2 position = transform.position;


        if (Input.GetKey("left") || Input.GetKey((KeyCode.A)))
        {
            position.x -= speed;

            /*
            if(nowObj.name != "rifle_left")
            {
                nowObj.SetActive(false);
                nowObj = gameObject.transform.Find("rifle_left").gameObject;
                nowObj.SetActive(true);
            }
            */
            
            

        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            position.x += speed;
            /*
            if(nowObj.name != "rifle_right")
            {
                nowObj.SetActive(false);

                nowObj = gameObject.transform.Find("rifle_right").gameObject;
                nowObj.SetActive(true);
            }
            */


        }
        else if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            position.y += speed;
            /*
            if(nowObj.name != "rifle_up")
            {
                nowObj.SetActive(false);

                nowObj = gameObject.transform.Find("rifle_up").gameObject;
                nowObj.SetActive(true);
            }
            */
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            position.y -= speed;
            /*
            if(nowObj.name != "rifle_down")
            {
                nowObj.SetActive(false);

                nowObj = gameObject.transform.Find("rifle_down").gameObject;
                nowObj.SetActive(true);
            }
            */
        }

        transform.position = position;
    }

    //弾を発射するコルーチン
    //fireRateで弾の連射速度を調整
    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Vector3 pos = nowObj.transform.Find("bulletPosition").gameObject.transform.position;
     
            BulletController nowBullet = Instantiate(bullet, pos, nowObj.transform.rotation);
            audioSource.PlayOneShot(shootAudio);

            //nowBullet.shotForward = nowObj.transform.rotation.eulerAngles;
            //nowBullet.shotForward = nowObj.transform.forward;
            var shotForward = (pos -nowObj.transform.Find("muzzleflash_rifle").gameObject.transform.position).normalized;

            //Debug.Log(nowBullet.shotForward);
            //nowBullet.rotation=nowObj.name;
            nowBullet.Shoot(shotForward);

            //nowBullet.rad = Quaternion.Euler(nowObj.transform.Find("bulletPosition").gameObject.transform.position - nowObj.transform.position );
     
        }
    }

    public void startCoroutineDead()
    {
        StartCoroutine("Dead");
    }

    private IEnumerator Dead()
    {
        //死亡時のメソッド呼び出し
        nowObj.SetActive(false);
        GameObject downObj = transform.Find("hit2_down").gameObject;
        downObj.SetActive(true);
        audioSource.PlayOneShot(deadAudio);
        yield return new WaitForSeconds(3);
        downObj.SetActive(false);

    }
}
