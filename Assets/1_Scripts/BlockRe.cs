using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRe : MonoBehaviour
{
    public DragSlot[] dragSlots;
    public BlockHp[] destroyBlockScript;
    public GameObject[] destroyBlocks;

    public bool[] t;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dragSlots.Length; i++)
        {
            dragSlots[i] = dragSlots[i].GetComponent<DragSlot>();
            t[i] = true;
        }

        for (int i = 0; i < dragSlots.Length; i++)
        { 

            if (dragSlots[i].onBlock == true)
            {
                if(t[i])
                {
                    destroyBlocks[i] = dragSlots[i].slotBox.GetChild(0).gameObject;
                    destroyBlockScript[i] = destroyBlocks[i].GetComponent<BlockHp>();
                    t[i] = false;
                }
            }
            // BlockHp스크립 값이 안들어왔다면 즉 빈 공간이면 continue
            if (!destroyBlockScript[i]) continue;
            print("블록 켜져있;");
            if (destroyBlockScript[i].die == true)
            {
                print("블록 파괴를 감지했!!!!!!!!!");
                dragSlots[i].onBlock = false;
                t[i] = true;
            }
        }
    }


}
    // 드래그 슬롯 스크립트 안에 있는 이 코드를 항상 실행되게 이렇게 게임매지저 위치에서 실행시키려한.

    //     //////////////////////////////////////////
    //    //블록이 설치되면
    //    if(onBlock == true)
    //    {
    //        //자식 블록이 파괴되면 블록이 설치안되있다고 표시
    //        destroyBlock = slotBox.GetChild(0).gameObject;
    //        destroyBlockScript = destroyBlock.GetComponent<BlockHp>();
    //        print("블록 켜져있");
    //        if (destroyBlockScript.die == true)
    //        {
    //            print("블록 파괴를 감지했!!!!1");
    //onBlock = false;
    //        }
    //    }