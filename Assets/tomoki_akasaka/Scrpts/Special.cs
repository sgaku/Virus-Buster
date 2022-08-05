using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Special : MonoBehaviour
{
    public GameObject chargeBullet;
    public bool skill1;
    // Start is called before the first frame update
    void Start()
    {
        skill1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator chargeShot(GameObject obj)
    {
        if(skill1 == false)
        {
            
        }
        else
        {
        Vector3 pos = obj.transform.Find("bulletPosition").gameObject.transform.position;
        Instantiate(chargeBullet, pos, obj.transform.rotation).transform.SetParent(obj.transform);
        skill1 = false;
        }

    }

    public void SetSkill1()
    {
        skill1 = true;
    }
}
