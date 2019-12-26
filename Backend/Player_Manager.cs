using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {

    private int health; // CREATES AN INT USED TO STORE THE PLAYERS HEALTH
    private Game_Manager gm; // CREATES A REFERENCE TO THE GAME MANAGER

	void Start ()   
    {
        gm = GameObject.Find("Game_Manager").GetComponent<Game_Manager>(); // FINDS THE GAMEMANAGER GAMEOBJECT IN THE SCENE AND ALLOWS ACCESS TO THE GAMEMANAGER SCRIPT
        health = 50; // SETS THE PLAYERS HEALTH TO 50
	}

    public int takeDamage(int damageValue)
    {
        health -= damageValue; // TAKES WHATEVER WE SET THE DAMAGE VALUE TO FROM THE HEALTH
        checkHealth(); // CALLS THE CHECKHEALTH METHOD
        return health; // RETURNS THE HEALTH
    }

    private void checkHealth()
    {
        if (health <= 0) // IF THE HEALTH OF THE PLAYER IS LESS THAN OR EQUAL TO 0
        {
            gm.endGame(); // CALLS THE GAMEMANAGERS ENDGAME METHOD
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Coin")) // IF THE PLAYER COLLIDES WITH ANY GAMEOBJECT WITH THE TAG "COIN"
        {
            gm.addCoin(); // CALLS THE GAMEMANAGERS ADDCOIN METHOD
            Destroy(col.gameObject); // DESTROYS THE COIN GAMEOBJECT THE PLAYER COLLIDED WITH
        }
        else if (col.gameObject.tag.Equals("Death_Barrier")) // IF THE PLAYER COLLIDES WITH ANY GAMEOBJECT WITH THE TAG "COIN"
        {
            gm.resetGame(); // CALLS THE GAMEMANAGERS RESETGAME METHOD
            takeDamage(10); // CALLS THE TAKEDAMAGE METHOD TO -10 FROM THE PLAYERS CURRENT HEALTH
            gm.updateHud(); // CALLS THE GAMEMANAGERS UPDATEHUD METHOD
        }
    }

    public int getHealth()
    {
        return health; // RETURNS THE PLAYERS CURRENT HEALTH VALUE
    }

    public void setHealth(int newHealth)
    {
        health = newHealth; // SETS THE CURRENT HEALTH VALUE TO NEWHEALTH
    }
}