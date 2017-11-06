using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class playerStats{
	public static int currentForwardPushLevel = 1;
	public static int currentUpwardPushLevel = 1;
	public static int playerMoney = 0;
};

public class RestartGame : MonoBehaviour {
	public GameObject playerToSave;
	public Button playButton;

	private static GameObject objectInstance;
	void Awake(){
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


