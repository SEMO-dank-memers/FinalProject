using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBehavior : MonoBehaviour {

    void OnCollisionEnter2D()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
