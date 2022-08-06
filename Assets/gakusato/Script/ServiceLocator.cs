using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// グローバルにアクセスするためのサービスロケーターを追加
/// </summary>
public class ServiceLocator : MonoBehaviour
{
    public VirusCreator virusCreator;
    public CharaManager charaManager;
    public ScoreManager scoreManager;
    public static ServiceLocator i;

    void Awake()
    {
        i = this;
    }
}
