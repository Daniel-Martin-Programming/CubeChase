using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

    private float speed; // FLOAT USED FOR SETTING THE SPEED OF THE ENEMY AI
    private Game_Manager gm; // REFERENCE TO THE GAME MANAGER
    private Player_Manager plM; // REFERENCE TO THE PLAYER MANAGER
    private GameObject target; // USED TO SET THE TARGET FOR THR ENEMY

	private void Start ()
    {
        gm = GameObject.Find("Game_Manager").GetComponent<Game_Manager>(); // USED TIO FIND THE GAME MANAGER AND ACCESS THE GAMEMANAGER SCRIPT
        plM = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Manager>(); // USED TIO FIND THE PLAYER GAMEOBJECT AND ACCESS THE PLAYERMANAGER SCRIPT
        target = GameObject.FindGameObjectWithTag("Player"); // SETS THE TARGET TO THE GAMEOBJECT WITH THE TAG PLAYER
        speed = 3; // SETS THE SPEED OF THE ENEMY AI TO 3
	}
	
	private void Update ()
    {
        moveEnemy(); // CALLS THE MOVENEMEY METHOD EVERY TICK
	}

    private void moveEnemy()
    {
        this.transform.position += this.transform.forward * speed * Time.deltaTime; // TAKES THE CURRENT POSITION AND ADDS THE TRANSFORM.FORWARD SO THE ENEMY IS ALWAYS MOVING FORWARD AND MULTIPLY THAT BY SPEED AND TIME.DELTA TIME
        // WE DO THIS SO THE GAME WILL RUN AT THE SAME SPEED NO MATTER WHAT THE SPECS OF THE COMPUTER ARE

        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position); // SETS THE TARGET ROTATION TO THE CURRENT POSITION OF THE TARGET - THE ENEMYS CURRENT POSITON
        float rotationSpeed = Mathf.Min(10 * Time.deltaTime, 5); // SETS THE ROTATION SPEED USING MATHF.MIN (CALCUALATES THE 2 VALUES AND RETURNS THE LOWER OF THE 2)
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed); // SETS THE ENEMYS ROTATION TO THE CURRENT ROTATION - TARGETROTATION * ROTATIONSPEED
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Player") // IF THE ENEMY COLLIDES WITH A GAMEOBJECT WITH THE NAME PLAYER
        {
            plM.takeDamage(10); // CALLS THE TAKEDAMAGE METHOD IN THE PLAYER MANAGER AND SETS THE DAMAGE VAL TO 10
            gm.updateHud(); // CALLS THE GAMEMANAGER'S UPDATEHUD METHOD
            gm.resetGame(); // CALLS THE GAMEMANAGER'S RESETGAME METHOD
        }
    }
}