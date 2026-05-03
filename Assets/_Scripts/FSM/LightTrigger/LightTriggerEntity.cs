using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerEntity : Entity
{
    public Animator lightTriggerAnimator;
    public List<CellingLight> cellingLightList;

    [SerializeField] private bool isNeedToTurnOn = false;

    public int lightID;

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
    }

    private void Start()
    {
        if (isNeedToTurnOn && SaveGameManager.Instance.newGame)
        {
            fsm.Init(onState);
        }
        else if (!SaveGameManager.Instance.newGame)
        {
            bool isLightOn = PlayerPrefs.GetInt("Light_" + lightID, 0) == 1;
            Debug.Log(isLightOn + "_" + lightID);
            if (isLightOn)
            {
                fsm.ChangeState(onState);
            }
            else
            {
                fsm.ChangeState(offState);
            }
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
