using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Vector3 startPoint;

    public directionState direcState;

    
    public float dState;

    public Image[] image;
    Color[] color;


    public enum directionState
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    void Start()
    {
        startPoint = transform.position;
       // for (int i = 0; i < 4; i++)
       // {
        //    image[i] = image[i].gameObject.GetComponent<Image>();
       //     color[i] = image[i].color;
        //}
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 현재 드래그 하고 있는 블록에 따라 상태가 바뀜 그걸 dState에 저
        if (direcState == directionState.DOWN)
        {
            dState = 1;
            print(dState);
            //// 선택중인 블록은 반투명하게 함
            //color[0].a = 0.5f;
            //image[0].color = color[0];
        }
           
        if (direcState == directionState.UP)
        {
            dState = 2;
            print(dState);
            //// 선택중인 블록은 반투명하게 함
            //color[1].a = 0.5f;
            //image[1].color = color[1];
        }
        if (direcState == directionState.RIGHT)
        {
            dState = 3;
            print(dState);
            //// 선택중인 블록은 반투명하게 함
            //color[2].a = 0.5f;
            //image[2].color = color[2];
        }
        if (direcState == directionState.LEFT)
        {
            dState = 4;
            print(dState);
            //// 선택중인 블록은 반투명하게 함
            //color[3].a = 0.5f;
            //image[3].color = color[3];
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    color[i].a = 1f;
        //    image[i].color = color[i];
        //}
        
        transform.position = startPoint;
    }
  

    public void OnDrop(PointerEventData eventData)
    {
    }
    
}
