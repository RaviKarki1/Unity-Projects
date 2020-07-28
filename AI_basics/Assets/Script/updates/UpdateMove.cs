using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{

    void Update()
    {
        this.transform.Translate(0f, 0f, Time.deltaTime);

    }
}
