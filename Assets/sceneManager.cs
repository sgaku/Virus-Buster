using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
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

    public void SceneChange()
    {
        SceneManager.LoadScene("Stage1");
    }

    
    public void SceneChangeQuit()
    {
        audio.PlayOneShot(pi);
        SceneManager.LoadScene("StartMenu");
    }
    
    public void SceneChangeContinue()
    {
        audio.PlayOneShot(pi);
        SceneManager.LoadScene("Stage1");
    }
}
