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

    // Clean up stray clouds
    void OnCollisionEnter(Collision collider)
    {
        // Allow to pass through extenders
        if (collider.gameObject.tag == GlobalVariables.PINCH_EXTENDER_LEFT || collider.gameObject.tag == GlobalVariables.PINCH_EXTENDER_RIGHT || collider.gameObject.tag == GlobalVariables.EFFECT)
        {
            print("COLLISION IGNORED " + collider.gameObject.tag);
            Physics.IgnoreCollision(collider.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

        // Not delete if touching player or clouds or pinch extenders
        if (collider.gameObject.tag != GlobalVariables.PINCH_EXTENDER_LEFT && collider.gameObject.tag != GlobalVariables.PINCH_EXTENDER_RIGHT && 
            collider.gameObject.tag != GlobalVariables.CLOUDS && collider.gameObject.tag != GlobalVariables.EFFECT)
        {
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
            // Tell river to increase rain counter
            River r = collider.GetComponent<River>();

            // If river is not full then notify and destroy clouds
            if (!r.riverFull)
            {
                r.IncreaseRainCounter();
                cloud.IncreaseRainCounter();
                cloud.Delete();
                Destroy(gameObject);
            }
        }
    }
}
