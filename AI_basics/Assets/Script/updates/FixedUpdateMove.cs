using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateMove : MonoBehaviour
{
    void FixedUpdate()
    {
        this.transform.Translate(0f, 0f, Time.deltaTime);
    }
}
