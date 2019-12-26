using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour {

    private int speed; // CREATES A NEW INT TO CONTROL HOW FAST THE PLAYER MOVES

    void Awake()
    {
        speed = 3; // SETS THE PLAYERS SPEED TO 3
    }

    void Update()
    {
        movePlayer(); // CALLS THE MOVEPLAYER METHOD EVERY TICK
    }

    private void movePlayer()
    {
        bool w = Input.GetKey(KeyCode.W); // SETS THE BOOL W TO THE W KEY
        bool s = Input.GetKey(KeyCode.S); // SETS THE BOOL S TO THE S KEY
        bool a = Input.GetKey(KeyCode.A); // SETS THE BOOL A TO THE A KEY
        bool d = Input.GetKey(KeyCode.D); // SETS THE BOOL D TO THE D KEY

        if (w) // IF THE PLAYER IS PRESSING W
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime); // SETS THE PLAYERS CURRENT POSITION TO A NEW VECTOR3 AND ONLY CHANGING THE Z VALUE TO THE CURRENT Z VALUE + SPEED SINCE WE ARE MOVING UP * Time.DeltaTime 
        }

        if (s) // IF THE PLAYER IS PRESSING S
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime); // SETS THE PLAYERS CURRENT POSITION TO A NEW VECTOR3 AND ONLY CHANGING THE Z VALUE TO THE CURRENT Z VALUE - SPEED SINCE WE ARE MOVING UP * Time.DeltaTime 
        }

        if (a) // IF THE PLAYER IS PRESSING A
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); // SETS THE PLAYERS CURRENT POSITION TO A NEW VECTOR3 AND ONLY CHANGING THE X VALUE TO THE CURRENT X VALUE - SPEED SINCE WE ARE MOVING UP * Time.DeltaTime 
        }

        if (d) // IF THE PLAYER IS PRESSING D
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z); // SETS THE PLAYERS CURRENT POSITION TO A NEW VECTOR3 AND ONLY CHANGING THE X VALUE TO THE CURRENT X VALUE + SPEED SINCE WE ARE MOVING UP * Time.DeltaTime 
        }
    }
}