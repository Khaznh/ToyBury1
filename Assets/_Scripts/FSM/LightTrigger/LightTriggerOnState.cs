using UnityEngine;

public class LightTriggerOnState : State
{
    public LightTriggerOnState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        ((LightTriggerEntity)entity).lightTriggerAnimator.Play("LightTriggerOn");
        ((LightTriggerEntity)entity).sfxChannel.RaiseEvent(((LightTriggerEntity)entity).soundToOn, ((LightTriggerEntity)entity).audioSource);
        foreach (var celling in ((LightTriggerEntity)entity).cellingLightList)
        {
            celling.TurnOn();
        }
    }
}
