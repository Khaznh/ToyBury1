using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public float gravity = 3f;

    private CharacterController controller;
    private PlayerInput input;

    Vector2 temp;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        temp = HandleInput();
    }

    private void FixedUpdate()
    {
        MovePlayer(temp);
    }

    private Vector2 HandleInput()
    {
        return input.Player.Move.ReadValue<Vector2>();
    }

    private void MovePlayer(Vector2 moveVec)
    {
        Vector3 move = transform.right * moveVec.x + transform.forward * moveVec.y + Vector3.down * gravity;
        controller.Move(speed * Time.fixedDeltaTime * move);
    }
}