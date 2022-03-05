using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    delegate void playerTR(GameObject ptr);
    playerTR playerTr;

    
    [SerializeField]
    private float moveSpeed;
    bool isDie;


    public enum State
    {
        MOVE,
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
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
   
    void Update()
    {
        // 이야~~ 델리게이트 쓰는 코드가 깔 끔 하구먼 
            playerTr(GameObject.Find("player"));
    }
}
