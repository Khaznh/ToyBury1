using UnityEngine;

public class DoorLabIdleClose : State
{
    public DoorLabIdleClose(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((DoorLabEntity)entity).animator.Play("DoorLabIdleClose");
    }
}
