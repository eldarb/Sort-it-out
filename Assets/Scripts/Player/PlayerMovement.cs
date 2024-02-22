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

    public float standHeight = 2.0f;
    private float standCenter = 0.0f;
    public float crouchHeight = 1.0f;
    private float crouchCenter = -0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Start()
    {
        currentSpeed = speed;
    }

    private void OnEnable()
    {
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
