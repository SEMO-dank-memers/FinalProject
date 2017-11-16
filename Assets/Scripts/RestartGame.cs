using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class playerStats{
	public static int currentForwardPushLevel = 1;
	public static int currentUpwardPushLevel = 1;
	public static int currentForwardPushes = 3;
	public static int currentUpwardPushes = 3;
	public static float currentForwardPushForce = 5.0f;
	public static float currentUpwardPushForce = 5.0f;
	public static int playerMoney = 0;
	public static Vector3 playerSize = new Vector3(0.83f, 0.83f, 1.0f);
};

public class RestartGame : MonoBehaviour {
	public GameObject playerToSave;
	public Button playButton;

	private static GameObject objectInstance;
	void Awake(){
		playerStats.currentForwardPushes = 3; //initial forward pushes
		playerStats.currentUpwardPushes = 3; //initial upward pushes
		playerStats.currentForwardPushes *= playerStats.currentForwardPushLevel;
		playerStats.currentUpwardPushes *= playerStats.currentUpwardPushLevel;
		DontDestroyOnLoad (this);
		if (objectInstance == null) {
			objectInstance = gameObject;

		}
	}

	public void Restart(){
		//oh god there is so many better ways to do this but the time isn't worth it.....
		//where is your god now encapsulation?? WHERE?
		SceneManager.LoadScene ("Main");
		DestroyObject (gameObject);
	}
}


