using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip otherClip;
    public AudioClip PoundClip;
    public AudioClip FlinchClip;
    // Use this for initialization
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = otherClip;
        audiosource.Play();

        Debug.Log("this is working");
    }
    public void PlayPound()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = PoundClip;
        audiosource.Play();
        print("This working");
    }
    public void PlayFlinch()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = FlinchClip;
        audiosource.Play();
    }
}
