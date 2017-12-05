using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdater : MonoBehaviour {
	int distance=10, previousDistance=0; //our rock starts at x=10 in the game so we will start there here
	public GameObject player;
	void Update () {
		if (previousDistance < distance) {
			this.GetComponent<Text> ().text = " Distance: " + (distance - 10); // set the text to the achieved distance, subtract by 10 to account for the rock starting at x = 10 and not x = 0
			previousDistance = distance; //keep track of the last distance achieved so we stop updating when the rock rolls backwards
		}
		distance = (int)player.transform.position.x;
	}
}
