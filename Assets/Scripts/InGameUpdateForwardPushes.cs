using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateForwardPushes : MonoBehaviour {
	void Update () {
		this.GetComponent<Text> ().text = " Forward Pushes: " + playerStats.currentForwardPushes;
	}
}
