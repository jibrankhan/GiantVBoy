using UnityEngine;
using System.Collections;

public class River : MonoBehaviour {

    private Component[] components;
    private Component[] colliderComp;
    private MeshRenderer riverBedRenderer;
    private bool isActive = false;

    public GameObject riverBed;
    public Material riverDry, riverWet;

    // Use this for initialization
    void Start () {
        components = GetComponentsInChildren<NavMeshObstacle>();
        colliderComp = GetComponentsInChildren<BoxCollider>();
        riverBedRenderer = riverBed.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /// <summary>
    /// Method to turn on and off this rivers navmeshobstacle children components.
    /// </summary>
    /// <param name="activate"></param>
    public void ActivateRiver(bool activate)
    {
        isActive = activate;

        if(isActive)
        {
            riverBedRenderer.material = riverWet;
            //print("CHANGING TEXTURE WET!");
        }
        else
        {
            riverBedRenderer.material = riverDry;
            //print("CHANGING TEXTURE DRY!");
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
        }
    }
}
