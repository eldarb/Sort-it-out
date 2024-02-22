using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLadderMovement : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerInput playerInput;
    InputAction climbAction;
    public bool climbingLadder { private set; get; }
    [SerializeField] public int climbingLadderSpeed;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        playerInput = GetComponent<PlayerInput>();
        climbAction = playerInput.actions.FindAction("Move");
        climbingLadder = false;
        climbingLadderSpeed = 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Ladder"))
        {
            // disable jumping when player is on ladder
            Debug.Log("On ladder");
            climbingLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            // enable jumping when player is off ladder
            Debug.Log("Off ladder");
            climbingLadder = false;
        }
    }

    public Vector3 HandleLadderMovement(Vector3 movement)
    {
        if (climbingLadder)
        {
            // going down
            if (movement.x < 0)
            {
                movement.y = -1 * climbingLadderSpeed * Time.deltaTime;
            }
            //if (movement.x < 0 && playerManager.playerGrounded.GroundedCheck())
            //{
            //    movement.y = -1 * climbingLadderSpeed * Time.deltaTime;
            //    movement.x = 0;
            //}
            // going up
            else if (playerManager.movement.x > 0) 
            {
                movement.y = climbingLadderSpeed * Time.deltaTime; 
            }
            // staying still
            else { movement.y = 0; }
        }
        return movement;
    }
}
