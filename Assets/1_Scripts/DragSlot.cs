using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    public GameObject blocks;
    Image SlotColor;

    private void Awake()
    {
        SlotColor = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Instantiate(blocks, transform.position, transform.rotation); //  374.51/418.07
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            SlotColor.color = Color.yellow;
            Color color = SlotColor.color;
            color.a = 0.4f;
            SlotColor.color = color;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            SlotColor.color = Color.white;
            Color color = SlotColor.color;
            color.a = 0.4f;
            SlotColor.color = color;
        
    }
}
