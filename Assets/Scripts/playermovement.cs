using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private CharacterController characterController;
    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
    }

    private void Update()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);

        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
