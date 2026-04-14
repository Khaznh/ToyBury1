using UnityEngine;

public class DoorOpenState : State
{
    public DoorOpenState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        ((DoorEntity)entity).animator.Play("DoorOpen");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((DoorEntity)entity).animator.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen") &&
            ((DoorEntity)entity).animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            fsm.ChangeState(((DoorEntity)entity).doorOpenIdle);
        }
    }
}
