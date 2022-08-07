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
        StartCoroutine("Cont");
    }

    
    public void SceneChangeQuit()
    {
        StartCoroutine("quit");
 
    }

    private IEnumerator quit()
    {
        audio.PlayOneShot(pi);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("StartMenu");
    }
    
    public void SceneChangeContinue()
    {
          StartCoroutine("Cont");
    }
    private IEnumerator Cont()
    {
        audio.PlayOneShot(pi);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Stage1");
    }
}
