using UnityEngine;
using System.Collections;

public class ExtenderScript : MonoBehaviour {

    private Component[] components;
    public GameObject extender;
    public float k;
    public float cameraX = 0;
    public float cameraY = 0;
    public float cameraZ = 0;
    public bool occulusSettings;

    Vector3 origin;

    private Vector3 forward;

    // Use this for initialization
    void Start () {
        //GameObject rig = GameObject.Find("LMHeadMountedRig1");
        //origin = rig.transform.position;
        if(occulusSettings)
        {
            k = 15f;
            cameraY = -4;
        }
        else
        {
            k = 30f;
            cameraY = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {

        GameObject rig = GameObject.Find(GlobalVariables.GREEK_GOD);
        origin = rig.transform.position;

        //extender.transform.position = new Vector3(originX, originY, originZ) + (gameObject.transform.position - new Vector3(originX, originY, originZ)) * k;

        //extender.transform.position = new Vector3(-38.4f, -13.4f, -115.7f) + (gameObject.transform.position - new Vector3(-38.4f, -13.4f, -115.7f)) * k;
        //extender.transform.position =  origin + (gameObject.transform.position - origin) * k;
        //extender.transform.position = origin + (new Vector3(gameObject.transform.position.x + cameraX, gameObject.transform.position.y + cameraY, gameObject.transform.position.z + cameraZ) - origin) * k;
        Vector3 distanceVec = new Vector3(gameObject.transform.position.x + cameraX, gameObject.transform.position.y + cameraY, gameObject.transform.position.z + cameraZ) - origin;
        extender.transform.position = origin + distanceVec * distanceVec.sqrMagnitude;
        
    }
}
