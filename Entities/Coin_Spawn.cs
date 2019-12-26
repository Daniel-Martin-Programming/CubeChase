using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawn : MonoBehaviour {

    public GameObject coin; // REFERENCE TO THE COIN GAMEOBJECT, SET TO PUBLIC SO WE CAN DRAG AND DROP PREFAB INTO SCRIPT
    public int spawnTime; // USED TO SET THE SPAWN TIME FOR EACH COIN
    public int timer; // USED FOR THE TIMER IN GAME

	void Start ()
    {
        spawnTime = 500; // SETS THE SPAWN TIME TO 500
        timer = 0; // SETS THE TIMER TO 0
    }

    void Update ()
    {
        spawnCoin(spawnTime); // CALLS THE SPAWNCOIN METHOD WITH THE SPAWNTIME AS A PARAMETER
        timer++; // INCREASES THE TIMER BY 1 EVERY TICK
   	}

    private void spawnCoin(int spawnTime)
    {
        int randomX = Random.Range(-3, 4); // CREATES A NEW RANDOM NUMBER BETWEEN -3 AND 4
        int randomZ = Random.Range(-3, 4); // CREATES A NEW RANDOM NUMBER BETWEEN -3 AND 4

        if (timer == spawnTime) // IF TIMER IS EQUAL TO SPAWNTIME
        {
            Instantiate(coin.gameObject, new Vector3(randomX, 0.30f, randomZ), Quaternion.identity); // CREATE A NEW COIN AT THE RANDOM X POSITION, 0.30f Y AND THE RANDOM Z POSITION USING QUATERNION.IDENTITY TO IGNORE THE ROTATION
            timer = 0; // SETS TIMER BACK TO 0
        }
    }
}