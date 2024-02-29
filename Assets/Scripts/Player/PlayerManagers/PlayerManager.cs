using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public PlayerCamera playerCamera;
    public PlayerJump playerJump;
    public PlayerMovement playerMovement;
    public PlayerGrounded playerGrounded;
    public PlayerLadderMovement playerLadderMovement;

    public CharacterController characterController;
    public PowerGauge powerGauge;
    public PickUpDropThrow pickUpDropThrow;

    public Vector3 movement;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerCamera = GetComponent<PlayerCamera>();
        playerJump = GetComponent<PlayerJump>();
        playerMovement = GetComponent<PlayerMovement>();
        playerGrounded = GetComponent<PlayerGrounded>();
        playerLadderMovement = GetComponent<PlayerLadderMovement>();
        characterController = GetComponent<CharacterController>();
        powerGauge = GetComponentInChildren<PowerGauge>();
        pickUpDropThrow = GetComponent<PickUpDropThrow>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded.GroundedCheck();
        playerMovement.Move();
        movement = playerLadderMovement.HandleLadderMovement(movement);
        if (pickUpDropThrow.recoiling)
        {
            movement = pickUpDropThrow.recoil(movement);
        }
        characterController.Move(movement);
        if (powerGauge != null) {
            powerGauge.AdjustPower();
        }
    }
}
