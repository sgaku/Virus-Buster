using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene("StartMenu");
    }
    
    public void SceneChangeContinue()
    {
        SceneManager.LoadScene("Stage1");
    }
}
