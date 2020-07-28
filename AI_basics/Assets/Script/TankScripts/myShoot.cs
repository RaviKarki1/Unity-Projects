using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myShoot : MonoBehaviour
{
    public GameObject parent;
    public GameObject enemy;
    float turnSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = (enemy.transform.position - parent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
