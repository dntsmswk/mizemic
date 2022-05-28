using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowImage : MonoBehaviour
{
    public Quaternion followObj;
    public float zRot;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        followObj = gameObject.transform.parent.transform.rotation;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        if (90 <= zRot && zRot <= 270)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        gameObject.transform.rotation = followObj;

    }
}
