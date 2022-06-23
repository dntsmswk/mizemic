using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Make : MonoBehaviour
{
    public GameObject enemyLine1, enemyLine2, enemyLine3, enemyLine4;
    public GameObject[] blocks;
    public GameObject enemy;

    public float[] distan1;
    public float[] distan2;
    public float[] distan3;
    public float[] distan4;


    public GameObject[] rangeObject;
    BoxCollider2D rangeCollider1, rangeCollider2, rangeCollider3, rangeCollider4;

    private void Start()
    {
        //음 신기한게 배열로 받아오는건 start에서 안되네 변수를 이처럼 여러개 생성해줘야되는
        rangeCollider1 = rangeObject[0].GetComponent<BoxCollider2D>();
        rangeCollider2 = rangeObject[1].GetComponent<BoxCollider2D>();
        rangeCollider3 = rangeObject[2].GetComponent<BoxCollider2D>();
        rangeCollider4 = rangeObject[3].GetComponent<BoxCollider2D>();
        StartCoroutine("EnemyRoutine");
    }

    private void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("BLOCK");
        //if (distan1[0] >= distan2[0])
        //    if (distan1[0] >= distan3[0])
        //        if (distan1[0] >= distan4[0])
        //            print("1이 가장 큼");
        // else if (distan2[0] >= distan3[0])
        //            if (distan2[0] >= distan4[0])
        //                print("2가 가장;");
        // else if (distan3[0] > distan4[0])
        //                print("3이 가장 ;");
        // else print("4가 가장 큼");

    }


    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("Routine 실행중이?");

        // GameObject.FindGameObjectsWithTag("..."); // 태그로 대상을 찾음. 같은 태그를 가진 Objects를 배열의 형태로 반환.
        // 와 몇번째 배열 쓸 필요없이 그냥 배열로 반환해서 배열로 생성한 변수에 다이렉트로 넣을 수 있네 ㄷㄷ

        for (int i = 0; i < blocks.Length; i++)
        {
            //이 부분 distan은 float으로 되있는데 여기는 public으로 해서 그런가 미리 공간을 만들어줘야하ㄴ
            distan1[i] = Vector2.Distance(enemyLine1.transform.position, blocks[i].transform.position);
            distan2[i] = Vector2.Distance(enemyLine2.transform.position, blocks[i].transform.position);
            distan3[i] = Vector2.Distance(enemyLine3.transform.position, blocks[i].transform.position);
            distan4[i] = Vector2.Distance(enemyLine4.transform.position, blocks[i].transform.position);

            // 4개의 애너미라인과 설치 된 블록 사이의 거리를 구해서 가장 거리가 가까운 블록에서 생성 이 생성위치 랜덤으로 해도 될 듯
            if (distan1[i] < distan2[i])
            {
                if (distan1[i] < distan3[i])
                {
                    if (distan1[i] < distan4[i])
                    {
                        float ran = Random.Range(-13, 13);
                        Instantiate(enemy, enemyLine1.transform.position + new Vector3(ran,0,0), enemyLine1.transform.rotation);
                    }
                }
                else if (distan3[i] < distan4[i])
                {
                    float ran = Random.Range(-13, 13);
                    Instantiate(enemy, enemyLine3.transform.position + new Vector3(0, ran, 0), enemyLine2.transform.rotation);
                }
                else
                {
                    float ran = Random.Range(-13, 13);
                    Instantiate(enemy, enemyLine4.transform.position + new Vector3(0, ran, 0), enemyLine2.transform.rotation);
                }
            }
            else if (distan2[i] < distan3[i])
            {
                if (distan2[i] < distan4[i])
                {
                    float ran = Random.Range(-13, 13);
                    Instantiate(enemy, enemyLine2.transform.position + new Vector3(ran, 0, 0), enemyLine2.transform.rotation);
                }
                else
                {
                    float ran = Random.Range(-13, 13);
                    Instantiate(enemy, enemyLine4.transform.position + new Vector3(0, ran, 0), enemyLine2.transform.rotation);
                }
            }
            else if (distan3[i] < distan4[i])
            {//소환할떄 회전값은 그냥 아무거나 줌 enemyLine3로 주면 90도 꺽여있어서 ㅎ
                float ran = Random.Range(-13, 13);
                Instantiate(enemy, enemyLine3.transform.position + new Vector3(0, ran, 0), enemyLine2.transform.rotation);
            }
            else
            {
                float ran = Random.Range(-13, 13);
                Instantiate(enemy, enemyLine4.transform.position + new Vector3(0, ran, 0), enemyLine2.transform.rotation);
            }
        }
        //다시 루틴 돌EnemyRoutine
        StartCoroutine("EnemyRoutine");
    }
}
