using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    public GameObject[] garbageLine;
    public Collider2D[] garbageCollider;
    public GameObject garbage;

    float ranSpawnTime;
    float ran;

    void Start()
    {
         ran = Random.Range(1, 5);
        StartCoroutine("ReStart");
    }

    IEnumerator ReStart()
    {
        ran = Random.Range(1, 5);

        yield return new WaitForSeconds(ranSpawnTime);

        if (ran == 1)
            Instantiate(garbage, Return_RandomPosition(), Quaternion.identity);
        if (ran == 2)
            Instantiate(garbage, Return_RandomPosition2(), Quaternion.identity);
        if (ran == 3)
            Instantiate(garbage, Return_RandomPosition3(), Quaternion.identity);
        if (ran == 4)
            Instantiate(garbage, Return_RandomPosition4(), Quaternion.identity);

        StartCoroutine("ReStart");
    }

    Vector3 Return_RandomPosition()
    {
        ran = 0;
            Vector3 originPosition = garbageLine[0].transform.position;
            // 콜라이더의 사이즈를 가져오는 bound.size 사용
            float range_X = garbageCollider[0].bounds.size.x;
            float range_Y = garbageCollider[0].bounds.size.y;

            range_X = Random.Range((range_X / 2) * -1, range_X / 2);
            range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);

            ranSpawnTime = Random.Range(15f, 25f);

            Vector3 RandomPostion = new Vector3(range_X, range_Y);

            Vector3 respawnPosition = originPosition + RandomPostion;
            return respawnPosition;
    }
    Vector3 Return_RandomPosition2()
    {
        ran = 0;
        Vector3 originPosition = garbageLine[1].transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = garbageCollider[1].bounds.size.x;
        float range_Y = garbageCollider[1].bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);

        ranSpawnTime = Random.Range(15f, 25f);

        Vector3 RandomPostion = new Vector3(range_X, range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    Vector3 Return_RandomPosition3()
    {
        ran = 0;
        Vector3 originPosition = garbageLine[2].transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = garbageCollider[2].bounds.size.x;
        float range_Y = garbageCollider[2].bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);

        ranSpawnTime = Random.Range(15f, 25f);

        Vector3 RandomPostion = new Vector3(range_X, range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    Vector3 Return_RandomPosition4()
    {
        ran = 0;
        Vector3 originPosition = garbageLine[3].transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = garbageCollider[3].bounds.size.x;
        float range_Y = garbageCollider[3].bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);

        ranSpawnTime = Random.Range(15f, 25f);

        Vector3 RandomPostion = new Vector3(range_X, range_Y);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
