using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslocateBlock : MonoBehaviour
{
    EnemyMove enemyMove;

    public enum State
    {
        UP_b,
        DOWN_b,
        RIGHT_b,
        LEFT_b
    }
    public State state_b;

    void Start()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
            if (collision.tag == "Enemy")
            {
            Debug.Log("충돌");
                if (state_b == State.UP_b)
                {
                    enemyMove = collision.gameObject.GetComponent<EnemyMove>();
                    enemyMove.state = EnemyMove.State.UP;
                }
                if (state_b == State.DOWN_b)
                {
                    enemyMove = collision.gameObject.GetComponent<EnemyMove>();
                    enemyMove.state = EnemyMove.State.DOWN;
                }
                if (state_b == State.RIGHT_b)
                {
                    enemyMove = collision.gameObject.GetComponent<EnemyMove>();
                    enemyMove.state = EnemyMove.State.RIGHT;
                }
                if (state_b == State.LEFT_b)
                {
                    enemyMove = collision.gameObject.GetComponent<EnemyMove>();
                    enemyMove.state = EnemyMove.State.LEFT;
                }
            }
        
    }
}
