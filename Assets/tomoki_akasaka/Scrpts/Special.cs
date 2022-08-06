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

    public GameObject nowObj;
    public void chargeShot(GameObject obj)
    {
        Debug.Log("chargeShot");


        if(skill1 == false)
        {

        }
        else
        {
            skill1 = false;
            nowObj = obj;
            StartCoroutine("chargeShotCoroutine");
        }
    }

    
    public IEnumerator chargeShotCoroutine()
    {

        Debug.Log("a");

        Debug.Log("aa");
        Vector3 pos = nowObj.transform.Find("bulletPosition").gameObject.transform.position;
        GameObject bullet = Instantiate(chargeBullet, pos, nowObj.transform.rotation);
        audioSource.PlayOneShot(chargeAudio);
        bullet.transform.SetParent(nowObj.transform);
        ServiceLocator.i.charaManager.StopCoroutine("Shoot");
        ServiceLocator.i.charaManager.stopFlag = true;
        yield return new WaitForSeconds(chargeTime);

        var shotForward = (pos -nowObj.transform.Find("muzzleflash_rifle").gameObject.transform.position).normalized;
        bullet.GetComponent<BulletController>().Shoot(shotForward);
        audioSource.Stop();
        bullet.transform.parent = null;
        audioSource.PlayOneShot(chargeShotAudio);
        ServiceLocator.i.charaManager.StartCoroutine("Shoot");
        ServiceLocator.i.charaManager.stopFlag = false;

        

        

    }

    public void SetSkill1()
    {
        skill1 = true;
    }
}
