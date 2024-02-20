using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprint : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private InputAction sprintAction;
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
        currentSpeed = walkSpeed;
    }

    void Update()
    {

        HandleMovement();
   
    }

    void OnEnable()
    {
        sprintAction.performed += _ => currentSpeed = sprintSpeed;
        sprintAction.canceled += _ => currentSpeed = walkSpeed;
    }

    void OnDisable()
    {
        sprintAction.performed -= _ => currentSpeed = sprintSpeed;
        sprintAction.canceled -= _ => currentSpeed = walkSpeed;
    }

    void HandleMovement()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        }
    }
}
