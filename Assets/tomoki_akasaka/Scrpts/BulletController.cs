using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.5f; //銃弾のスピード
    public Vector3 shotForward;
    public string rotation;
    public int moveOption;
    public float rad;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }
    public void Shoot()
    {
        transform.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        //Move();
    }

    public void Move()
    {
        if(moveOption==1)
        {

        }
        Vector3 bulletPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
        if(rotation == "rifle_left")
        {
            bulletPos.x -= speed * Time.deltaTime; //x座標にspeedを加算
        }
        else if (rotation=="rifle_right")
        {
            bulletPos.x += speed * Time.deltaTime; //x座標にspeedを加算
        }
        else if (rotation == "rifle_up")
        {
            bulletPos.y += speed * Time.deltaTime; //x座標にspeedを加算
        }
        else if(rotation == "rifle_down")
        {
            bulletPos.y -= speed * Time.deltaTime; //x座標にspeedを加算
        }
        transform.position = bulletPos; //現在の位置情報に反映させる
    }
}

