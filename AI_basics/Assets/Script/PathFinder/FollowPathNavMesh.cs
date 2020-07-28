using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathNavMesh : MonoBehaviour
{
    
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;


    private void Start()
    {
        wps = wpManager.GetComponent<WpManager>().wayPoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void GoToHeli()
    {
        agent.SetDestination(wps[1].transform.position);
        //g.AStar(currentNode, wps[1]);
        //curretnWp = 0;
    }

    public void GoTORuin()
    {
        agent.SetDestination(wps[6].transform.position);
        //g.AStar(currentNode, wps[6]);
        //curretnWp = 0;
    }

    private void LateUpdate()
    {
    }

}
