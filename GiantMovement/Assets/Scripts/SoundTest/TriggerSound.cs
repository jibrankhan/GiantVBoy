﻿using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {

    public AudioSource audiosource;
    public AudioClip audioclip;
	
    // Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = audioclip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Boy")
        {
            audiosource.Play();
    

        }


    }
}
