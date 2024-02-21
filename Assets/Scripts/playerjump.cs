using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Determines if player's y velocity should be gravity, or jump velocity
/// </summary>
public class Playerjump : MonoBehaviour
{ 
    /// <summary>
    /// jump height
    /// </summary>
    public float jumpHeight = 2f;
    /// <summary>
    /// used to check if player is on the ground
    /// </summary>
    private CharacterController characterController;
    /// <summary>
    /// player y velocity: either gravity or jump velocity
    /// </summary>
    public Vector3 playerJumpVelocity;
    /// <summary>
    /// hold grounded value
    /// </summary>
    private bool isGrounded;
    /// <summary>
    /// gravity
    /// </summary>
    public float gravityValue = -9.81f;
    /// <summary>
    /// playerInput, used to get jumpAction component
    /// </summary>
    private PlayerInput playerInput;
    /// <summary>
    /// checks for jump, and applies change in y velocity
    /// </summary>
    private InputAction jumpAction;

    /// <summary>
    /// obtains necessary components
    /// </summary>
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
        playerJumpVelocity = Vector3.zero;
    }
    /// <summary>
    /// Enables call to Jump() on jump input
    /// </summary>
    private void OnEnable()
    {
        jumpAction.performed += _ => Jump();
    }
    /// <summary>
    /// disables call to Jump() on jump input
    /// </summary>
    private void OnDisable()
    {
        jumpAction.performed -= _ => Jump();
    }

    /// <summary>
    /// applies gravity if grounded, or accelerates towards ground
    /// </summary>
    void Update()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded)
        {
            playerJumpVelocity.y = gravityValue;
        }
        else
        {
            playerJumpVelocity.y += gravityValue * Time.deltaTime;
        }
    }
    /// <summary>
    /// on jump input and grounded, change y velocity to jump velocity
    /// </summary>
    private void Jump()
    {
        if (isGrounded)
        {
            playerJumpVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log(isGrounded + ", jump: " + characterController.velocity);
        }
    }
  }