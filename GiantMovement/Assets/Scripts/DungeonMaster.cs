using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonMaster : MonoBehaviour
{ 
    private River[] rivers;
    public static int GameState;
    public Titan titan;
    public Boy boy;
    public List<Transform> titanTargets;
    public List<Transform> boyTargets;
    public int rainCounter = 0;

    NavMeshAgent titanAgent, boyAgent;
    public int ActNumber { get; set; }
    public float boyDestinationYAdjustment;
    protected bool isAct1Done, isAct2Done, isAct3Done;

    public bool isTesting;
    public int testActNumber;

    // Use this for initialization
    void Start()
    {
        rivers = FindObjectsOfType(typeof(River)) as River[];

        ActNumber = -1;

        //TESTING VARIABLES
        if (isTesting)
        {
            StartAct(testActNumber);
        }

        // Initial state
        GameState = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnGUI()
    {
        if (GameState == -1)
        {
            // lose
        }
        else if (GameState == 1)
        {
            // win
        }
    }

    // Setup new scenario
    public void StartAct(int act)
    {
        print("STARTING ACT " + act);

        ActNumber = act;
        // If act complete move to next target
        titan.SetAgentDesination(titanTargets[act].position);
        boy.SetAgentDesination(new Vector3(boyTargets[act].position.x, boyTargets[act].position.y + boyDestinationYAdjustment, boyTargets[act].position.z));

        // 1 - zap giant
        // 2 - use river to slow giant
        // 3 - user river and zap
    }

    // Increase rain counter
    public void IncreaseRainCounter()
    {
        rainCounter++;

        // If three rain drops have been gathered
        if(rainCounter >= 3)
        {
            print("RIVER ACTIVATED");
            // Change river texture
            foreach(River r in rivers)
            {
                if(r.tag == GlobalVariables.RIVER)
                {
                    r.ActivateRiver(true);
                }
            }
            titan.TitanTakeDamage();
            RequestActChange(2);
        }
    }

    public void RequestActChange(int act)
    {
        // Only increase acts
        if (act > ActNumber)
        {
            print("REQUEST APPROVED STARTING ACT " + act);
            StartAct(act);
        }
    }
}
