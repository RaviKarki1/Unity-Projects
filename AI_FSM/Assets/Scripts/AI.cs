using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform Player;
    State_My currentState;


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Idle_My(this.gameObject, anim, Player, agent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
