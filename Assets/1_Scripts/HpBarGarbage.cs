using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarGarbage : MonoBehaviour
{
    GameObject garbageHpObj;
    GarbageHp garbageHp;
    Vector3 vec;
    float startHp;
    bool t;

    void Start()
    {
        t = true;
        garbageHpObj = transform.parent.gameObject;
        garbageHp = garbageHpObj.GetComponent<GarbageHp>();
    }

    public void hit()
    {
        if (t) //한번만 실행되게 만듬 
        {
            startHp = garbageHp.hp + 1; // 몬스터에게 맞을때마다 초기값에 초기화해주면 초기값이 계속 바뀌니 한번만 실행되게하여 초기값은 바뀌지않게함 +1은 몬스터한테 이미 한대 맞았으-
            t = false;
        }

        vec.x = 1 / startHp;
        this.transform.GetChild(1).localScale -= vec; // 15분에 1만큼을 뻄 
    }
}
