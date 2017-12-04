using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdater : MonoBehaviour {
	int distance=10, previousDistance=0;
	public GameObject player;
	void Update () {
		if (previousDistance < distance) {
			this.GetComponent<Text> ().text = " Distance: " + (distance - 10);
			previousDistance = distance;
		}
		distance = (int)player.transform.position.x;
	}
}
