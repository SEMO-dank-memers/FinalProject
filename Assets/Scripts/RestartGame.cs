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
			//playerStats.currentForwardPushLevel = 1;
			//playerStats.currentUpwardPushLevel = 1;
		}
		else {
			//DestroyObject (gameObject);
			//playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().upwardPushLevel = playerStats.currentUpwardPushLevel;
			//playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel = playerStats.currentForwardPushLevel;
		}
	}

	public void Restart(){
		//oh god there is so many better ways to do this but the time isn't worth it.....
		//where is your god now encapsulation?? WHERE?
		//playerStats.currentForwardPushLevel = playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel;
		//playerStats.currentUpwardPushLevel = playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().upwardPushLevel;
		SceneManager.LoadScene ("Main");
		DestroyObject (gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}


