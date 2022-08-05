using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusCreator : MonoBehaviour
{
    //ターゲットの位置
    [SerializeField] Transform targetPosition;
    public Transform TargetPosition
    {
        get { return targetPosition; }
        private set { targetPosition = value; }
    }
    //ウイルス生成の際の親オブジェクト
    [SerializeField] Transform virusParent;

    //ウイルスの種類を格納
    [SerializeField] List<GameObject> virusList = new List<GameObject>();
    float currentTime = 0f;
    [SerializeField] float createTime;
    float createCount;
    Vector2 createPosition;
    Vector2 farMaxPosition;
    Vector2 farMinPosition;
    Vector2 diffVector;
    float[] addVector = { -6, 6};
    //発生させる範囲の幅
    [SerializeField] Vector2 farDistanceRange;

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
            diffVector.x = targetVector.x - createPosition.x;
            diffVector.y = targetVector.y - createPosition.y;
            var x = Mathf.Abs(diffVector.x);
            var y = Mathf.Abs(diffVector.y);

            if (x < 3f)
            {
                var indexX = Random.Range(0, 1);
                createPosition.x += addVector[indexX];
            }
            else if (y < 3f)
            {
                var indexY = Random.Range(0, 1);
                createPosition.y += addVector[indexY];
            }

            Instantiate(virusList[index], createPosition, Quaternion.identity, virusParent);
            yield return null;
        }
    }
}
