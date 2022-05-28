using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowImage : MonoBehaviour
{
    Quaternion followObj;
    float h;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        followObj = gameObject.transform.parent.transform.rotation;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        h = followObj.z;

        if (h < 0)
        {
            h += 360;
        }
       // if(h) 이제 여기서 몇도일떄 이미지가 어디를 보게하는지 찾으샘 휴 생각보다 빨리 찾은 느낌 
        gameObject.transform.rotation = followObj;
        if (h < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (h > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
