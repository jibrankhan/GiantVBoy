﻿using UnityEngine;
using System.Collections;

public class PinchExtenderLeft : Extender
{
    // Use this for initialization
    void Start()
    {
        // Collect clouds
        thunderClouds = FindObjectsOfType<ThunderCloud>();
        rainClouds = FindObjectsOfType<CloudCollision>();
        ruins = FindObjectsOfType<Ruin>();
    }

    // Update is called once per frame
    void Update()
    {
        // If stick then transform else do distance checks and snap
        if (stick)
        {
            if (IsPinchingLeft() && stickObject != null)
            {
                print("MOVE CLOUD!");
                // Add lerp function
                stickObject.transform.position = transform.position;
                //TransformObject(stickObject.transform.position, transform.position);
            }
        }
        // Attach object
        else
        {
            foreach (ThunderCloud t in thunderClouds)
            {
                // If pinching in anyway, not cloud already set and distance under a position
                if (IsPinchingLeft() && stickObject == null)
                {
                    if (Vector3.Distance(transform.position, t.transform.position) < snapRange)
                    {
                        stickObject = t.gameObject;
                        stick = true;
                        //TransformObject(stickObject.transform.position, transform.position);
                        stickObject.transform.position = transform.position;
                    }
                }
            }
            foreach (CloudCollision c in rainClouds)
            {
                // If pinching in anyway, not cloud already set and distance under a position
                if (IsPinchingLeft() && stickObject == null)
                {
                    if (Vector3.Distance(transform.position, c.transform.position) < snapRange)
                    {
                        stickObject = c.gameObject;
                        stick = true;
                        //TransformObject(stickObject.transform.position, transform.position);
                        stickObject.transform.position = transform.position;
                    }
                }
            }
            foreach (Ruin r in ruins)
            {
                // If pinching in anyway, not cloud already set and distance under a position
                if (IsPinchingLeft() && stickObject == null)
                {
                    if (Vector3.Distance(transform.position, r.transform.position) < snapRange)
                    {
                        stickObject = r.gameObject;
                        stick = true;
                        //TransformObject(stickObject.transform.position, transform.position);
                        stickObject.transform.position = transform.position;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        if(stickObject != null)
        {
            Rigidbody r = stickObject.GetComponent<Rigidbody>();
            // Allow to pass through extenders
            print("COLLISION IGNORED " + r.tag);
            Physics.IgnoreCollision(r.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // If touched by index finger
        if (other.tag == GlobalVariables.CLOUDS || other.tag == GlobalVariables.THUNDER_CLOUD && IsPinchingLeft())
        {
            print("ENTER CLOUD");
            stick = true;
            if (stickObject == null)
            {
                stickObject = other.gameObject;
            }
            //Extender e = (Extender) other.gameObject;

            //transform.position = new Vector3 (5.0f, 5.0f, 5.0f);		
            //print("The cloud has been touched");
            //stickObject = other.gameObject;
            //onStick = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == GlobalVariables.CLOUDS || other.tag == GlobalVariables.THUNDER_CLOUD)
        {
            print("EXIT CLOUD");
            stick = false;
            stickObject = null;
            //transform.position = new Vector3 (5.0f, 5.0f, 5.0f);		
            //print("The cloud has been touched");
            //stickObject = other.gameObject;
            //onStick = true;
            //stickObject = null;
        }

        if (other.tag == GlobalVariables.RUIN)
        {
            //print("THROWING!");
            //print(speed);
            stick = false;
            stickObject = null;
            Rigidbody r = other.GetComponent<Rigidbody>();
            r.velocity = transform.forward * 5;
        }
    }

    void TransformObject(Vector3 targetLocation, Vector3 stickLocation)
    {
        stickLocation = targetLocation;
    }

    bool IsPinchingLeft()
    {
        return gg.IsPinchingLeft || gg.IsPinchingBoth;
    }
}
