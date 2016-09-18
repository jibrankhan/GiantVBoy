﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThunderCloud : MonoBehaviour {

    public GreekGod gg;
    private AudioSource audio;

    public List<AudioClip> thunderGrab;
    public List<AudioClip> thunderSounds;
    bool collided = false;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        GameObject rig = GameObject.Find(GlobalVariables.GREEK_GOD);
        gg = rig.GetComponent<GreekGod>();
    }
	
	// Update is called once per frame
	void Update () {

        // Only destroy cloud after sound is finished playing
	    if(collided && !audio.isPlaying)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if(BeingPinched(collider))
        {
            if (!audio.isPlaying)
            { 
                audio.clip = thunderGrab[Random.Range(0, thunderGrab.Capacity)];
                audio.Play();
            }
        }

        if(collider.tag == GlobalVariables.GIANT)
        {    
            if (!audio.isPlaying)
            {
                collided = true;
                audio.clip = thunderSounds[0];
                audio.Play();
            }
        }
    }

    bool BeingPinched(Collider collider)
    {
        return collider.tag == GlobalVariables.PINCH_EXTENDER_RIGHT && gg.IsPinchingRight || collider.tag == GlobalVariables.PINCH_EXTENDER_LEFT && gg.IsPinchingLeft;
    }
}
