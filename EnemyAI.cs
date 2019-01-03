using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    /// <summary>
    /// This is used for testing that the RoundManager will keep track of when the enemies died
    /// The only needed part of this script is the private RoundManager roundManager; and 
    ///   private void Death();
    /// </summary>


    private RoundManager roundManager;//need this in your enemy ai 
    private float timerValue = 1.5f;

    public void Init(RoundManager _roundmanager)
    {
        roundManager = _roundmanager;
    }

    private void Update()
    {
        timerValue -= Time.deltaTime;
        if (timerValue <= 0f)
        {
            Death();
        }
    }

    private void Death()
    {
        roundManager.RemoveEnemy();//call this before you destroy the gameobject
        Destroy(gameObject);
    }

}
