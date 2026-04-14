using UnityEngine;

public class DoorEntity : Entity
{
    public Animator animator;

    public DoorCloseIdle doorCloseIdle;
    public DoorOpenIdle doorOpenIdle;
    private DoorOpenState doorOpenState;
    private DoorCloseState doorCloseState;

    private FSM fsm;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        fsm = new FSM();
        doorCloseIdle = new DoorCloseIdle(fsm, this);
        doorOpenIdle = new DoorOpenIdle(fsm, this);
        doorOpenState = new DoorOpenState(fsm, this);
        doorCloseState = new DoorCloseState(fsm, this);
        fsm.Init(doorCloseIdle);
    }

    private void Update()
    {
        fsm.currentState.UpdateLogic();
    }

    public void InteractWithDoor()
    {
        if (fsm.currentState == doorCloseIdle)
        {
            fsm.ChangeState(doorOpenState);
        }
        else if (fsm.currentState == doorOpenIdle)
        {
            fsm.ChangeState(doorCloseState);
        }
    }
}
