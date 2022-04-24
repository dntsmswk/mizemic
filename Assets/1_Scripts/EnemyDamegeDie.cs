using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamegeDie : MonoBehaviour
{
    public int hp;

    private void Awake()
    {
        // 왜 +1 해주냐면 시작할 때 벽 지나오는 바람에 몹들이 채력이 깍이고 시작해서
        hp += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "WALL" || collision.transform.tag == "BLOCK")
        {
            hp -= 1;
            print("hp -1");
            if (hp <= 0)
                gameObject.SetActive(false);
        }
    }
}
