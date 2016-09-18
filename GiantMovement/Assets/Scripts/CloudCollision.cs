using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudCollision : MonoBehaviour {

    public DungeonMaster dungeon;
    public GreekGod gg;
    public GameObject rain;

    public List<AudioClip> rainSounds;
    public List<AudioClip> rainGrab;
    public AudioSource audio;
    public AudioSource audio2;

    private bool beingPinched;
    bool isRaining;
    private ParticleSystem particleS;
    

    void Start()
    {
        particleS = GetComponentInChildren<ParticleSystem>();
        GameObject rig = GameObject.Find(GlobalVariables.GREEK_GOD);
        gg = rig.GetComponent<GreekGod>();
    }

    void OnTriggerStay(Collider collider)
    {
        if (BeingPinched(collider) && !isRaining)
        {
            //rain.transform.SetParent(transform);
            GameObject rain1 = (GameObject)Instantiate(rain, transform.localPosition, transform.localRotation, transform);
            rain1.transform.localPosition = Vector3.zero;
            isRaining = true;

            // Only play if not already playing
            if(!audio.clip && !audio2.isPlaying)
            {
                audio.clip = rainSounds[Random.Range(0, rainSounds.Capacity)];
                audio2.clip = rainGrab[Random.Range(0, rainGrab.Capacity)];
            }
            
            // Play rain sounds, only once      
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            if (!audio2.isPlaying)
            {
                audio2.Play();
            }

            particleS.Play();
            //Debug.Log(rain1.transform.position);
            //Debug.Log(rain1.transform.localPosition);
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    // Increase rain counter
    public void IncreaseRainCounter()
    {
        dungeon.IncreaseRainCounter();
    }

    public void DropletDestroyed()
    {
        isRaining = false;
    }

    void onTriggerExit(Collider collider)
    {
        if (collider.tag == GlobalVariables.PINCH_EXTENDER_LEFT || collider.tag == GlobalVariables.PINCH_EXTENDER_RIGHT)
        {
            isRaining = false;
            particleS.Stop();
        }
    }

    bool BeingPinched(Collider collider)
    {
        return collider.tag == GlobalVariables.PINCH_EXTENDER_RIGHT && gg.IsPinchingRight || collider.tag == GlobalVariables.PINCH_EXTENDER_LEFT && gg.IsPinchingLeft;
    }
}

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == GlobalVariables.PINCH_EXTENDER)
        {
            print("LEAVING CLOUD");
            beingPinched = false;
            stickObject = null;
        }
    }*/

