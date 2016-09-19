using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudCollision : MonoBehaviour {

    public DungeonMaster dungeon;
    public GreekGod gg;
    public GameObject rain;
    public GameObject rainEffect;

    public List<AudioClip> rainSounds;
    public List<AudioClip> rainGrab;
    public AudioSource audio;
    public AudioSource audio2;

    Collider extenderCollider;
    private bool beingPinched;
    bool rainCubeExists = false;
    

    void Start()
    {
        GameObject rig = GameObject.Find(GlobalVariables.GREEK_GOD);
        gg = rig.GetComponent<GreekGod>();

        // Setup audio clips
        audio.clip = rainSounds[Random.Range(0, rainSounds.Capacity)];
        audio2.clip = rainGrab[Random.Range(0, rainGrab.Capacity)];
    }

    void OnTriggerStay(Collider collider)
    {
        // While being pinched if a cube is not already made
        if (BeingPinched(collider) && !rainCubeExists)
        {
            GameObject rain1 = (GameObject)Instantiate(rain, transform.localPosition, transform.localRotation, transform);
            rain1.transform.localPosition = Vector3.zero;
            rainCubeExists = true;
        }

        // Keep playing raining whilst rain cube exists
        if (rainCubeExists)
        {
            // Play rain sounds, only once      
            if (!audio.isPlaying)
            {
                audio.Play();
            }

            rainEffect.SetActive(true);
            //particleS.Play();
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    // Increase rain counter
    public void IncreaseRainCounter()
    {
        dungeon.NotifyRiverComplete();
    }

    public void DropletDestroyed()
    {
        print("droplet DESTROYED!");
        rainCubeExists = false;
        //particleS.Stop();
        rainEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (BeingPinched(collider))
        {
            extenderCollider = collider;

            // Play grab sound
            if (!audio2.isPlaying)
            {
                audio2.Play();
                rainEffect.SetActive(true);
                //particleS.Play();
            }
        }
    }

    void onTriggerExit(Collider collider)
    {
        if (!BeingPinched(collider))
        {
            extenderCollider = null;
            rainEffect.SetActive(false);
            //particleS.Stop();
        }
    }

    bool BeingPinched(Collider collider)
    {
        return collider.tag == GlobalVariables.PINCH_EXTENDER_RIGHT && gg.IsPinchingRight || collider.tag == GlobalVariables.PINCH_EXTENDER_LEFT && gg.IsPinchingLeft;
    }

    void GenerateRainCube()
    {
        if(!rainCubeExists)
        {
            GameObject rain1 = (GameObject)Instantiate(rain, transform.localPosition, transform.localRotation, transform);
            rain1.transform.localPosition = Vector3.zero;
        }
    }
}

