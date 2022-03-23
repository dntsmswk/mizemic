using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [Range(0.0f, 5.0f)]
    public float maxDistance;

    SpriteRenderer spriteRenderer;
    Animator animator;
    int animCount;
    public float h;
    public float v;


    void Start()
    {
        animCount = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (h < 0)
        {
            spriteRenderer.flipX = false;
        }
        if(h > 0)
        {
            spriteRenderer.flipX = true;
        }

        // 움직였느냐 안 움직였느냐의 따른 애니메이션 전
        if(h == 0 && v == 0)
        {
            animCount = 0;
            animator.SetInteger("Anim", animCount);
        }
        else if(!(h==0) || !(v == 0))
        {
            animCount = 1;
            animator.SetInteger("Anim", animCount);
        }
    }

    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        var vec = transform.position;

        vec += new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime;

        // 이동을 위한 값을 갖고 있는 변수의 x,y값의 최대 최소를 준 것 즉 이동 제한
        // 이해가 안되기는 한데 처음 위치 기준으로 최대최소를 정해준듯
        vec.x = Clamp(vec.x, -maxDistance, maxDistance);
        vec.y = Clamp(vec.y, -maxDistance, maxDistance);

        transform.position = vec;
    }
}
