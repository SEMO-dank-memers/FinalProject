using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUpdater : MonoBehaviour {
	private const float duration = 10.0f;
	private Color day = new Color();
	private Color night = new Color();
	private bool isDay = true;
	private bool lerping = false;
	private float t = 0.0f;
	//end of copied vars

	public int distance = 10; // public so the distance the rock has gone can be used in other scripts
	int previousDistance = 0; //our rock starts at x=10 in the game so we will start there here
	public GameObject player;

	void Start()
	{
		setBackgroundColors();
	}


	void Update () {
		if (previousDistance < distance) {
			this.GetComponent<Text> ().text = " Distance: " + (distance - 10); // set the text to the achieved distance, subtract by 10 to account for the rock starting at x = 10 and not x = 0
			previousDistance = distance; //keep track of the last distance achieved so we stop updating when the rock rolls backwards
			playerStats.currentDistance = distance; 
		}
		distance = (int)player.transform.position.x;
		Debug.Log (distance, gameObject);
		if ((((distance-9) % 300) == 0) || (lerping == true)) {
			if (isDay) {
				lerpNight ();
			} else if(!isDay) {
				lerpDay ();
			}
		}
	}

	void lerpNight()
	{
		if (t < 1.0) {
			Camera.main.backgroundColor = Color.Lerp (day, night, t);
			t += Time.deltaTime / duration;
			lerping = true;
		} else {
			isDay = false;
			lerping = false;
			t = 0.0f;
		}
	}

	void lerpDay() 
	{
		if (t < 1.0) {
			Camera.main.backgroundColor = Color.Lerp (night, day, t);
			t += Time.deltaTime / duration;
			lerping = true;
		} else {
			isDay = true;
			lerping = false;
			t = 0.0f;
		}
	}

	void setBackgroundColors()
	{
		day.r = 0.51f;
		day.g = 0.70f;
		day.b = 0.73f;
		day.a = 0.0f;
		night.r = 0.1f;
		night.g = 0.1f;
		night.b = 0.1f;
		night.a = 0.0f;
	}
}