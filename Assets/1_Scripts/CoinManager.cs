using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    static public float coins;
    public Text coin;

    public Text[] blockPrice;
    public float Up;
    public float Down;
    public float Left;
    public float Right;


    void Start()
    {
        coin = coin.GetComponent<Text>();

        for (int i = 0; i < blockPrice.Length; i++)
        {
            blockPrice[i] = blockPrice[i].GetComponent<Text>();
        }
        // 살때마다 가격 늘어나고 구매하면 골드소진하는건 DragSlot 에 만들어
        // 어 음 내가 설계할떄는 Down,up,right, left순으로 코드를 짰는데 배치하니 up,down,left,right가
        //예뻐서 그렇게 하닌까 다른 스크립트에서에 블록들과 배치가 달라서 복잡해지네
        Up = 100;
        Down = 100;
        Left = 100;
        Right = 100;
        
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = "Coin : " + coins.ToString();

        blockPrice[0].text = " : " + Up.ToString();
        blockPrice[1].text = " : " + Down.ToString();
        blockPrice[2].text = " : " + Left.ToString();
        blockPrice[3].text = " : " + Right.ToString();
    }
}
