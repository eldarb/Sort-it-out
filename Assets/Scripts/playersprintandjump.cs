using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintAndJump : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float jumpHeight = 2f;
    public float gravityValue = -9.81f;

    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float sprintSpeed = 10.0f;
    private float currentSpeed;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["Sprint"];
        jumpAction = playerInput.actions["Jump"];
        currentSpeed = walkSpeed;
    }

    void OnEnable()
    {
        sprintAction.performed += _ => currentSpeed = sprintSpeed;
        sprintAction.canceled += _ => currentSpeed = walkSpeed;
        jumpAction.performed += _ => Jump();
    }

    void OnDisable()
    {
        sprintAction.performed -= _ => currentSpeed = sprintSpeed;
        sprintAction.canceled -= _ => currentSpeed = walkSpeed;
        jumpAction.performed -= _ => Jump();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        HandleMovement();

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void HandleMovement()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
}
