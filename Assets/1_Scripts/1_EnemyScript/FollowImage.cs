using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowImage : MonoBehaviour
{
    public bool defaultFlipX;
    public Quaternion followObj;
    public float zRot;
    SpriteRenderer spriteRenderer;

    EnemyDamegeDie enemyDamegeDie;
    GameObject parent;

    private void Start()
    {
        followObj = gameObject.transform.parent.transform.rotation;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        parent = transform.parent.gameObject;
        enemyDamegeDie = parent.GetComponent<EnemyDamegeDie>();
    }

    void Update()
    {
        //오일러 앵글로 불러야 360도로 나옴 rotation은 0 ~ 1사이로 나옴
        zRot = gameObject.transform.parent.transform.eulerAngles.z;

        if (zRot < 0)
        {
            zRot += 360;
        }
        if (zRot > 360)
        {
            zRot -= 360;
        }
        // if(h) 이제 여기서 몇도일떄 이미지가 어디를 보게하는지 찾으샘 휴 생각보다 빨리 찾은 느낌

        if (enemyDamegeDie.die == false) // 몬스터가 안 죽었을 때만 이미지 좌우반전
        {
            if (90 <= zRot && zRot <= 270)
            {
                spriteRenderer.flipX = defaultFlipX;
            }
            else
            {
                spriteRenderer.flipX = !defaultFlipX;
            }
        }

        gameObject.transform.rotation = followObj;

    }
}
