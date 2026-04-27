using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerEntity : Entity
{
    public Animator lightTriggerAnimator;
    public List<CellingLight> cellingLightList;

    [SerializeField] private bool isNeedToTurnOn = false;

    public AudioClip soundToOn;
    public AudioClip soundToOff;
    public AudioEventSO sfxChannel;
    public AudioSource audioSource;

    private LightTriggerOffState offState;
    private LightTriggerOnState onState;
    private FSM fsm;

    private void Awake()
    {
        lightTriggerAnimator = GetComponent<Animator>();
        fsm = new FSM();
        onState = new LightTriggerOnState(fsm, this);
        offState = new LightTriggerOffState(fsm, this);
        if (isNeedToTurnOn)
        {
            fsm.Init(onState);
        }
        else
        {
            fsm.Init(offState);
        }
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

    public void ForceTurnOff()
    {
        if (fsm.currentState == onState)
        {
            fsm.ChangeState(offState);
        }
    }
}
