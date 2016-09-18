using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

    NavMeshAgent agent;

    public void SetAgentDesination(Vector3 agentDestination)
    {
        if(agent == null)
        {
            agent = GetNavAgent;
        }

        agent.SetDestination(agentDestination);
    }

    public NavMeshAgent GetNavAgent
    {
        get
        {
            if(agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }

            return agent;
        }
    }
}
