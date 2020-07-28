using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State{
    public Pursue(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent)
    {
        name = STATE.PURSUE;
        agent.speed = 5;
        agent.isStopped = false;
    }


    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.position);
        //Debug.Log("agent.hasPath --" + agent.hasPath);
        if (agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                nextState = new Attack(npc, anim, player, agent);
                stage = EVENT.EXIT;
            }
            else if(!CanSeePlayer())
            {
                nextState = new Patrol(npc, anim, player, agent);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        base.Exit();
    }
}
