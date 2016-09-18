using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    // Object properties
    private bool hasApple = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool HasApple
    {
        get
        {
            return hasApple;
        }
        set
        {
            this.hasApple = value;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // When deer hits tree, deer eats apple
        if(other.tag == "Deer")
        {
            print("HIT DEER!");
            hasApple = false;
        }
    }
}
