using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_ChangeBlock : MonoBehaviour
{
    public float AlphaSpeed;
    SpriteRenderer tagBlock;
    Color color;

    void Start()
    {
        AlphaSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a > 0)
        {
            color.a -= Time.deltaTime * AlphaSpeed;
            tagBlock.color = color;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "BLOCK")
        {
            tagBlock =  collision.GetComponent<SpriteRenderer>();
            color = tagBlock.color;
        }
    }

}
