using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerEntity : Entity
{
    public Animator lightTriggerAnimator;
    public List<CellingLight> cellingLightList;

    private LightTriggerOffState offState;
    private LightTriggerOnState onState;
    private FSM fsm;

    private void Awake()
    {
        lightTriggerAnimator = GetComponent<Animator>();
        fsm = new FSM();
        onState = new LightTriggerOnState(fsm, this);
        offState = new LightTriggerOffState(fsm, this);

        fsm.Init(offState);
    }

    public void ChangeCurrentState()
    {
        if (fsm.currentState == offState)
        {
            fsm.ChangeState(onState);
        }
        else
        {
            fsm.ChangeState(offState);
        }
    }
}
