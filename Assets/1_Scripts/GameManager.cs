using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 2f;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1f;
        }

    }
}
