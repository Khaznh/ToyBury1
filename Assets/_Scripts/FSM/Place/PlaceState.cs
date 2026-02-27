using UnityEngine;

public class PlaceState : State
{
    public PlaceState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public virtual void PlayerEnterPlace()
    {
        Debug.Log("Player entered place");
    }

    public virtual void PlayerExitPlace()
    {
        Debug.Log("Player exited place");
    }
}
