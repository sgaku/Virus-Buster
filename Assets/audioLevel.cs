using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLevel : MonoBehaviour
{
    public AudioClip pi;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clickaudio()
    {
        audio.PlayOneShot(pi);
    }
}
