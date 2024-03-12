using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    PlayerManager playerManager;
    public Vector2 move { get; private set; }
    public Vector2 look { get; private set; }
    public bool isJumping { get; private set; }
    public bool isCrouching { get; private set; }
    public bool isSprinting { get; private set; }
    public bool isHolding { get; private set; }
    //public bool isThrowing { get; private set; }
    public float power { get; private set; }
    public bool fire { get; private set; }

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        if (!TryGetComponent(out PlayerInput handle))
            return;

        RegisterHandle(handle);
    }

    private void OnDisable()
    {
        if (!TryGetComponent(out PlayerInput handle))
            return;

        UnRegisterHandle(handle);
    }

    void RegisterHandle(PlayerInput input)
    {
        InputAction moveAction = input.actions.FindAction("Move");
        if (moveAction != null)
        {
            moveAction.started += OnMoveStart;
            moveAction.performed += OnMoveStart;
        }
        InputAction lookAction = input.actions.FindAction("Look");
        if (lookAction != null)
        {
            lookAction.started += OnLookStart;
            lookAction.performed += OnLookStart;
        }
        InputAction jumpAction = input.actions.FindAction("Jump");
        if (jumpAction != null)
        {
            jumpAction.started += OnJumpStart;
            jumpAction.canceled += OnJumpEnd;
        }
        InputAction crouchAction = input.actions.FindAction("Crouch");
        if (crouchAction != null)
        {
            crouchAction.started += OnCrouchStart;
            crouchAction.performed += OnCrouchStart;
            crouchAction.canceled += OnCrouchEnd;
        }
        InputAction sprintAction = input.actions.FindAction("Sprint");
        if (sprintAction != null)
        {
            sprintAction.started += OnSprintStart;
            sprintAction.performed += OnSprintStart;
            sprintAction.canceled += OnSprintEnd;
        }

        InputAction adjustPowerAction = input.actions.FindAction("AdjustPower");
        if (adjustPowerAction != null)
        {
            adjustPowerAction.started += OnAdjustPowerStart;
            adjustPowerAction.performed += OnAdjustPowerStart;
            adjustPowerAction.canceled += OnAdjustPowerEnd;
        }
        InputAction fireAction = input.actions.FindAction("Fire");
        if (fireAction != null)
        {
            fireAction.started += OnFireStart;
            fireAction.canceled += OnFireEnd;
        }
    }
    void UnRegisterHandle(PlayerInput input)
    {
        InputAction moveAction = input.actions.FindAction("Move");
        if (moveAction != null)
        {
            moveAction.started -= OnMoveStart;
            moveAction.performed -= OnMoveStart;
        }
        InputAction lookAction = input.actions.FindAction("Look");
        if (lookAction != null)
        {
            lookAction.started -= OnLookStart;
            lookAction.performed -= OnLookStart;
        }
        InputAction jumpAction = input.actions.FindAction("Jump");
        if (jumpAction != null)
        {
            jumpAction.started -= OnJumpStart;
            jumpAction.canceled -= OnJumpEnd;
        }
        InputAction crouchAction = input.actions.FindAction("Crouch");
        if (crouchAction != null)
        {
            crouchAction.started -= OnCrouchStart;
            crouchAction.performed -= OnCrouchStart;
            crouchAction.canceled -= OnCrouchEnd;
        }
        InputAction sprintAction = input.actions.FindAction("Sprint");
        if (sprintAction != null)
        {
            sprintAction.started -= OnSprintStart;
            sprintAction.performed -= OnSprintStart;
            sprintAction.canceled -= OnSprintEnd;
        }

        InputAction adjustPowerAction = input.actions.FindAction("AdjustPower");
        if (adjustPowerAction != null)
        {
            adjustPowerAction.started -= OnAdjustPowerStart;
            adjustPowerAction.performed -= OnAdjustPowerStart;
            adjustPowerAction.canceled -= OnAdjustPowerEnd;
        }
        InputAction fireAction = input.actions.FindAction("Fire");
        if (fireAction != null)
        {
            fireAction.started -= OnFireStart;
            fireAction.canceled -= OnFireEnd;
        }
    }
    void OnMoveStart(InputAction.CallbackContext context)
    {
        SetMove(context.ReadValue<Vector2>());
    }

    void OnLookStart(InputAction.CallbackContext context)
    {
        SetLook(context.ReadValue<Vector2>());
    }

    void OnJumpStart(InputAction.CallbackContext context)
    {
        SetJump(context.ReadValueAsButton());
    }
    void OnJumpEnd(InputAction.CallbackContext context)
    {
        SetJump(context.ReadValueAsButton());
    }
    public virtual void OnSprintStart(InputAction.CallbackContext context)
    {
        SetSprint(context.ReadValueAsButton());
        GameEventsManager.Instance.playerEvents.SprintStart();
    }
    public virtual void OnSprintEnd(InputAction.CallbackContext context)
    {
        SetSprint(context.ReadValueAsButton());
        GameEventsManager.Instance.playerEvents.SprintEnd();
    }
    void OnCrouchStart(InputAction.CallbackContext context)
    {
        SetCrouch(context.ReadValueAsButton());
        GameEventsManager.Instance.playerEvents.CrouchStart();
    }
    void OnCrouchEnd(InputAction.CallbackContext context)
    {
        SetCrouch(context.ReadValueAsButton());
        GameEventsManager.Instance.playerEvents.CrouchEnd();
    }
    void OnAdjustPowerStart(InputAction.CallbackContext context)
    {
        SetPower(context.ReadValue<float>());
    }
    void OnAdjustPowerEnd(InputAction.CallbackContext context)
    {
        SetPower(0);
    }
    void OnFireStart(InputAction.CallbackContext context)
    {
        SetFire(context.ReadValueAsButton());
    }
    void OnFireEnd(InputAction.CallbackContext context)
    {
        SetFire(context.ReadValueAsButton());
        GameEventsManager.Instance.playerEvents.Fire();
        Debug.Log("fire:" + fire);
    }

    void SetMove(Vector2 value)
    {
        move = value;
    }
    void SetLook(Vector2 value)
    {
        look = value;
    }
    public void SetJump(bool value)
    {
        isJumping = value;
    }
    void SetCrouch(bool value)
    {
        isCrouching = value;
    }
    void SetSprint(bool value)
    {
        isSprinting = value;
    }
    void SetPower(float value)
    {
        power = value;
    }

    void SetFire(bool value)
    {
        fire = !value;

    }
}