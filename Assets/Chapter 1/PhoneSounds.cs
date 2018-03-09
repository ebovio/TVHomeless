using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSounds : MonoBehaviour {
    public AudioClip phoneRings;
    private AudioSource source;

    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    public void playPhone()
    {
        source.Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
