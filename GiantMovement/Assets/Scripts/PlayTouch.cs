using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void PlayClick()
    {
        print("CLICKED!");
        SceneManager.LoadScene("Staging");


    }
}
