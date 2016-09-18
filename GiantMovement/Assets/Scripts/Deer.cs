using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deer : Agent
{
    /*public List<Tree> trees;
    private Tree targetTree;
    private NavMeshAgent agent;
    AudioSource audio;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        if (!travelling)
        {
            Transform pos = FindNearestTree(trees);
            if (pos != null)
            {
                print("SETTING TARGET TO NEAREST TREE");
                // Shift y position of target down because tree is too tall
                Vector3 modifiedPos = new Vector3(pos.position.x, pos.position.y, pos.position.z);

                agent.SetDestination(modifiedPos);
                travelling = true;
            }
        }
    }

    Transform FindNearestTree(List<Tree> trees)
    {
        print("FINDING NEAREST TREE");
        // Judge trees based on current position
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Tree t in trees)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            // Shortest distance and tree has apple

            if (dist < minDist && t.HasApple)
            {
                tMin = t.transform;
                minDist = dist;
                targetTree = t;
            }
        }
        return tMin;
    }

    void OnTriggerEnter(Collider other)
    {
        // When deer hits tree target tree, deer eats apple
        if (other.tag == "Tree" && Vector3.Distance(targetTree.transform.position, transform.position) < 3.0f)
        {
            print("HIT TARGET TREE!");
            StartCoroutine(Eat());
        }
    }

    IEnumerator Eat()
    {
        agent.speed = 0;
        agent.angularSpeed = 0;
        agent.acceleration = 0;

        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        // Play deer munching sound
        audio.Play();
        yield return new WaitForSeconds(2);
        travelling = false;
        Debug.Log("After Waiting 2 Seconds");

        agent.speed = 0.5f;
        agent.angularSpeed = 120;
        agent.acceleration = 8;
    }*/
}
