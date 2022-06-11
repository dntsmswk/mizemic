using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_ChangeBlock : MonoBehaviour
{
    public float AlphaSpeed;
    SpriteRenderer tagBlock;
    Color color;

    float moveSpeedSave;


    EnemyMove enemyMove;

    Animator attackAnim;

    void Start()
    {
        attackAnim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMove>();
        AlphaSpeed = 1;
        attackAnim.SetBool("EnemyAttack", false);
        moveSpeedSave = enemyMove.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a > 0)
        {
            color.a -= Time.deltaTime * AlphaSpeed;
            tagBlock.color = color;
        }
        else // 블록이 완전히 투명해지면 공격 애니메이션 종료
        {
            attackAnim.SetBool("EnemyAttack", false);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "BLOCK")
        {
            enemyMove.moveSpeed = 0;
            StartCoroutine("waitTime");

            attackAnim.SetBool("EnemyAttack", true);

            tagBlock =  collision.GetComponent<SpriteRenderer>();
            color = tagBlock.color;
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(1f);
        enemyMove.moveSpeed = moveSpeedSave;
    }

}
