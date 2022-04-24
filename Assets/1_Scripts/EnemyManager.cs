using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] rangeObject;
    public BoxCollider2D[] rangeCollider;

    public GameObject parent;

    Vector3 originPosition;

    float randomTime;

    float range_X;
    float range_Y;

    private void Awake()
    {
        for (int i = 0; i < rangeObject.Length; i++)
        {
            rangeCollider[i] = rangeObject[i].GetComponent<BoxCollider2D>();
        }
        
    }


    void Start()
    {

        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomTime); //randomTime

            // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
            GameObject instantCapsul = Instantiate(enemy, Return_RandomPosition(), Quaternion.identity);

            //애너미들을 parent안으로 차일드화
            instantCapsul.transform.parent = parent.transform;
        }
    }

    Vector3 Return_RandomPosition()
    {
        for (int i = 0; i < rangeObject.Length; i++)
        {
            originPosition = rangeObject[i].transform.position;
        }

        // 콜라이더의 사이즈를 가져오는 bound.size 사용


        // 매번 랜덤한 블록에 크기를 가져와서 그 블록 기준으로 크기를 받아서 그 범위안에서 랜덤하게하게끔 
        int ranblock = Random.Range(0, rangeCollider.Length);
            range_X = rangeCollider[ranblock].bounds.size.x;
            range_Y = rangeCollider[ranblock].bounds.size.y;
        

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;

        randomTime = Random.Range(3, 11);
        return respawnPosition;
    }
}
