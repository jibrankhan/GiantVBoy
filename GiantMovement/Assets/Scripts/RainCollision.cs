using UnityEngine;
using System.Collections;

public class RainCollision : MonoBehaviour {

    public DungeonMaster dungeon;
    CloudCollision cloud;

    // Use this for initialization
    void Start () {
        cloud = gameObject.transform.GetComponentInParent<CloudCollision>();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision collider)
    {
        // Not delete if touching player or clouds or pinch extenders
        if (collider.gameObject.tag != GlobalVariables.PINCH_EXTENDER_LEFT && collider.gameObject.tag != GlobalVariables.PINCH_EXTENDER_RIGHT && 
            collider.gameObject.tag != GlobalVariables.CLOUDS && collider.gameObject.tag != GlobalVariables.RIVER)
        {
            // Allow to pass through extenders
            if(collider.gameObject.tag == GlobalVariables.PINCH_EXTENDER_LEFT && collider.gameObject.tag == GlobalVariables.PINCH_EXTENDER_RIGHT)
            {
                Physics.IgnoreCollision(collider.gameObject.GetComponent<Collider>() , GetComponent<Collider>());
            }

            if (gameObject != null)
            {
                cloud.DropletDestroyed();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == GlobalVariables.RIVER)
        {
            cloud.IncreaseRainCounter();
            cloud.Delete();
        }
    }
}
