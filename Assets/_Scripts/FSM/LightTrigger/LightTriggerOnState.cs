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
        PlayerPrefs.SetInt("Light_" + ((LightTriggerEntity)entity).lightID, 1);
        PlayerPrefs.Save();
        Debug.Log("Light_" + ((LightTriggerEntity)entity).lightID + " is set to " + PlayerPrefs.GetInt("Light_" + ((LightTriggerEntity)entity).lightID, 0));
        ((LightTriggerEntity)entity).sfxChannel.RaiseEvent(((LightTriggerEntity)entity).soundToOn, ((LightTriggerEntity)entity).audioSource);
        foreach (var celling in ((LightTriggerEntity)entity).cellingLightList)
        {
            celling.TurnOn();
        }
    }
}
