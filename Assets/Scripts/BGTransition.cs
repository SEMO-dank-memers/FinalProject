using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTransition : MonoBehaviour 
{
	private float timeLeft = 10.0f;
	private const float duration = 10.0f;
	private float t = 0.0f;
	private Color day = new Color();
	private Color night = new Color();
	private bool isDay = true;

	void Start()
	{
		setBackgroundColors();
	}
	
	//Update is used for a day night cycle
	void Update()
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			if (isDay) {
				if (t < 1.0) {
					Camera.main.backgroundColor = Color.Lerp (day, night, t);
					t += Time.deltaTime / duration;
				} else { //!t < 1.0
					isDay = false;
					t = 0.0f;
					timeLeft = 30.0f;
				}
			} else { //!isDay
				if (t < 1.0) {
					Camera.main.backgroundColor = Color.Lerp (night, day, t);
					t += Time.deltaTime / duration;
				} else {
					isDay = true;
					t = 0.0f;
					timeLeft = 25.0f;
				}
			}
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
