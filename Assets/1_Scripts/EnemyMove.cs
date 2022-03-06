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


    public enum State
    {
        MOVE,
        TURNOVER,
        DIE,
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
    public State state = State.MOVE;

    void Start()
    {
        isDie = false;

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
        if (!(state == State.TURNOVER))
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

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
            state = State.TURNOVER;
            Debug.Log("house맞.");
        }
    }
   
    void Update()
    {
        // 이야~~ 델리게이트 쓰는 코드가 깔 끔 하구먼 
        playerTr(GameObject.Find("player"));
        Enemy_TURNOVER();
    }
}
