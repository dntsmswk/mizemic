using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    delegate void PlayerTR(GameObject ptr);
    PlayerTR playerTr;

    RaycastHit2D layHit;

    [SerializeField]
    public float moveSpeed;
    bool isDie;
    bool turnOver;

    Vector3 reflectVec;
    Vector3 fPos;
    Vector2 inVec;

    float rr, gg, bb;
    bool t;

    public bool Damaged;
    Color color;
    GameObject spriteOBJ;
    SpriteRenderer spriteRenderer;

    CircleCollider2D circleCollider;

    EnemyDamegeDie enemyDamegeDie;

    public enum State
    {
        MOVE,
        DIE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
        BOUNCE,
        REFLECT
    }
    public State state = State.MOVE;

    private void Awake()
    {
        circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;

        enemyDamegeDie = this.gameObject.GetComponent<EnemyDamegeDie>();
        //Invoke("TriggerOff", 1.2f);
    }
    void TriggerOff()
    {
        //circleCollider.isTrigger = false;
    }
    void Start()
    {
        //에너미 생성되면 현재 에너미 수를 늘림
        EnemyMake.enemyTotalLength += 1;

        isDie = false;
        turnOver = false;

        state = State.MOVE;
        //델리게이로 만든 변수 안에 함수 넣어
        playerTr = Enemy_MOVE;

        rr = 255f / 255f;
        gg = 110f / 255f;
        bb = 97f / 255;
        t = true;
        Damaged = false;
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
        if(!(state == State.UP || state == State.DOWN ||                               // 몬스터가 죽으면 이동정지
           state == State.RIGHT || state == State.LEFT || state == State.BOUNCE) && !(enemyDamegeDie.die))
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
        if(state == State.UP && !(enemyDamegeDie.die))
        {
            turnOver = true;
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime,Space.World);
            Vector3 rota = new Vector3(0, 0, -90);
            transform.rotation = Quaternion.Euler(rota);
        }
    }
    public void DOWN()
    {
        if (state == State.DOWN && !(enemyDamegeDie.die))
        {
            turnOver = true;
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rota = new Vector3(0, 0, -270);
            transform.rotation = Quaternion.Euler(rota);
        }
    }
    public void RIGHT()
    {
        if (state == State.RIGHT && !(enemyDamegeDie.die))
        {
            turnOver = true;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rota = new Vector3(0, 0, -180);
            transform.rotation = Quaternion.Euler(rota);
        }
    }
    public void LEFT()
    {
        if (state == State.LEFT && !(enemyDamegeDie.die))
        {
            turnOver = true;
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime, Space.World);
            Vector3 rota = new Vector3(0, 0, -360);
            transform.rotation = Quaternion.Euler(rota);
        
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "WALL")
        {
            //벽에 닿으면 다시 플레이어에게 이동되게함
            Debug.Log("벽에 닿음");
            turnOver = false;
            state = State.MOVE;
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

        // 색 깜빡이는 무한루
        if(t)
            gg += 0.45f * Time.deltaTime;
        if (!t)
            gg -= 0.5f * Time.deltaTime;

        if (gg >= 255f / 255f) t = false;
        if (gg <= 110f / 255f) t = true;


        if (state == State.DOWN || state == State.UP || state == State.LEFT || state == State.RIGHT)
        {
            Damaged = true;
            spriteOBJ = transform.GetChild(0).gameObject;
            spriteRenderer = spriteOBJ.GetComponent<SpriteRenderer>();
            color = new Color(rr, gg, gg);
            spriteRenderer.color = color;
        }
        else
        {
            Damaged = false;
            spriteOBJ = transform.GetChild(0).gameObject;
            spriteRenderer = spriteOBJ.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }

        //발사원점 ?
        fPos = transform.position;
    }
}
