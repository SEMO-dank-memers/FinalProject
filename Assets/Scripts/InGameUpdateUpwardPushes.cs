using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateUpwardPushes : MonoBehaviour {
	void Update () {
		this.GetComponent<Text> ().text = " Upward Pushes: " + playerStats.currentUpwardPushes;
	}
}
