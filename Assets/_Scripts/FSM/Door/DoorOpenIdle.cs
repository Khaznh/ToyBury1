using UnityEngine;

public class DoorOpenIdle : State
{
    public DoorOpenIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((DoorEntity)entity).animator.Play("DoorOpenIdle");
    }
}
