using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoScript : MonoBehaviour {
	public MovieTexture logoIntro;
	RawImage rawImage;
	AudioSource audioSource;
	// Use this for initialization
	void Start(){
		rawImage = GetComponent<RawImage>();
		audioSource = GetComponent<AudioSource>();
		PlayClip();
	}

	void Update(){
		if (!logoIntro.isPlaying){
			SceneManager.LoadScene("Menu Screen");
		}
	}

	void PlayClip(){
		rawImage.texture = logoIntro;
		logoIntro.Play();
		audioSource.clip = logoIntro.audioClip;
		audioSource.Play();
	}
}
