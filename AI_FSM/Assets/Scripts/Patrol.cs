using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;
    public Patrol(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent)
    {
        name = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        //currentIndex = 0;
        float lastDist = Mathf.Infinity;
        for(int i = 0; i < GameEnvironment.singleton.Checkpoints.Count; i++)
        {
            GameObject thisWp = GameEnvironment.singleton.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, thisWp.transform.position);
            if(distance < lastDist)
            {
                currentIndex = i-1;
                lastDist = distance;
            }
        }
        anim.SetTrigger("isWalking");
        base.Enter();
    }
    public override void Update()
    {
        if(agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironment.singleton.Checkpoints.Count - 1)
                currentIndex = 0;
            else
                currentIndex += 1;

            agent.SetDestination(GameEnvironment.singleton.Checkpoints[currentIndex].transform.position);
        }
        else if (CanSeePlayer())
        {
            nextState = new Pursue(npc, anim, player, agent);
            stage = EVENT.EXIT;
        }

        //base.Update();
    }
    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}

