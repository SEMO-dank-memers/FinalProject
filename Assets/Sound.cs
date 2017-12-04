using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public AudioClip BGmusic;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
		source.PlayOneShot(BGmusic);
    }
}
