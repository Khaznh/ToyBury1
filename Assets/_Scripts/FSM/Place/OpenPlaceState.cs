using UnityEngine;

public class OpenPlaceState : PlaceState
{
    private Animator animator;

    public OpenPlaceState(FSM fsm, Entity entity) : base(fsm, entity)
    {
        animator = ((PlaceEntity)entity).placeAnimator;
    }

    public override void EnterState()
    {
        base.EnterState();

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float currentTime = 0;

        if (stateInfo.IsName("PlaceOpen"))
        {
            currentTime = stateInfo.normalizedTime;
        }
        else
        {
            float direction = animator.GetFloat("Direction");
            currentTime = (direction > 0) ? 0f : 1f;
        }

        animator.Play("PlaceOpen", 0, currentTime);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float direction = animator.GetFloat("Direction");

        if (stateInfo.IsName("PlaceOpen"))
        {
            if (direction > 0 && stateInfo.normalizedTime >= 1.0f)
            {
                fsm.ChangeState(((PlaceEntity)entity).idleOpenPlaceState);
                return;
            }
            else if (direction < 0 && stateInfo.normalizedTime <= 0.0f)
            {
                fsm.ChangeState(((PlaceEntity)entity).idleClosePlaceState);
                return;
            }
        }
    }

    public override void PlayerExitPlace()
    {
        base.PlayerExitPlace();
        animator.SetFloat("Direction", -1f);
    }

    public override void PlayerEnterPlace()
    {
        base.PlayerEnterPlace();
        animator.SetFloat("Direction", 1f);
    }
}
