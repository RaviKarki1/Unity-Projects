using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    float speed = 5;
    float accuracy = 1;
    float rotSpeed = 2;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int curretnWp = 0;
    Graph g;

    private void Start()
    {
        wps = wpManager.GetComponent<WpManager>().wayPoints;
        g = wpManager.GetComponent<WpManager>().graph;
        currentNode = wps[0];
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[1]);
        curretnWp = 0;
    }

    public void GoTORuin()
    {
        g.AStar(currentNode, wps[6]);
        curretnWp = 0;
    }

    private void LateUpdate()
    {
        if (g.getPathLength() == 0 || curretnWp == g.getPathLength())
            return;

        //node we r closest to at this moment
        currentNode = g.getPathPoint(curretnWp);

        //if we r close to current waypoint move to next
        if(Vector3.Distance(g.getPathPoint(curretnWp).transform.position, transform.position) < accuracy)
        {
            curretnWp++;
        }

        //if we r not at the end of the path
        if(curretnWp < g.getPathLength())
        {
            goal = g.getPathPoint(curretnWp).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                                             this.transform.position.y,
                                             goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }

}
