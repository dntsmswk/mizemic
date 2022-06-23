using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    public GameObject[] blocks;
    public Transform slotBox;
    Image SlotColor;
    public bool onBlock;

    public Drag[] drag;
    public GameObject[] dragObj;

    CoinManager coinManager;
    GameObject GcoinManager;

    public GameObject destroyBlock;
    public BlockHp destroyBlockScript;

    private void Awake()
    {
        SlotColor = GetComponent<Image>();
        onBlock = false;
        //drag[0] = blocks[0].GetComponent<Drag>();
        //drag[1] = blocks[1].GetComponent<Drag>();
        //drag[2] = blocks[2].GetComponent<Drag>();
        //drag[3] = blocks[3].GetComponent<Drag>();
    }
    private void Start()
    {
        GcoinManager = GameObject.Find("GameManager");
        coinManager = GcoinManager.GetComponent<CoinManager>();

        dragObj[0] = GameObject.Find("Down"); //Down은 drag스크립트 가지도있는거 아무거나 가져와봄
        dragObj[1] = GameObject.Find("Up");
        dragObj[2] = GameObject.Find("Right");
        dragObj[3] = GameObject.Find("Left");
        drag[0] = dragObj[0].GetComponent<Drag>();
        drag[1] = dragObj[1].GetComponent<Drag>();
        drag[2] = dragObj[2].GetComponent<Drag>();
        drag[3] = dragObj[3].GetComponent<Drag>();
    }

    private void Update()
    {
        //////////////////////////////////////////   여기 주석처리된 코드는 BlockRe스크립트에서 구현되었.
        //블록이 설치되면
        //if(onBlock == true)
        //{
        //    //자식 블록이 파괴되면 블록이 설치안되있다고 표시
        //        destroyBlock = slotBox.GetChild(0).gameObject;
        //        destroyBlockScript = destroyBlock.GetComponent<BlockHp>();
            
           
        //    print("블록 켜져있");
        //    if (destroyBlockScript.die == true)
        //    {
        //        print("블록 파괴를 감지했!!!!1");
        //        onBlock = false;
        //    }
        //}
      

        //만약 블록이 설치 안되있으면 블록슬롯의 색깔을 흰색으로 이렇게 update문에 쓰는 이유는 블록이 파괴되면 이쪽으로 정보를 넘겨서 onBlcok을 flase로 만들거라
        if (onBlock == false)
        {
            SlotColor.color = Color.white;
            Color color = SlotColor.color;
            color.a = 0.4f;
            SlotColor.color = color;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if(!(onBlock))
            {
                //음 스테틱으로 만들어서 현재 만진블록 상태의 따라서 다른값을 주려고 했는데 왜 안되냐
                if (drag[0].dState == 1)
                {
                    SlotColor.color = Color.yellow;
                    Color color = SlotColor.color;
                    color.a = 0.4f;
                    SlotColor.color = color;
                    onBlock = true;


                    CoinManager.coins -= coinManager.Down;
                    //구입할떄마다 가격 비싸짐
                    coinManager.Down += 25;

                    //slotBox가 부모 오브젝트로 블록은 그 밑에 생성되게함
                    GameObject instantCapsul = Instantiate(blocks[0], slotBox.position, transform.rotation);
                    instantCapsul.transform.parent = slotBox.transform;

                    drag[0].dState = 0;
                    drag[1].dState = 0;
                    drag[2].dState = 0;
                    drag[3].dState = 0;
                }

                if (drag[1].dState == 2)
                {
                    SlotColor.color = Color.yellow;
                    Color color = SlotColor.color;
                    color.a = 0.4f;
                    SlotColor.color = color;
                    onBlock = true;


                    CoinManager.coins -= coinManager.Up;
                    //구입할떄마다 가격 비싸짐
                    coinManager.Up += 25;

                    GameObject instantCapsul = Instantiate(blocks[1], slotBox.position, transform.rotation);
                    instantCapsul.transform.parent = slotBox.transform;

                    drag[0].dState = 0;
                    drag[1].dState = 0;
                    drag[2].dState = 0;
                    drag[3].dState = 0;
                }

                if (drag[2].dState == 3)
                {
                    SlotColor.color = Color.yellow;
                    Color color = SlotColor.color;
                    color.a = 0.4f;
                    SlotColor.color = color;
                    onBlock = true;


                    CoinManager.coins -= coinManager.Right;
                    //구입할떄마다 가격 비싸짐
                    coinManager.Right += 25;

                    GameObject instantCapsul = Instantiate(blocks[2], slotBox.position, transform.rotation);
                    instantCapsul.transform.parent = slotBox.transform;

                    drag[0].dState = 0;
                    drag[1].dState = 0;
                    drag[2].dState = 0;
                    drag[3].dState = 0;
                }

                if (drag[3].dState == 4)
                {
                    SlotColor.color = Color.yellow;
                    Color color = SlotColor.color;
                    color.a = 0.4f;
                    SlotColor.color = color;
                    onBlock = true;


                    CoinManager.coins -= coinManager.Left;
                    //구입할떄마다 가격 비싸짐
                    coinManager.Left += 25;

                    GameObject instantCapsul = Instantiate(blocks[3], slotBox.position, transform.rotation);
                    instantCapsul.transform.parent = slotBox.transform;

                    drag[0].dState = 0;
                    drag[1].dState = 0;
                    drag[2].dState = 0;
                    drag[3].dState = 0;
                }
                //Instantiate(blocks, transform.position, transform.rotation); //  374.51/418.07
            }
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
        if(!onBlock)
        {
            SlotColor.color = Color.white;
            Color color = SlotColor.color;
            color.a = 0.4f;
            SlotColor.color = color;
        }
    }
}
