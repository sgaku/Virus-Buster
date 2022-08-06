using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(ActiveFalse), 2f);
    }

    void ActiveFalse()
    {
        gameObject.transform.parent = ServiceLocator.i.virusCreator.TrashParent;
        gameObject.SetActive(false);
    }
}
