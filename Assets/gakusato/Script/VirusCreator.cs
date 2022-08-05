using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCreator : MonoBehaviour
{
    //ターゲットの位置
    [SerializeField] Transform targetPosition;
    //ウイルスの種類を格納
    [SerializeField] List<GameObject> virusList = new List<GameObject>();
    float currentTime = 0f;
    float createTime = 4f;
    float createCount;
    Vector2 createPosition;
    Vector2 farMaxPosition;
    Vector2 farMinPosition;
    Vector2 nearMaxPosition;
    Vector2 nearMinPosition;
    //発生させる範囲の幅
    [SerializeField] Vector2 farDistanceRange;
    [SerializeField] Vector2 nearDistanceRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            createCount = Random.Range(4, 10);
            StartCoroutine(CreateVirus(createCount));
            currentTime = 0;
        }
    }
    IEnumerator CreateVirus(float count)
    {
        for (int i = 0; i < count; i++)
        {
            //TODO: 生成する位置のランダム化、キャラクターの周りを囲うように生成
            var index = Random.Range(0, virusList.Count - 1);
            Vector2 targetVector = targetPosition.position;
            farMaxPosition = targetVector + farDistanceRange;
            farMinPosition = targetVector - farDistanceRange;
            createPosition.y = Random.Range(farMinPosition.y, farMaxPosition.y);
            createPosition.x = Random.Range(farMinPosition.x, farMaxPosition.x);

            nearMaxPosition = targetVector + nearDistanceRange;
            nearMinPosition = targetVector - nearDistanceRange;
            

            createPosition = targetVector;
            Instantiate(virusList[index], createPosition, Quaternion.identity);
            yield return null;
        }
    }
}
