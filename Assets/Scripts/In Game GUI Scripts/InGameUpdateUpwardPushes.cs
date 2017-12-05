using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateUpwardPushes : MonoBehaviour {
	void Update () {
		this.GetComponent<Text> ().text = " Upward Pushes: " + playerStats.currentUpwardPushes; //update the in game ui to reflect the amount of upward pushes the player has
	}
}
