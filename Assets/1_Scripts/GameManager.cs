using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text round;
    EnemyMake enemyMake;
    public GameObject enemyMakeLine;

    void Start()
    {
        enemyMake = enemyMakeLine.GetComponent<EnemyMake>();
    }

    // Update is called once per frame
    void Update()
    {
        round.text = "ROUND : " + enemyMake.currentRound.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 4f;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale = 1f;
        }

    }
}
