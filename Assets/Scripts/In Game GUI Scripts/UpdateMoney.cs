using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text> ().text = "  Player Money: " + playerStats.playerMoney; // update the ui to reflect the amount of money we have
	}
}
