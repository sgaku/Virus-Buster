using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocater : MonoBehaviour
{
    public CharaManager charaManager;
    public static ServiceLocater i;

    void Awake()
    {
        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
