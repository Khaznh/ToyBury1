using UnityEngine;

public class PlaceEntity : Entity
{
    public Animator placeAnimator;

    public OpenPlaceState openPlaceState;
    public IdleOpenPlaceState idleOpenPlaceState;
    public IdleClosePlaceState idleClosePlaceState;

    private FSM fsm;

    private void Awake()
    {
        placeAnimator = GetComponent<Animator>();

        fsm = new FSM();

        openPlaceState = new OpenPlaceState(fsm,this);
        idleClosePlaceState = new IdleClosePlaceState(fsm, this);
        idleOpenPlaceState = new IdleOpenPlaceState(fsm, this);

        fsm.Init(idleClosePlaceState);
    }

    private void Update()
    {
        fsm.currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        fsm.currentState.UpdatePhysics();
    }

    public void PlayerEnter()
    {
        ((PlaceState)fsm.currentState).PlayerEnterPlace();
    }

    public void PlayerExit()
    {
        ((PlaceState)fsm.currentState).PlayerExitPlace();
    }
}
