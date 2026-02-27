using System.Runtime.InteropServices;
using UnityEngine;

public class State
{
    public FSM fsm;
    public Entity entity;

    private float timer;

    public State(FSM fsm, Entity entity)
    {
        this.fsm = fsm;
        this.entity = entity;
    }

    public virtual void EnterState()
    {
        timer = Time.time;
    }

    public virtual void UpdateLogic()
    {

    }

    public virtual void UpdatePhysics()
    {

    }

    public virtual void ExitState()
    {

    }

    public float TimeInState()
    {
        return Time.time - timer;
    }
}
