using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHp : MonoBehaviour
{
    public float Hp;
    public bool die;
    public Transform parentSlot;
    public GameObject[] uiSlots;
    public DragSlot[] FdragSlot;
    public DragSlot dragSlot;

    GameObject hpBarObj;
    HpBar hpBar;

    private void Start()
    {
        die = false;

        // 기본 hp
        Hp = 15;

        parentSlot = transform.parent;
        uiSlots = GameObject.FindGameObjectsWithTag("UISLOT");

        hpBarObj = transform.GetChild(0).gameObject;
        hpBar = hpBarObj.GetComponent<HpBar>();
    }

    private void Update()
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            FdragSlot[i] = uiSlots[i].GetComponent<DragSlot>();

            if (parentSlot == FdragSlot[i].slotBox)
            {
                dragSlot = uiSlots[i].GetComponent<DragSlot>();
            }
        }

        if (Hp <= 0)
        {
            dragSlot.onBlock = false;

            die = true;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            hpBar.hit();
            Hp -= 1;
        }
    }
}
