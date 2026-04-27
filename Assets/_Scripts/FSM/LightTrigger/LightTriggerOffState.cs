using UnityEngine;

public class LightTriggerOffState : State
{
    public LightTriggerOffState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        ((LightTriggerEntity)entity).lightTriggerAnimator.Play("LightTriggerOff");
        ((LightTriggerEntity)entity).sfxChannel.RaiseEvent(((LightTriggerEntity)entity).soundToOff, ((LightTriggerEntity)entity).audioSource);
        foreach (var celling in ((LightTriggerEntity)entity).cellingLightList)
        {
            celling.TurnOff();
        }
    }
}
