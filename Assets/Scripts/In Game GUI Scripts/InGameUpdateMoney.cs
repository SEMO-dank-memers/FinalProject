using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateMoney : MonoBehaviour {
	void Update () {
		this.GetComponent<Text> ().text = " Money: " + playerStats.playerMoney; //constantly update the ui to reflect the amount of money the player has
	}
}