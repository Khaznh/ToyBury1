using UnityEngine;

public class FSM
{
    public State currentState;
    public State previousState;

    public void ChangeState(State newState)
    {
        currentState.ExitState();
        previousState = currentState;
        currentState = newState;
        currentState.EnterState();
    }

    public void Init(State startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }
}
