using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveAgents : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] GameObject target; 
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }

}
