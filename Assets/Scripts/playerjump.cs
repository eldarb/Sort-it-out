using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerjump : MonoBehaviour
{ 
    public float jumpHeight = 2f;
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float gravityValue = -9.81f;
    private PlayerInput playerInput;
    private InputAction jumpAction;

    /// <summary>
    /// private AudioClip variable to hold the footsteps SFX.
    /// </summary>
    public AudioClip m_JumpingSFX;
    /// <summary>
    /// private AudioSource variable to hold the Player's AudioSource.
    /// </summary>
    private AudioSource m_AudioSource;

    /// <summary>
    /// Gets and sets a few variables.
    /// </summary>
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        m_AudioSource = GetComponent<AudioSource>();
        jumpAction = playerInput.actions["Jump"]; 
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
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            // if(m_AudioSource.isPlaying)
            // {
            //     m_AudioSource.Stop();
            // }
            // m_AudioSource.PlayOneShot(m_JumpingSFX);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
  }