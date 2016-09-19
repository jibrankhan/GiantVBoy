using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class NextTouch1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void NextClickOne()
    {

        SceneManager.LoadScene("StoryPage2");

    }
}
