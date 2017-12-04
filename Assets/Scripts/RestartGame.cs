using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class playerStats{
	//static vars that persist between each play through of the game, these are used in order to keep track of the proper values to use across the game scripts as well as to keep track of the upgrades the players have bought.
	public static int currentForwardPushLevel = 1;
	public static int currentUpwardPushLevel = 1;
	public static int currentForwardPushes = 3;
	public static int currentUpwardPushes = 3;
	public static float currentForwardPushForce = 5.0f;
	public static float currentUpwardPushForce = 5.0f;
	public static int playerMoney = 0;
	public static int moneyMultiplier = 1;
	public static int lives = 1;
	public static int currentPlayerLives;
	public static Vector3 playerSize = new Vector3(0.83f, 0.83f, 1.0f);
	public static float initialForce = 5.0f;
};

public class RestartGame : MonoBehaviour {
	public GameObject playerToSave;
	public Button playButton;

	private static GameObject objectInstance;
	void Awake(){
		playerStats.currentPlayerLives = playerStats.lives; //lives the rock will have for this play through
		playerStats.currentForwardPushes = 3; //initial forward pushes
		playerStats.currentUpwardPushes = 3; //initial upward pushes
		playerStats.currentForwardPushes *= playerStats.currentForwardPushLevel; //currentForwardPushes - 3 * the currentForwardPushLevel(upgrades the player has bought essentially)
		playerStats.currentUpwardPushes *= playerStats.currentUpwardPushLevel;
		DontDestroyOnLoad (this); //keep the gameRestarter object between scenes that way we can keep track of values throughout the game
		if (objectInstance == null) { //track if this is the first object
			objectInstance = gameObject;

		}
	}

	public void Restart(){
		//called by the game to restart in order to do another run
		SceneManager.LoadScene ("Main");
		DestroyObject (gameObject);
	}
}


