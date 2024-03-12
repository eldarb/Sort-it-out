using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager playerManager;
    Vector3 moveDir;
    [SerializeField] float speed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float crouchSpeed;
    public float currentSpeed;

    /// <summary>
    /// private AudioClip variable to hold the footsteps SFX.
    /// </summary>
    public AudioClip m_FootStepsSFX;
    /// <summary>
    /// private AudioSource variable to hold the Player's AudioSource.
    /// </summary>
    private AudioSource m_AudioSource;
    /// <summary>
    /// private boolean variable to check if audio is currently playing.
    /// </summary>
    private bool isAudioOn;

    public float standHeight = 2.0f;
    private float standCenter = 0.0f;
    public float crouchHeight = 1.0f;
    private float crouchCenter = -0.5f;

    /// <summary>
    /// Gets and sets a few variables.
    /// </summary>
    void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.clip = m_FootStepsSFX;
        isAudioOn = false;
    }

    private void Start()
    {
        currentSpeed = speed;        
        //Debug.Log(GameEventsManager.Instance == null);
        GameEventsManager.Instance.playerEvents.onSprintStart += SetSpeedSprint;
        GameEventsManager.Instance.playerEvents.onCrouchStart += SetSpeedCrouch;
        GameEventsManager.Instance.playerEvents.onSprintEnd += SetSpeed;
        GameEventsManager.Instance.playerEvents.onCrouchEnd += CrouchEnd;
    }

    private void OnEnable()
    {
        if (GameEventsManager.Instance == null) { return; }
        GameEventsManager.Instance.playerEvents.onSprintStart += SetSpeedSprint;
        GameEventsManager.Instance.playerEvents.onCrouchStart += SetSpeedCrouch;
        GameEventsManager.Instance.playerEvents.onSprintEnd += SetSpeed;
        GameEventsManager.Instance.playerEvents.onCrouchEnd += CrouchEnd;
    }
    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onSprintStart -= SetSpeedSprint;
        GameEventsManager.Instance.playerEvents.onCrouchStart -= SetSpeedCrouch;
        GameEventsManager.Instance.playerEvents.onSprintEnd -= SetSpeed;
        GameEventsManager.Instance.playerEvents.onCrouchEnd -= CrouchEnd;
    }

    public void Move()
    {
        //If the player moves and audio isn't playing, play the footsteps SFX.
        if(playerManager.playerInputManager.move != Vector2.zero && playerManager.playerGrounded.isGrounded) 
        { 
            if(!isAudioOn)
            {
                m_AudioSource.Play();
                isAudioOn = true;
            }
        }
        //Player has stop moving so stop playing the footsteps SFX.
        else 
        {
            if(isAudioOn)
            {
                m_AudioSource.Stop();
                isAudioOn = false;
            }
        }
        moveDir = (transform.forward * playerManager.playerInputManager.move.y + transform.right * playerManager.playerInputManager.move.x) * currentSpeed * Time.deltaTime;
        playerManager.movement = new Vector3(moveDir.x, playerManager.movement.y, moveDir.z);
    }

    void Crouching()
    {
        if (playerManager.playerInputManager.isCrouching)
        {
            playerManager.characterController.height = crouchHeight;
            playerManager.characterController.center = new Vector3(0.0f, crouchCenter, 0.0f);
        }
        else
        {
            playerManager.characterController.height = standHeight;
            playerManager.characterController.center = new Vector3(0.0f, standCenter, 0.0f);
        }
    }

    void SetSpeedSprint()
    {
        currentSpeed = sprintSpeed;
    }
    void SetSpeedCrouch()
    {
        currentSpeed = crouchSpeed;
        Crouching();
    }
    void SetSpeed()
    {
        currentSpeed = speed;
    }
    void CrouchEnd()
    {
        SetSpeed();
        Crouching();
    }
}
