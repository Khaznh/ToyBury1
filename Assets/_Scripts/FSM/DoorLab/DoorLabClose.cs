using UnityEngine;

public class DoorLabClose : State
{
    public DoorLabClose(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        ((DoorLabEntity)entity).animator.Play("DoorLabClose");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((DoorLabEntity)entity).animator.GetCurrentAnimatorStateInfo(0).IsName("DoorLabClose") &&
            ((DoorLabEntity)entity).animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            fsm.ChangeState(((DoorLabEntity)entity).doorLabIdleClose);
        }
    }
}