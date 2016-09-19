using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour
{
    public AudioSource audiosource;

    public AudioClip otherClip;

    // Use this for initialization
    void Start()
    {

        audiosource = GetComponent<AudioSource>();

        audiosource.clip = otherClip;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {

        audiosource.Play();

        Debug.Log("this is working");


    }

}
