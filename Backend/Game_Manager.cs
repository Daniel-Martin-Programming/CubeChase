using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    private Text healthText; // REFERENCE TO THE HEALTH TEXT OBJECT USED TO DISPLAY THE PLAYERS HEALTH
    private Text coinText; // REFERENCE TO THE COIN TEXT OBJECT USED TO DISPLAY THE PLAYERS COINS

    private Vector3 respawnPointP; // CREATES A NEW VECTOR3 FOR STORING THE PLAYERS START POSITION
    private Vector3 respawnPointE; // CREATES A NEW VECTOR3 FOR STORING THE ENEMIES START POSITION
    private Player_Manager plM; // REFERENCE TO THE PLAYER MANAGER SCRIPT

    private GameObject player; // REFERENCE TO THE PLAYER GAMEOBJECT
    private GameObject enemy; // REFERENCE TO THE ENEMY GAMEOBJECT

    private GameObject endGameHud; // REFERENCE TO THE ENDGAMEHUD GAMEOBJECT

    private int coins; // CREATES A NEW INT TO STORE HOW MANY COINS THE PLAYER HAS

    private void Start()
    {
        player = GameObject.Find("Player"); // FINDS THE PLAYER IN THE CURRENT SCENE
        enemy = GameObject.Find("Enemy"); // FINDS THE ENEMIE IN THE CURRENT SCENE

        endGameHud = GameObject.Find("GameEndScreen"); // FINDS THE HUD GAMEOBJECT IN THE SCENE

        healthText = GameObject.Find("HealthText").GetComponent<Text>(); // FINDS THE HEALTH TEXT IN THE SCENE
        coinText = GameObject.Find("CoinText").GetComponent<Text>(); // FINDS THE COIN TEXT IN THE SCENE
        plM = GameObject.Find("Player").GetComponent<Player_Manager>(); // FINDS THE PLAYER IN THE SCENE AND ALLOWS US TO USE THE PLAYER MANAGER SCRIPT

        coins = 0; // SETS THE COINS TO 0 ON GAME START
        coinText.text = "Coins: 0"; // SETS THE COIN TEXT TO COINS:0

        respawnPointE = enemy.transform.position; // SETS THE RESPAWN POINT OF THE ENEMY TO THE ENEMIES CURRENT POSITION WHEN THE GAME STARTS
        respawnPointP = player.transform.position; // SETS THE RESPAWN POINT OF THE PLAYER TO THE PLAYERS CURRENT POSITION WHEN THE GAME STARTS

        startGame(); // CALLS THE START GAME METHOD
    }

    public void resetGame()
    {
        enemy.transform.position = respawnPointE; // SETS THE RESPAWN POINT OF THE ENEMY TO THE ENEMIES STORED POSITION WHEN THE GAME IS RESET
        player.transform.position = respawnPointP; // SETS THE RESPAWN POINT OF THE PLAYER TO THE PLAYER STORED POSITION WHEN THE GAME IS RESET
    }

    public void endGame()
    {
        Time.timeScale = 0; // SINCE THE GAME RELIES ON TIME.timescale FOR THE GAME TO RUN, SETTING THIS TO 0 WILL PAUSE THE GAME
        endGameHud.SetActive(true); // SETS THE ENDGAME HUD TO ACTIVE
    }

    public void startGame()
    {
        Time.timeScale = 1; // SETS THE TIME.TIMESCALE TO 1

        if (endGameHud.activeSelf == true) // WE USE THIS TO CHECK IF THE ENDGAMEHUD IS ACTIVE WHEN THE GAME STARTS IF SO
        {
            endGameHud.SetActive(false); // SETS THE ENDGAMEHUS TO INACTIVE
        }

        plM.setHealth(50); // SETS THE PLAYERS HEALTH TO 50
        updateHud(); // CALLS THE UPDATEHUD METHOD
        coins = 0; // RESETS THE COINS COUNTER
    }

    public void addCoin()
    {
        coins += 1; // THIS WILL ADD ONE TO THE CURRENT COIN COUNTER WHEN THIS METHOD IS CALLED
        coinText.text = "Coins: " + coins; // SETS THE COIN TEXT TO WHAT THE PLAYERS CURRENT COINS
    }

    public void updateHud()
    {
        healthText.text = "Health: " + plM.getHealth(); // THIS METHOD ALWAYS ENSURES THE PLAYER TEXT IS UP TO DATE
    }
}