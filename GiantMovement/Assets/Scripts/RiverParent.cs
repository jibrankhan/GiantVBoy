using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RiverParent : MonoBehaviour {

    public List<River> rivers;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        print("COLLISION WITH RIVER 1");

        // If Rain hits river
        if (col.tag == "Rain")
        {
            print("COLLISION WITH RIVER");
            StartCoroutine(TurnOnRiver());
        }
    }

    IEnumerator TurnOnRiver()
    {
        foreach (River r in rivers)
        {
            r.ActivateRiver(true);
        }

        yield return new WaitForSeconds(5);

        foreach (River r in rivers)
        {
            r.ActivateRiver(false);
        }
    }
}
