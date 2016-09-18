using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Hunter : Agent {
  
    public float speed;
    public List<GameObject> hunterTargets;
    public Deer deer;
    public LayerMask riverMask;

    private NavMeshAgent agent;
    private bool hunting = false;
    private bool searching = true;
    private Transform targetTransform;
    public AudioSource hornCall, deerDeath;

    // ray cast variables
    private float rayDistance = 100f;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        // PART OF RANDOM DIRECTION CODE
        MoveToRandomTarget();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // When hunting chase after deer and stop if near water
        if (hunting)
        {
            //print("ON THE HUNT!");
            agent.SetDestination(deer.transform.position);
            StartCoroutine(GetBored());
        }
        else
        {
            // Deer distance check
            if (Vector3.Distance(transform.position, deer.transform.position) < 3.0f)
            {
                hornCall.Play();
                hunting = true;
            }
            // Searching for a new wander target
            if (searching)
            {
                hornCall.Stop();
                //print("Find new target");
                MoveToRandomTarget();
            }
        }

        // PART OF RANDOM DIRECTION CODE
        //transform.position += transform.forward * speed * Time.deltaTime;
	}

    void FixedUpdate()
    {
        // Slightly above player origin
        Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 rayDirection = new Vector3(transform.forward.x, transform.forward.y - 0.5f, transform.forward.z);

        //Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // River distance check - layer 8
        if (Physics.Raycast(rayOrigin, rayDirection, 100.0f, 1 << 8) && hunting)
        {
            print("RIVER NOOOO!");
            hunting = false;
            StartCoroutine(Wait());
        }
    }

    /*void FaceRandomDirection()
    {
    // PART OF RANDOM DIRECTION CODE
        Vector3 randomDirection = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        transform.Rotate(randomDirection);
        print("CHANGE DIRECTION " + randomDirection);
    }*/

    void MoveToRandomTarget()
    {
        //print("MOVE TO RANDOM TARGET");
        agent.SetDestination(ReturnRandomTarget().position);
        searching = false;
    }

    /// <summary>
    /// Returns a random target position to move.
    /// </summary>
    /// <returns></returns>
    Transform ReturnRandomTarget()
    {
        int randomNum = Random.Range(0, 12);
        print("MOVE TO RANDOM TARGET " + randomNum);
        targetTransform = hunterTargets[randomNum].transform;
        return targetTransform;
    }

    void OnTriggerEnter(Collider other)
    {
        // Reached wander target position, start searching again
        if (other.tag == "HunterTarget" && Vector3.Distance(transform.position, targetTransform.position) < 7)
        {
            //print("HIT HUNTER TARGET!");
            searching = true;
        }
        else if (other.tag == "Deer")
        {
            deerDeath.Play();
            print("GAME OVER!");
            SceneManager.LoadScene("Main");
            DungeonMaster.GameState = -1;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    IEnumerator GetBored()
    {
        print("IM BORED!");
        yield return new WaitForSeconds(5);
        hunting = false;
    }
}
