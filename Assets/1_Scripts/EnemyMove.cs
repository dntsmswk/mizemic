using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    delegate void PlayerTR(GameObject ptr);
    PlayerTR playerTr;

    RaycastHit2D layHit;

    [SerializeField]
    private float moveSpeed;
    bool isDie;
    bool turnOver;


    public enum State
    {
        MOVE,
        DIE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
        BOUNCE
    }
    public State state = State.MOVE;

    void Start()
    {
        isDie = false;
        turnOver = false;

        state = State.MOVE;
        //델리게이로 만든 변수 안에 함수 넣어
        playerTr = Enemy_MOVE;
    }

    public void Enemy_MOVE(GameObject playerTr)
    {
        Vector2 vec = new Vector2(transform.position.x - playerTr.transform.position.x,
                                  transform.position.y - playerTr.transform.position.y);
        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

        //state가 TURNOVER로 바뀌면 회전을 정지
        if (!(turnOver))
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //맞아! 블록의 의해 이동시킬려면 기존의 이동은 꺼야지!!!
        if(!(state == State.UP || state == State.DOWN ||
           state == State.RIGHT || state == State.LEFT || state == State.BOUNCE))
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
    public void Enemy_TURNOVER()
    {
        //ray를 시각적으로 표현
        Debug.DrawRay(transform.position, -transform.right * 5, Color.green);


        //광선이 내가 지정한 레이어의 닿았다면 턴을 종료
        if (Physics2D.Raycast(transform.position,
                           -transform.right,
                           1,
                           1 << 6))
        {
            turnOver = true;
            Debug.Log("house맞.");
        }
    }
    public void UP()
    {
        if(state == State.UP)
        {
            turnOver = true;
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime,Space.World);
        }
    }
    public void DOWN()
    {
        if (state == State.DOWN)
        {
            turnOver = true;
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime, Space.World);
        }
    }
    public void RIGHT()
    {
        if (state == State.RIGHT)
        {
            turnOver = true;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        }
    }
    public void LEFT()
    {
        if (state == State.LEFT)
        {
            turnOver = true;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            state = State.BOUNCE;
        }
    }
    void Update()
    {
        // 이야~~ 델리게이트 쓰는 코드가 깔 끔 하구먼 
        playerTr(GameObject.Find("player"));
        Enemy_TURNOVER();
        UP();
        DOWN();
        RIGHT();
        LEFT();
    }
}
