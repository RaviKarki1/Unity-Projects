﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Link
{
    public enum direction {UNI, BI };
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}
public class WpManager : MonoBehaviour
{

    public GameObject[] wayPoints;
    public Link[] links;
    public Graph graph = new Graph();

    void Start()
    {
        if(wayPoints.Length > 0)
        {
            foreach(GameObject wp in wayPoints)
            {
                graph.AddNode(wp);
            }

            foreach(Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                    graph.AddEdge(l.node2, l.node1);
            }
        }
        
    }

    void Update()
    {
        graph.debugDraw();
    }
}
