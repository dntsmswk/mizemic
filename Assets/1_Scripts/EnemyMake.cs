using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMake : MonoBehaviour
{
    public GameObject enemy;

    public GameObject rangeObject;
    public GameObject parent;

    BoxCollider2D rangeCollider;

    float ranSpawnTime;

    public GameObject[] enemy2;

    static public int enemyTotalLength;
    public int enemyTotalLengthShow;
    public int enemyMaxLength;
    public int currentRound;

    public Text round;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);

        ranSpawnTime = Random.Range(10f, 15f);

        Vector3 RandomPostion = new Vector3(range_X,range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

   
    private void Start()
    {
        currentRound = 1;

        // enemy 처음 첫 개수 제한 15마리
        enemyMaxLength = 15;

        StartCoroutine(RandomRespawn_Coroutine());
    }

    private void Update()
    {
        enemyTotalLengthShow = enemyTotalLength;
        round.text = "ROUND : " + currentRound.ToString();
        enemy2 = GameObject.FindGameObjectsWithTag("Enemy");
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {

            //에너미 최대 갯수 보다 에너미 개수가 많으면 다음 라운드 진입
            if(enemyTotalLength >= enemyMaxLength)
            {
                // 라운드 증감
                currentRound += 1;
                //3초 기다렸다가 다음 루틴 시작두
                Invoke("PlusEnemyCount", 10f);
            }
            yield return new WaitForSeconds(ranSpawnTime);

            //에너 생성 개체수 조
            if(enemyTotalLength <= enemyMaxLength)
            {
                // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
                GameObject instantCapsul = Instantiate(enemy, Return_RandomPosition(), Quaternion.identity);
                instantCapsul.transform.parent = parent.transform;
            }
        }
    }
    void PlusEnemyCount()
    {
        enemyMaxLength += 5;
    }
}
