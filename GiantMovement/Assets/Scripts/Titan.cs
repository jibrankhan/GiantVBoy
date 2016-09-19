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

    public float giantRiverResetSpeed;
    public float giantMaxSpeed;
    public float giantAccelator;

    // Use this for initialization
    void Start () {
        // Move towards first position
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //print(agent.speed);

        // If giants speed is not greater than or equal to max speed
        if(!(agent.speed >= giantMaxSpeed))
        {
            agent.speed = agent.speed * giantAccelator;
        }
       
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName(GlobalVariables.GIANT_WALK_ANIMATION))
        //{
            //print("PLAYING AUDIO!");
           // if(!audio.isPlaying)
            //{
            //    audio.Play();
            //}

            //if(animator.)
        //}


        if (Vector3.Distance(transform.position, boy.transform.position) < loseDistance && DungeonMaster.GameState != -1)
        {
            DungeonMaster.GameState = -1;
            agent.Stop();
            boy.GetNavAgent.Stop();
            animator.SetBool(GlobalVariables.ANIM_BOOL_GAME_OVER, true);
            Invoke("TitanKillsBoy", 15.0f);
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
        print("TRIGGER ENTER TITAN");
        print(collider.tag);

        if(collider.tag == GlobalVariables.THUNDER_CLOUD || collider.tag == GlobalVariables.RUIN)
        {
            print("TITAN TAKE DAMAGE");

            StartCoroutine(TitanTakeDamage());

            // And this is act 2 and standing in final river
            if (dungeon.ActNumber == 2 && inFinalWater)
            {
                print("DAMAGE TAKEN!");
                // Increase damage
                damageTaken++;
                // End game if damage is final
                if (damageTaken == finalDamageResist)
                {
                    print("YOU WIN!");
                    StartCoroutine(TitanDies());
                    Invoke("TransitionToEndScreen", 15.0f);
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

        if (collider.tag == GlobalVariables.RIVER)
        {
            agent.speed = agent.speed;
        }

        if (collider.tag == GlobalVariables.THUNDER_CLOUD && collider.tag == GlobalVariables.RUIN)
        {
            StartCoroutine(TitanTakeDamage());

            // And this is act 2 and standing in final river
            if (dungeon.ActNumber == 2 && inFinalWater)
            {
                print("DAMAGE TAKEN!");
                // Increase damage
                damageTaken++;
                // End game if damage is final
                if (damageTaken == finalDamageResist)
                {
                    print("YOU WIN!");
                    StartCoroutine(TitanDies());
                    Invoke("TransitionToEndScreen", 15.0f);
                }
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == GlobalVariables.RIVER)
        {
            River r = collider.GetComponent<River>();
            if (r.IsActive)
            {
                agent.speed = giantRiverResetSpeed;
            }
        }

        if (collider.tag == GlobalVariables.THUNDER_CLOUD && collider.tag == GlobalVariables.RUIN)
        {
            StartCoroutine(TitanTakeDamage());

            // And this is act 2 and standing in final river
            if (dungeon.ActNumber == 2 && inFinalWater)
            {
                print("DAMAGE TAKEN!");
                // Increase damage
                damageTaken++;
                // End game if damage is final
                if (damageTaken == finalDamageResist)
                {
                    print("YOU WIN!");
                    StartCoroutine(TitanDies());
                    Invoke("TransitionToEndScreen", 15.0f);
                }
            }
        }
    }

    public IEnumerator TitanTakeDamage()
    {
        print("TAKE DAMAGE");
        agent.Stop();
        //animator.CrossFade(GlobalVariables.TRIGGER_TAKE_DAMAGE, 1);
        animator.SetBool(GlobalVariables.ANIM_BOOL_TAKE_DAMAGE, true);
        yield return new WaitForSeconds(3);
        animator.SetBool(GlobalVariables.ANIM_BOOL_TAKE_DAMAGE, false);
        //animator.CrossFade(GlobalVariables.TRIGGER_TAKE_DAMAGE, 1);
        //animator.SetTrigger(GlobalVariables.TRIGGER_TAKE_DAMAGE);
        yield return new WaitForSeconds(3);
        agent.Resume();

        if (dungeon.ActNumber == 0)
        {
            //dungeon.RequestActChange(1);
        }
    }

    public IEnumerator TitanDies()
    {
        print("TITAN DEAD");
        agent.Stop();
        //animator.CrossFade(GlobalVariables.TRIGGER_TAKE_DAMAGE, 1);
        animator.SetBool(GlobalVariables.GIANT_DEAD, true);
        yield return new WaitForSeconds(3);
    }

    public void TitanKillsBoy()
    {
        // Both agents stop and giant plays animation
        SceneManager.LoadScene("Staging");
    }

    public void TransitionToEndScreen()
    {
        SceneManager.LoadScene(GlobalVariables.END_SCENE_NAME);
    }
}
