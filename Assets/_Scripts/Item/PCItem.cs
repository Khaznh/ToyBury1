using Unity.Cinemachine;
using UnityEngine;

public class PCItem : Item
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    public override void Interact()
    {
        GetComponent<PCManager>().OpenComputer();
        playerInput.Enable();
    }

    private void Update()
    {
        HandleExit();
    }

    private void HandleExit()
    {
        if (playerInput.Player.Use.WasPressedThisFrame())
        {
            GetComponent<PCManager>().ExitToComputer();
            playerInput.Disable();
        }
    }
}
