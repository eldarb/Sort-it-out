using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script handles general player movement including sprint and obtains y-directional velocity from the PlayerJump script
/// so that the characterController.move() is able to move the player depending on their inputs
/// </summary>
public class PlayerSprint : MonoBehaviour
{
    /// <summary>
    /// Unity's CharacterController, used to call move()
    /// </summary>
    private CharacterController characterController;
    /// <summary>
    /// Used to get player inputs
    /// </summary>
    private PlayerInput playerInput;
    /// <summary>
    /// Used to get sprint input and apply speed change
    /// </summary>
    private InputAction sprintAction;
    /// <summary>
    /// Walkspeed value
    /// </summary>
    [SerializeField] private float walkSpeed = 5.0f;
    /// <summary>
    /// sprint speed value
    /// </summary>
    [SerializeField] private float sprintSpeed = 10.0f;
    /// <summary>
    /// speed of player (either sprint/walk speed)
    /// </summary>
    private float currentSpeed;
    //public float turnSmoothTime = 0.1f;
    private Playerjump playerJump;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["Sprint"];
        currentSpeed = walkSpeed;
        playerJump = GetComponent<Playerjump>();
    }

    /// <summary>
    /// calls HandleMovement
    /// </summary>
    void Update()
    {

        HandleMovement();

    }
    /// <summary>
    ///Enables change in speed on walk/sprint inputs
    /// </summary>
    void OnEnable()
    {
        sprintAction.performed += _ => currentSpeed = sprintSpeed;
        sprintAction.canceled += _ => currentSpeed = walkSpeed;
    }
    /// <summary>
    /// Disables behavior on change in speed on walk/sprint inputs
    /// </summary>
    void OnDisable()
    {
        sprintAction.performed -= _ => currentSpeed = sprintSpeed;
        sprintAction.canceled -= _ => currentSpeed = walkSpeed;
    }
    /// <summary>
    /// Handles ordinary movement and jump
    /// </summary>
    void HandleMovement()
    {
        // reads player movement input
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        // calculates direction of movement
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        Vector3 moveDir = Vector3.zero;
        if(direction.magnitude >= 0.1f) 
        { 
            // moves player at inputted direction, at angle from the direction player is facing
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
        }
        // normalizes direction, then applies speed to movement
        moveDir = moveDir.normalized * currentSpeed;
        // apply gravity or player jump velocity
        moveDir += playerJump.playerJumpVelocity;
        // finally applies movement to player
        characterController.Move(moveDir * Time.deltaTime);
    }
}
