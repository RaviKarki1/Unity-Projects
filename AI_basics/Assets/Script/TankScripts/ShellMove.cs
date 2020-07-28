using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMove : MonoBehaviour
{
    float speed = 1;
    void Update()
    {
        this.transform.Translate(0f, Time.deltaTime * speed *.5f, Time.deltaTime * speed);
    }
}
