using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour {

    private Game_Manager gm; // REFERENCE TO THE GAME MANAGER CLASS

	void Start ()
    {
        gm = GameObject.Find("Game_Manager").GetComponent<Game_Manager>(); // SETS GM TO THE GAMEMANAGER GAMEOBJECT AND ACCESSES THE GAMEMANAGER SCRIPT
	}

    public void onExitClick()
    {
        Application.Quit(); // EXITS THE APPLICATION WHEN THE BUTTON IS CLICKED
    }

    public void newGame()
    {
        gm.startGame(); // CALLS THE GAME MANAGERS START GAME METHOD
    }
}