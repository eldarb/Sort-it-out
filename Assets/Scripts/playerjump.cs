using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerjump : MonoBehaviour
{ 
  public float jumpHeight = 2f;
    private CharacterController characterController;
    public Vector3 playerJumpVelocity;
    private bool isGrounded;
    public float gravityValue = -9.81f;
    private PlayerInput playerInput;
    private InputAction jumpAction;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
        playerJumpVelocity = Vector3.zero;
    }

    private void OnEnable()
    {
        jumpAction.performed += _ => Jump();
    }

    private void OnDisable()
    {
        jumpAction.performed -= _ => Jump();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        //Debug.Log(characterController.velocity);
        //Debug.Log(isGrounded + ", " + characterController.velocity);
        if (isGrounded)
        {
            playerJumpVelocity.y = gravityValue;
        }
        else
        {
            playerJumpVelocity.y += gravityValue * Time.deltaTime;
            //Debug.Log("gravity in air: " + playerVelocity.y);
        }
       
        //characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerJumpVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log(isGrounded + ", jump: " + characterController.velocity);
        }
    }
  }