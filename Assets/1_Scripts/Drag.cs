using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Vector3 startPoint;

    public directionState direcState;

    
    public float dState;

    public enum directionState
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
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
        }
           
        if (direcState == directionState.UP)
        {
            dState = 2;
            print(dState);
        }
        if (direcState == directionState.RIGHT)
        {
            dState = 3;
            print(dState);
        }
        if (direcState == directionState.LEFT)
        {
            dState = 4;
            print(dState);
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPoint;
    }
  

    public void OnDrop(PointerEventData eventData)
    {
    }
    void Start()
    {
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
