using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUpdateLives : MonoBehaviour {
	void Start(){
		this.GetComponent<Text> ().text = " Lifes: " + (playerStats.lives - 1); // correct for the fact that we start with one live, we want the player to see 0 when they will not get a last wind
	}
	void Update () {
		this.GetComponent<Text> ().text = " Lifes: " + (playerStats.currentPlayerLives - 1); //use currentPlayerlives which is allowed to change throughout the game unlike lives which only changes on upgrade
	}
}
