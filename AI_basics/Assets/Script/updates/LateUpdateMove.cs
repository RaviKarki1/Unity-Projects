using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    void LateUpdate()
    {
        this.transform.Translate(0f, 0f, Time.deltaTime);

    }
}
