using UnityEngine;

public class DoorCloseIdle : State
{
    public DoorCloseIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((DoorEntity)entity).animator.Play("DoorCloseIdle");
    }
}
