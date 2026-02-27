using UnityEngine;

public class IdleClosePlaceState : PlaceState
{
    public IdleClosePlaceState(FSM fsm, Entity entity) : base(fsm, entity)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

        ((PlaceEntity)entity).placeAnimator.Play("PlaceIdleClose");
    }

    public override void PlayerEnterPlace()
    {
        base.PlayerEnterPlace();
        ((PlaceEntity)entity).placeAnimator.SetFloat("Direction", 1f);
        fsm.ChangeState(((PlaceEntity)entity).openPlaceState);
    }
}
