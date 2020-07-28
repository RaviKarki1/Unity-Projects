using UnityEngine;
using UnityEngine.AI;

public class Idle: State
{
    public Idle(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, anim, player, agent);
            stage = EVENT.EXIT;
        }
        else if(Random.Range(0, 100) < 10)
        {
            nextState = new Patrol(npc, anim, player, agent);
            stage = EVENT.EXIT;
        }
        //base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}

