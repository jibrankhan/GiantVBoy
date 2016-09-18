using UnityEngine;
using System.Collections;

public class EntenderMaster : MonoBehaviour {

    public GameObject extenderL;
    public GameObject extenderR;
    public GameObject boneL;
    public GameObject boneR;


    private Vector3 originL;
    private Vector3 originR;
    //private Vector3 prevL;
    //private Vector3 prevR;
    //private Vector3 currL;
    //private Vector3 currR;

    // Use this for initialization
    void Start () {
        //prevL = boneL.transform.position;
        //prevR = boneR.transform.position;

        //GameObject rig = GameObject.Find("LMHeadMountedRig");
        //VRHeightOffset offset = rig.GetComponent<VRHeightOffset>();
        //Debug.Log(offset._deviceOffsets[0].HeightOffset);

        //originL += new Vector3(0, offset._deviceOffsets[0].HeightOffset, 0);
        //originR += new Vector3(0, offset._deviceOffsets[0].HeightOffset, 0);
        //originL += new Vector3(0, 1, 0);
        //originR += new Vector3(0, 1, 0);


        //extenderL.transform.position = prevL;
        //extenderR.transform.position = prevR;

        //originL = rig.transform.position;
        //originR = rig.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 movementL = boneL.transform.position - prevL;
        //Vector3 movementR = boneR.transform.position - prevR;
        //extenderL.transform.position += movementL * 2;
        //extenderR.transform.position += movementR * 2;
        //prevL = movementL;
        //prevR = movementR;

        //extenderL.transform.position = originL + (boneL.transform.position - originL) * 10;
        //extenderR.transform.position = originR + (boneR.transform.position - originR) * 10;

        //extenderL.transform.position = originL + (boneL.transform.position - originL) * 5;
        //extenderR.transform.position = originR + (boneR.transform.position - originR) * 5;

    }
}
