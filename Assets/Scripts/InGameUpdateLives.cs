using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateLives : MonoBehaviour {
	void Start(){
		this.GetComponent<Text> ().text = " Lifes: " + (playerStats.lives - 1);
	}
	void Update () {
		this.GetComponent<Text> ().text = " Lifes: " + playerStats.currentPlayerLives;
	}
}
