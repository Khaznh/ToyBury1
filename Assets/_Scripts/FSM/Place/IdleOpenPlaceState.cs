using UnityEngine;

public class IdleOpenPlaceState : PlaceState
{
    public IdleOpenPlaceState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        ((PlaceEntity)entity).placeAnimator.Play("PlaceIdleOpen");
    }

    public override void PlayerExitPlace()
    {
        base.PlayerEnterPlace();
        ((PlaceEntity)entity).placeAnimator.SetFloat("Direction", -1f);
        fsm.ChangeState(((PlaceEntity)entity).openPlaceState);
    }
}
