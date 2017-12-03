using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioClip BGmusic;
    private AudioSource source;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        source.PlayOneShot(BGmusic);
	}
}
