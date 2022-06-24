using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageHp : MonoBehaviour
{
    EnemyMove enemyMove;
    public int hp;

    float rotateSpeed = 15;
    float transHorizon = 1;
    float angle = 12;
    bool shake;
    int shakeCount;

    HpBarGarbage HpBarGarbage;
    GameObject hpBarGarbageObj;

    private void Start()
    {
        hp = Random.Range(5, 21);
        shake = false;
        shakeCount = 0;

        hpBarGarbageObj = transform.GetChild(0).gameObject;
        HpBarGarbage = hpBarGarbageObj.GetComponent<HpBarGarbage>();
    }

    private void Update()
    {
        if(shake)
        {
            gameObject.transform.parent.rotation = Quaternion.Lerp(gameObject.transform.parent.rotation,
            Quaternion.Euler(0, 0, angle * transHorizon), rotateSpeed * Time.deltaTime);

            if (transform.rotation == Quaternion.Euler(0, 0, angle))
            {
                transHorizon = -1;


                shakeCount += 1;
            }
            if (transform.rotation == Quaternion.Euler(0, 0, -angle))
            {
                transHorizon = 1;

                shakeCount += 1;
            }
            if (shakeCount == 3) // 한번 루프르 돌고나면 회전 멈추며 초기
            {
                shakeCount = 0;
                gameObject.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
               shake = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            enemyMove = collision.GetComponent<EnemyMove>();
            
            if (enemyMove.Damaged == true)
            {
                CoinManager.coins += 10;

                shake = true;

                HpBarGarbage.hit();
                hp -= 1;
                if (hp <= 0)
                {
                    CoinManager.coins += 100;
                    Destroy(gameObject);
                }
            }
        }
    }
}
