using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateForwardPushes : MonoBehaviour {
	void Update () {
		this.GetComponent<Text> ().text = " Forward Pushes: " + playerStats.currentForwardPushes; //update the gui to reflect how many forward pushes we have left
	}
}
