using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{

    public GameObject fishPrefab;
    public GameObject[] allFish;
    public int numFish;
    private Vector3 swimLimit = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;

    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];

        for(int i = 0; i < numFish; i++)
        {

            Vector3 pos = new Vector3(Random.Range(-swimLimit.x, swimLimit.x),
                                      Random.Range(-swimLimit.y, swimLimit.y),
                                      Random.Range(-swimLimit.z, swimLimit.z));
            allFish[i] =  Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].GetComponent<Flock>().myManager = this;
        }
        
    }
}
