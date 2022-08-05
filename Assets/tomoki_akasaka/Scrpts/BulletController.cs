using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.5f; //銃弾のスピード
    //public Vector3 shotForward;
    public string rotation;
    public int moveOption;
    public float rad;

    Vector2 min;
    Vector2 max;


    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (position.x < min.x || max.x < position.x || position.y < min.y || max.y < position.y)
        {
            transform.gameObject.SetActive(false);
        }
    }
    public void Shoot(Vector3 shotForward)
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

