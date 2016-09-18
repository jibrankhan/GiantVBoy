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
        // Not delete if touching player or clouds
        if (collider.gameObject.tag != GlobalVariables.PLAYER && collider.gameObject.tag != GlobalVariables.CLOUDS && collider.gameObject.tag != GlobalVariables.RIVER)
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
            cloud.IncreaseRainCounter();
            cloud.Delete();
        }
    }
}
