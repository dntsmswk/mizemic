using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] setBlocks_UI;
    public Image uiSetButton;
    public GameObject uiSetBTNback;

    int buttonCount;

    public enum State
    {
        HARD,
        NORMAL,
        EASY
    }
    public State level;

    void Start()
    {
        buttonCount = 0;

        for (int i = 0; i < setBlocks_UI.Length; i++)
        {
            setBlocks_UI[i].SetActive(false);
        }
        uiSetBTNback.SetActive(false);
    }

    public void OnSetBlock_UI()
    {
        for (int i = 0; i < setBlocks_UI.Length; i++)
        {
            if(buttonCount % 2 == 0)
            {
                setBlocks_UI[i].SetActive(true);

                if (level == State.HARD)
                    uiSetBTNback.SetActive(true);


                if(level == State.HARD)
                    StartCoroutine("CoolTime_UIon");

                Time.timeScale = 0.3f;
            }
            else
            {
                setBlocks_UI[i].SetActive(false);

                if (level == State.HARD)
                    uiSetBTNback.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        buttonCount += 1;
    }

    IEnumerator CoolTime_UIon()
    {
        float coolTime = 0;
        coolTime = 0; //여기서 이렇게 초기화해줬어야했는데 위에걸로 초기화된

        //1초 정도 기다렸다 꺼짐
        Invoke("waitCool", 3f);

        while (uiSetButton.fillAmount <= 1)
        {
            //기본 쿨타임 3초 정도 여기서 더하거나 뺴거나~
            //왜 3초냐면 기본이 위 while에 써있는대로 1초인데 현재시간이 0.3배이기 때문에 대략 3.33...초
            coolTime += Time.deltaTime;
            uiSetButton.fillAmount = coolTime / 3;
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator CoolTime_UIoff()
    {
        float coolTime = 0;
        coolTime = 0; //여기서 이렇게 초기화해줬어야했는데 위에걸로 초기화된

        uiSetBTNback.SetActive(true);


        //1초 정도 기다렸다 꺼짐
        Invoke("waitCool2", 10f);

        while (uiSetButton.fillAmount <= 1)
        {
            //기본 쿨타임 1초 정도 여기는 리얼타임/
            coolTime += Time.deltaTime;
            uiSetButton.fillAmount = coolTime/10;
            yield return new WaitForFixedUpdate();
        }
    }
    void waitCool()
    {
        for (int i = 0; i < setBlocks_UI.Length; i++)
            setBlocks_UI[i].SetActive(false);

        uiSetBTNback.SetActive(false);
        Time.timeScale = 1f;
        buttonCount += 1;
        StartCoroutine("CoolTime_UIoff");
    }
    void waitCool2()
    {
        for (int i = 0; i < setBlocks_UI.Length; i++)
            setBlocks_UI[i].SetActive(false);

        uiSetBTNback.SetActive(false);
        Time.timeScale = 1f;
    }
}
