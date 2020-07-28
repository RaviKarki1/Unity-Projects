using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    float rotationSpeed = 2.0f;
    AudioSource shoot;

    public Attack(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent) : base(_npc, _anim, _player, _agent){
        name = STATE.ATTACK;
        shoot = npc.GetComponent<AudioSource>();
    }


    public override void Enter()
    {
        anim.SetTrigger("isShooting");
        agent.isStopped = true;
        shoot.Play();
        base.Enter();
        
    }

    public override void Update()
    {
        //base.Update();
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        direction.y = 0;
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotationSpeed);
        if (!CanAttackPlayer())
        {
            nextState = new Idle(npc, anim, player, agent);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isShooting");
        shoot.Stop();
        base.Exit();
    }
}