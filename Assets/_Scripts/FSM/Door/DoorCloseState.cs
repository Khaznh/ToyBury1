using UnityEngine;

public class DoorCloseState : State
{
    public DoorCloseState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((DoorEntity)entity).animator.Play("DoorClose");
        ((DoorEntity)entity).sfxChannel.RaiseEvent(((DoorEntity)entity).doorAudio, ((DoorEntity)entity).audioSource);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((DoorEntity)entity).animator.GetCurrentAnimatorStateInfo(0).IsName("DoorClose") &&
            ((DoorEntity)entity).animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            fsm.ChangeState(((DoorEntity)entity).doorCloseIdle);
        }
    }
}
