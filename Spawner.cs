using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private int totalToSpawn;
    public GameObject enemyPrefab;
    public RoundManager roundManager;


    public void Spawn(int _totalToSpawn)
    {
        totalToSpawn = _totalToSpawn;
        InvokeRepeating("DoSpawn", 0.5f, 1.5f);
    }

    private void DoSpawn()
    {
        GameObject go = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        go.GetComponent<EnemyAI>().Init(roundManager);
        totalToSpawn -= 1;
        CheckCount();

        //you could remove the CheckCount() above and add in 

        //if (totalToSpawn == 0)
        //{
        //    CancelInvoke();
        //}

        //then remove CheckCount() and StopSpawn() below
        //it will work either way

    }

    private void CheckCount()
    {
        if(totalToSpawn == 0)
        {
            StopSpawn();
        }
    }


    private void StopSpawn()
    {
        CancelInvoke();
    }

}
