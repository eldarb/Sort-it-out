using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private InputAction crouchAction;
    public float standHeight = 2.0f;
    private float standCenter = 0.0f;
    public float crouchHeight = 1.0f;
    private float crouchCenter = - 0.5f;
    private bool isCrouching = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        crouchAction = playerInput.actions["Crouch"];
    }

    void OnEnable()
    {
        crouchAction.performed += _ => ToggleCrouch();
    }

    void OnDisable()
    {
        crouchAction.performed -= _ => ToggleCrouch();
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching; 
        if (isCrouching)
        {
            characterController.height = crouchHeight;
            characterController.center = new Vector3(0.0f, crouchCenter, 0.0f);
        }
        else
        {
            characterController.height = standHeight;
            characterController.center = new Vector3(0.0f, standCenter, 0.0f);
        }

    }
  }