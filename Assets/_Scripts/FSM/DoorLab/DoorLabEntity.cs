using UnityEngine;

public class DoorLabEntity : Entity
{
    public Animator animator;

    public DoorLabIdleClose doorLabIdleClose;
    public DoorLabIdleOpen doorLabIdleOpen;

    private FSM fsm;
    private DoorLabClose doorLabClose;
    private DoorLabOpen doorLabOpen;

    private void Awake()
    {
        fsm = new FSM();

        animator = GetComponent<Animator>();

        doorLabIdleClose = new DoorLabIdleClose(fsm, this);
        doorLabIdleOpen = new DoorLabIdleOpen(fsm, this);
        doorLabClose = new DoorLabClose(fsm, this);
        doorLabOpen = new DoorLabOpen(fsm, this);

        fsm.Init(doorLabIdleClose);
    }

    private void Update()
    {
        fsm.currentState.UpdateLogic();
    }

    public void InteractWithDoor()
    {
        if (fsm.currentState == doorLabIdleClose)
        {
            fsm.ChangeState(doorLabOpen);
        }
        else if (fsm.currentState == doorLabIdleOpen)
        {
            fsm.ChangeState(doorLabClose);
        }
    }
}
