using UnityEngine;

public class DoorLabIdleOpen : State
{
    public DoorLabIdleOpen(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((DoorLabEntity)entity).animator.Play("DoorLabIdleOpen");
    }
}