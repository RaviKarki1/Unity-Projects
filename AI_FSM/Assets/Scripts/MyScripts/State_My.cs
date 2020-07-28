using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_My
{
    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP
    }
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE name;
    public EVENT stage;

    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected NavMeshAgent agent;
    protected State_My nextState;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State_My(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent)
    {
        npc = _npc;
        anim = _anim;
        player = _player;
        agent = _agent;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State_My Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if(stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        Debug.Log(stage);
        return this;
    }


}

public class Idle_My : State_My
{
    public Idle_My(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent)
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
        //base.Update();
        if(Random.Range(0, 100) < 10)
        {
            nextState = new Patrol_My(npc, anim, player, agent);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}

public class Patrol_My : State_My
{
    public Patrol_My(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent)
    {
        name = STATE.PATROL;
    }

    public override void Enter()
    {
        anim.SetTrigger("isWalking");
        base.Enter();
    }

    int currentIndex = 0;
    public override void Update()
    {
        Debug.Log("currentIndex :"+ (currentIndex >= GameEnvironMent_my.singleton.chekcpoints.Count - 1));
        //GameEnvironment.singleton.Checkpoints.Coun
        if(agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironMent_my.singleton.Checkpoints.Count - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex += 1;
                Debug.Log("currentIndex :" + currentIndex);
            }
        }

        agent.SetDestination(GameEnvironMent_my.singleton.Checkpoints[currentIndex].transform.position);
        //base.Update();
    }
    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
