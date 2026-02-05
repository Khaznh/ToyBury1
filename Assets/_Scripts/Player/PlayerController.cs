using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public GameObject hand;

    public float throwForce = 4f;
    public float forceZAxis = 2f;
    public CinemachineCamera playerCinemachineCamera;

    private PlayerInput playerInput;

    public override void Awake()
    {
        base.Awake();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleThrow();
        HandleUse();
        HandleInteract();
    }

    private void HandleUse()
    {
        if (playerInput.Player.Use.WasPressedThisFrame())
        {
            if (hand.transform.childCount == 0)
            {
                return;
            }

            hand.transform.GetComponentInChildren<Item>()?.Use();
        }
    }

    private void HandleInteract()
    {
        if (playerInput.Player.Interact.WasPressedThisFrame())
        {
            if (RaycastSource.Instance.currentObject == null)
            {
                return;
            }

            RaycastSource.Instance.currentObject.transform.GetComponentInChildren<Item>()?.Interact();
        }
    }

    private void HandleThrow()
    {
        if (playerInput.Player.Throw.WasPressedThisFrame())
        {
            if (hand.transform.childCount == 0)
            {
                return;
            }

            hand.transform.GetComponentInChildren<Item>()?.OnExitItem();
        }
    }
}
