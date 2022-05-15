using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamegeDie : MonoBehaviour
{
    public int hp;
    Vector2 startPosition;

    private void Awake()
    {
        // 왜 +1 해주냐면 시작할 때 벽 지나오는 바람에 몹들이 채력이 깍이고 시작해서
        hp += 1;
    }
    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "WALL" || collision.transform.tag == "BLOCK")
        {
            hp -= 1;
            print("hp -1");
            if (hp <= 0)
            {
                CoinManager.coins += 100;

                //죽으면 생성 위치로 돌아간 뒤 비활성화됨
                transform.position = startPosition;
                Invoke("Reset", 3f);
                gameObject.SetActive(false);
            } 
        }
    }
    private void Reset()
    {
        hp = 3;
        Debug.Log("부활!");
        gameObject.SetActive(true);
    }
}
