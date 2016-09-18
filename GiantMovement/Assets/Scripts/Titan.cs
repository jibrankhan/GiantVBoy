using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Titan : Agent {

    public GreekGod gg;
    public Boy boy;
    public AudioClip closeStep, farStep;
    public DungeonMaster dungeon;
    public int finalDamageResist;
    public float loseDistance;

    AudioSource audio;
    NavMeshAgent agent;
    private int damageTaken = 0;
    private bool inFinalWater = false;
    Animator animator;
    bool firstAnimation;

    // Use this for initialization
    void Start () {
        // Move towards first position
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(GlobalVariables.GIANT_WALK_ANIMATION))
        {
            print("PLAYING AUDIO!");
            if(!audio.isPlaying)
            {
                audio.Play();
            }

            //if(animator.)
        }

        // Titan/boy distance checks
        // Check if we've reached the destination
        if (!agent.pathPending)
        {
            // Distance check
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                // No path and stopped
                //if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                //{
                    // Done
                //    SceneManager.LoadScene("Main");
                //}
            }

            //print(Vector3.Distance(transform.position, boy.transform.position));

            // If close to boy reset game for now   
            //if(Vector3.Distance(transform.position, boy.transform.position) < loseDistance)
            //{
            //    SceneManager.LoadScene("Staging");
            //}

            /*if (agent.remainingDistance <= 20f)
            {
                if (!audio.isPlaying)
                {
                    audio.clip = closeStep;
                    audio.Play();
                    gg.StartShake();
                }
            }
            else
            {
                if (!audio.isPlaying)
                {
                    audio.clip = farStep;
                    audio.Play();
                    gg.StartShake();
                }
            }*/
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == GlobalVariables.THUNDER_CLOUD)
        { 
            if(dungeon.ActNumber == 0)
            {
                StartCoroutine(TitanTakeDamage());
            }

            // And this is act 2 and standing in final river
            if (dungeon.ActNumber == 2 && inFinalWater)
            {
                print("DAMAGE TAKEN!");
                // Increase damage
                damageTaken++;
                // End game if damage is final
                if (damageTaken == finalDamageResist)
                {
                    Application.Quit();
                }
            } 
        }

        if(collider.tag == GlobalVariables.FINAL_RIVER)
        {
            inFinalWater = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == GlobalVariables.FINAL_RIVER)
        {
            inFinalWater = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        
    }

    public IEnumerator TitanTakeDamage()
    {
        agent.Stop();
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
        agent.Resume();

        if (dungeon.ActNumber == 0)
        {
            dungeon.RequestActChange(1);
        }
    }
}
