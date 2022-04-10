using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Vector3 startPoint;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
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
