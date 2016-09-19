using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {

    public int timer = 24;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(timer >= 0)
        {
            timer--;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
