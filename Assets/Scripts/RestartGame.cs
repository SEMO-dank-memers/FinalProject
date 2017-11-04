using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {
	public GameObject playerToSave;
	public Button playButton;
	public static int currentForwardPushLevel;
	public static int currentUpwardPushLevel;

	private static GameObject objectInstance;
	void Awake(){
		DontDestroyOnLoad (this);
		if (objectInstance == null) {
			objectInstance = gameObject;
		}
		else {
			//DestroyObject (gameObject);
			playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().upwardPushLevel = currentUpwardPushLevel;
			playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel = currentForwardPushLevel;
		}
	}

	public void Restart(){
		//oh god there is so many better ways to do this but the time isn't worth it.....
		//where is your god now encapsulation?? WHERE?
		currentForwardPushLevel = playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel;
		currentUpwardPushLevel = playerToSave.GetComponent<ZippyTerrain2DRollingBall> ().upwardPushLevel;
		SceneManager.LoadScene ("Main");
		DestroyObject (gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}


