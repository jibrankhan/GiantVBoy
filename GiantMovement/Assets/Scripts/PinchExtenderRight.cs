using UnityEngine;
using System.Collections;

public class PinchExtenderRight : Extender
{
    // Use this for initialization
    void Start()
    {
        // Collect clouds
        thunderClouds = FindObjectsOfType<ThunderCloud>();
        rainClouds = FindObjectsOfType<CloudCollision>();
    }

    // Update is called once per frame
    void Update()
    {

        // If stick then transform else do distance checks and snap
        if (stick)
        {
            if (IsPinchingRight() && stickObject != null)
            {
                print("MOVE CLOUD!");
                stickObject.transform.position = transform.position;
                //TransformObject(stickObject.transform.position, transform.position);
            }
        }
        else
        {
            foreach (ThunderCloud t in thunderClouds)
            {
                // If pinching in anyway, not cloud already set and distance under a position
                if (IsPinchingRight() && stickObject == null)
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
                if (IsPinchingRight() && stickObject == null)
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
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    { 
        // If touched by index finger
        if (other.tag == GlobalVariables.CLOUDS || other.tag == GlobalVariables.THUNDER_CLOUD && IsPinchingRight())
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
    }

    void TransformObject(Vector3 targetLocation, Vector3 stickLocation)
    {
        stickLocation = targetLocation;
    }

    bool IsPinchingRight()
    {
        return gg.IsPinchingRight || gg.IsPinchingBoth;
    }
}
