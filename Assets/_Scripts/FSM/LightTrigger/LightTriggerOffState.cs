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
        PlayerPrefs.SetInt("Light_" + ((LightTriggerEntity)entity).lightID, 0);
        PlayerPrefs.Save();
        Debug.Log("Light_" + ((LightTriggerEntity)entity).lightID + " is set to " + PlayerPrefs.GetInt("Light_" + ((LightTriggerEntity)entity).lightID, 0));
        ((LightTriggerEntity)entity).sfxChannel.RaiseEvent(((LightTriggerEntity)entity).soundToOff, ((LightTriggerEntity)entity).audioSource);
        foreach (var celling in ((LightTriggerEntity)entity).cellingLightList)
        {
            celling.TurnOff();
        }
    }
}
