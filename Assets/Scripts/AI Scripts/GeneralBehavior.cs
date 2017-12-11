using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBehavior : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		//do nothing
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Rock") {
			gameObject.SetActive(false);
		}
	}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
