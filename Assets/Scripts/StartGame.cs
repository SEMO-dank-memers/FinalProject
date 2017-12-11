using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
	public VideoPlayer vid;

	void Update () {
		if (!vid.isPlaying) {
			SceneManager.LoadScene ("Menu Screen");
		}
	}
}
