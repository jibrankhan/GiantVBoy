﻿using UnityEngine;
using System.Collections;

public class ExtenderScript : MonoBehaviour {

    private Component[] components;
    public GameObject extender;
    public float k = 30f;
    public float cameraX = 0;
    public float cameraY = 0;
    public float cameraZ = 0;

    Vector3 origin;

    private Vector3 forward;

    // Use this for initialization
    void Start () {
        //GameObject rig = GameObject.Find("LMHeadMountedRig1");
        //origin = rig.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject rig = GameObject.Find(GlobalVariables.GREEK_GOD);
        origin = rig.transform.position;

        //extender.transform.position = new Vector3(originX, originY, originZ) + (gameObject.transform.position - new Vector3(originX, originY, originZ)) * k;

        //extender.transform.position = new Vector3(-38.4f, -13.4f, -115.7f) + (gameObject.transform.position - new Vector3(-38.4f, -13.4f, -115.7f)) * k;
        //extender.transform.position =  origin + (gameObject.transform.position - origin) * k;
        extender.transform.position = origin + (new Vector3(gameObject.transform.position.x + cameraX, gameObject.transform.position.y + cameraY, gameObject.transform.position.z + cameraZ) - origin) * k;
    }
}
