using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharaManager : MonoBehaviour
{
    public enum CharaState
    {
        Alive,
        Dead,
    }

    public CharaState currentCharaState{get; set;}

    [SerializeField] private Transform deadParent;
    //プレイヤーのパラメータ
    //プレイヤーの速度
    [SerializeField] private float speed = 0.5f;
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

    public bool  stopFlag;

    [SerializeField] float initialFireRate;


    [SerializeField] float initialMoveSpeed;
    [SerializeField] float initialBulletPower;

    [SerializeField] float fireRateUnit;
    [SerializeField] float bulletPowerUnit;
    [SerializeField] float speedUnit;

    

    // Start is called before the first frame update
    void Start()
    {
        //Playerの状態をAliveに
        currentCharaState = CharaState.Alive;

        //スキルレベルに応じてスキルの使用を許可
        int skillLevel = PlayerPrefs.GetInt("SkillLevel", 0);
        if (skillLevel >= 1)
        {
            specialSkill.skill1 = true;
        }
        else
        {
            specialSkill.skill1 = false;
        }

        fireRate = initialFireRate - PlayerPrefs.GetInt("FireRateLevel", 0) * fireRateUnit;
        speed = PlayerPrefs.GetInt("MoveSpeedLevel", 0) * speedUnit + initialMoveSpeed;
        float nowBulletPower = PlayerPrefs.GetInt("BulletPowerLevel", 0) * bulletPowerUnit + initialBulletPower;


        audioSource = transform.GetComponent<AudioSource>();

        //子オブジェクトを非アクティブ化
        childObject = new GameObject[o_max];
		for(int i = 0; i < o_max ; i++){
			childObject[i] = transform.GetChild(i).gameObject;
		}
		foreach(GameObject gamObj in childObject)
        {
			gamObj.SetActive(false);
		}

        //rlfleupオブジェクトだけ有効にして表示
        nowObj = gameObject.transform.Find("rifle_up").gameObject;
        nowObj.SetActive(true);

        //コルーチンで弾の生成を開始
         StartCoroutine("Shoot");
    }


    // Update is called once per frame
    void Update()
    {
        if(stopFlag)
        {
            return;
        }
        //移動処理
        Move();

        //１入力で必殺技（チャージショット）
        if(Input.GetKey(KeyCode.Alpha1) && specialSkill.skill1 == true)
        {
            specialSkill.skill1 = false;
            specialSkill.nowObj = nowObj;
            specialSkill.StartCoroutine("chargeShotCoroutine");
        }
    }

    void Move()
    {
        //マウスカーソルの位置に方向を向ける。
       
        Vector3 mousePos = Input.mousePosition;
        Vector2 charaPos = transform.position;

        float a = (mousePos.y - charaPos.y) / (mousePos.x - charaPos.x);
        float angle = MathF.Atan(a);

        nowObj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle*360);
        Vector2 position1 = transform.position;

        var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        var pos = Camera.main.WorldToScreenPoint (nowObj.transform.position);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        
        nowObj.transform.rotation = rotation;


        Vector2 position = transform.position;
        float speed_temp = speed * Time.deltaTime;
        Debug.Log(Time.deltaTime);


        if (Input.GetKey("left") || Input.GetKey((KeyCode.A)))
        {
            position.x -= speed_temp;

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
            position.x += speed_temp;
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
            position.y += speed_temp;
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
            position.y -= speed_temp;
            /*
            if(nowObj.name != "rifle_down")
            {
                nowObj.SetActive(false);

                nowObj = gameObject.transform.Find("rifle_down").gameObject;
                nowObj.SetActive(true);
            }
            */
        }

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        position.x = Mathf.Clamp(position.x, min.x+1.1f, max.x-1.1f);
        position.y = Mathf.Clamp(position.y, min.y+0.9f, max.y-0.9f);
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
     
            BulletController nowBullet = Instantiate(bullet, pos, nowObj.transform.rotation, deadParent);
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
        currentCharaState = CharaState.Dead;
        StopCoroutine("Shoot");
        nowObj.SetActive(false);
        GameObject downObj = transform.Find("hit2_down").gameObject;
        downObj.SetActive(true);
        audioSource.PlayOneShot(deadAudio);
        yield return new WaitForSeconds(3);
        downObj.SetActive(false);
        ScoreManager.instance.PlayerDeath();

    }
}
