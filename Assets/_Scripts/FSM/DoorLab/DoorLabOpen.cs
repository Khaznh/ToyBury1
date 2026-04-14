using UnityEngine;

public class DoorLabOpen : State
{
    public DoorLabOpen(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        ((DoorLabEntity)entity).animator.Play("DoorLabOpen");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (((DoorLabEntity)entity).animator.GetCurrentAnimatorStateInfo(0).IsName("DoorLabOpen") &&
            ((DoorLabEntity)entity).animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            fsm.ChangeState(((DoorLabEntity)entity).doorLabIdleOpen);
        }
    }
}
