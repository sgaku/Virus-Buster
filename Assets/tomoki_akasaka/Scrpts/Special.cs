using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Special : MonoBehaviour
{
    public GameObject chargeBullet;
    public bool skill1;
    public float chargeTime;
    AudioSource audioSource;

    public AudioClip chargeAudio;
    public AudioClip chargeShotAudio;


    // Start is called before the first frame update
    void Start()
    {
        skill1 = true;
        audioSource = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject nowObj;
    public void chargeShot(GameObject obj)
    {


        if(skill1 == false)
        {

        }
        else
        {
            nowObj = obj;
            StartCoroutine("chargeShot");
        }
    }

    
    public IEnumerator chargeShot()
    {
        Debug.Log("a");
        if(skill1 == false)
        {
            
        }
        else
        {
        Debug.Log("aa");
        Vector3 pos = nowObj.transform.Find("bulletPosition").gameObject.transform.position;
        GameObject bullet = Instantiate(chargeBullet, pos, nowObj.transform.rotation);
        audioSource.PlayOneShot(chargeAudio);
        bullet.transform.SetParent(nowObj.transform);
        skill1 = false;
        yield return new WaitForSeconds(chargeTime);

        var shotForward = (pos -nowObj.transform.Find("muzzleflash_rifle").gameObject.transform.position).normalized;
        bullet.GetComponent<BulletController>().Shoot(shotForward);
        audioSource.Stop();
        audioSource.PlayOneShot(chargeShotAudio);

        }

    }

    public void SetSkill1()
    {
        skill1 = true;
    }
}
