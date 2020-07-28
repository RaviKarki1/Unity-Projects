using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWp : MonoBehaviour
{
    public GameObject[] wayPoints;
    int currentWp = 0;
    public float speed = 10.0f;
    public float rotSpeed = 10;
    public float lookAhed = 10;

    GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhed) return;
        if (Vector3.Distance(tracker.transform.position, wayPoints[currentWp].transform.position) < 3)
            currentWp++;

        if (currentWp >= wayPoints.Length)
            currentWp = 0;

        tracker.transform.LookAt(wayPoints[currentWp].transform.position);
        tracker.transform.Translate(0, 0, (speed+20) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(this.transform.position, wayPoints[currentWp].transform.position) < 3)
        //    currentWp++;

        //if (currentWp >= wayPoints.Length)
        //    currentWp = 0;

        ProgressTracker();


        //this.transform.LookAt(wayPoints[currentWp].transform);
        Quaternion lookAtWp = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWp, Time.deltaTime * rotSpeed);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
