using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public int enemiesPerSpawner;
    public int currentRound;
    private int totalEnemiesPerRound;


    private bool isRoundOver = true;

    public List<Spawner> spawners = new List<Spawner>();



    //---------------------Testing Only--------------------------
    private void Start()
    {
        Debug.Log("Press the G key to start first round");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartRound();
        }
    }
    //-----------------------------------------------------------




     public void StartRound()
    {
        if (isRoundOver)
        {
            Debug.Log("----Round Number: " + currentRound.ToString() + " Has Started----");

            enemiesPerSpawner = enemiesPerSpawner * currentRound;//increases the number of enemies per spawner each round
            totalEnemiesPerRound = enemiesPerSpawner * spawners.Count;

            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].Spawn(enemiesPerSpawner);
            }

            isRoundOver = false;
        }
    }

    public void RemoveEnemy()
    {
        totalEnemiesPerRound -= 1;
        CheckCound();
    }

    private void CheckCound()
    {
        if(totalEnemiesPerRound == 0)
        {
            isRoundOver = true;
            currentRound += 1;

            Debug.Log("--Round is over--");
        }
    }


}
