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


    //ウイルスの種類を格納
    [SerializeField] List<GameObject> virusList = new List<GameObject>();
    float currentTime = 0f;
    [Header("何秒ごとにウイルスを出すか")]
    [SerializeField] float createTime;
    //SetActive(false)にしたオブジェクトを整理するための親オブジェクト
    [SerializeField] Transform trashParent;
    bool isCreateVariant = false;
      [Header("2種類目のウイルス")]
    [SerializeField] GameObject variantVirus;
     [Header("ウイルスが連続で出てくる最低値")]
    [SerializeField] int minVirusCreateCount;
     [Header("ウイルスが連続で出てくる最大値")]
    [SerializeField] int maxVirusCreateCount;
    [Header("敵の種類を増やすスコア値")]
    [SerializeField] int addVirusScore;
    public Transform TrashParent
    {
        get { return trashParent; }
        set { trashParent = value; }
    }
    float createCount;
    Vector2 createPosition;
    Vector2 farMaxPosition;
    Vector2 farMinPosition;
    Vector2 diffVector;
    Vector2 minCameraPosition;
    Vector2 maxCameraPosition;
    int virusIndex;
    float[] addVector = { -10, 10 };

     [Header("ウイルスをプレイヤーから半径何メートル以内に生成するか")]
    [SerializeField] Vector2 farDistanceRange;

    // Start is called before the first frame update
    void Start()
    {
        //スタート時にウイルスを発生させるため
        currentTime = createTime;
        minCameraPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxCameraPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (ServiceLocator.i.charaManager.currentCharaState == CharaManager.CharaState.Dead) return;
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            createCount = Random.Range(minVirusCreateCount, maxVirusCreateCount);
            StartCoroutine(CreateVirus(createCount));
            currentTime = 0;
        }
        if(ServiceLocator.i.scoreManager.TotalScore > addVirusScore && !isCreateVariant){

virusList.Add(variantVirus);
isCreateVariant = true;
        }
    }
   
    IEnumerator CreateVirus(float count)
    {
        for (int i = 0; i < count; i++)
        {
            //TODO: 生成する位置のランダム化、キャラクターの周りを囲うように生成
            virusIndex = Random.Range(0, virusList.Count);
            Vector2 targetVector = targetPosition.position;
            farMaxPosition = targetVector + farDistanceRange;
            farMinPosition = targetVector - farDistanceRange;
            createPosition.y = Random.Range(farMinPosition.y, farMaxPosition.y);
            createPosition.x = Random.Range(farMinPosition.x, farMaxPosition.x);
            diffVector.x = targetVector.x - createPosition.x;
            diffVector.y = targetVector.y - createPosition.y;
            var x = Mathf.Abs(diffVector.x);
            var y = Mathf.Abs(diffVector.y);

            if (x < 5f)
            {
                var indexX = Random.Range(0, 1);
                createPosition.x += addVector[indexX];
            }
            else if (y < 5f)
            {
                var indexY = Random.Range(0, 1);
                createPosition.y += addVector[indexY];
            }

            if (createPosition.x > maxCameraPosition.x || createPosition.x < minCameraPosition.x) continue;
            if (createPosition.y > maxCameraPosition.y || createPosition.y < minCameraPosition.y) continue;
            Instantiate(virusList[virusIndex], createPosition, Quaternion.identity, transform);

            yield return null;
        }
    }
}
