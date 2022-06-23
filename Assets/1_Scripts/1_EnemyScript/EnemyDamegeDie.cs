using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamegeDie : MonoBehaviour
{
    public int hp;
    Vector2 startPosition;

    GameObject child;
    SpriteRenderer tagBlock;
    Color color;

    public bool die;

    private void Awake()
    {
        // 왜 +1 해주냐면 시작할 때 벽 지나오는 바람에 몹들이 채력이 깍이고 시작해서
        hp += 1;
    }
    private void Start()
    {
        startPosition = transform.position;
        die = false;
    }

    private void Update()
    {
        if (die)
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * 1f;
                tagBlock.color = color;
            }
            else //알파 값이 0보다 이하가 되면 비활성화딘
            {
                //죽으면 생성 위치로 돌아간 뒤 비활성화됨
                transform.position = startPosition;
                Invoke("Reset", 3f);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "WALL" || collision.transform.tag == "BLOCK")
        {
            hp -= 1;
            if (hp <= 0)
            {
                child = transform.GetChild(0).gameObject;
                tagBlock = child.GetComponent<SpriteRenderer>();
                color = tagBlock.color;

                die = true;

                CoinManager.coins += 10;
            } 
        }
    }
    private void Reset()
    {
        die = false;
        color.a = 1;
        hp = 3;
        Debug.Log("부활!");
        gameObject.SetActive(true);
    }
}
