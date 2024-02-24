using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Allows player to climb ladders
/// </summary>
public class PlayerLadderMovement : MonoBehaviour
{
    /// <summary>
    /// used to change movement variable in playerManager
    /// </summary>
    PlayerManager playerManager;
    /// <summary>
    /// used to check if player is in contact with a ladder
    /// </summary>
    public bool climbingLadder { private set; get; }
    /// <summary>
    /// rate the player climbs up ladders
    /// </summary>
    [SerializeField] public int climbingLadderSpeed;
    /// <summary>
    /// sets the above variables to default values
    /// </summary>
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        climbingLadder = false;
        climbingLadderSpeed = 4;
    }

    /// <summary>
    /// called when player triggers ladder collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("On ladder");
            climbingLadder = true;
        }
    }
    /// <summary>
    /// called when player leaves ladder collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("Off ladder");
            climbingLadder = false;
        }
    }

    /// <summary>
    /// changes movement variable when player is climbing ladder, else movement does not change
    /// </summary>
    /// <param name="movement"></param>
    /// <returns></returns>
    public Vector3 HandleLadderMovement(Vector3 movement)
    {
        //Debug.Log(movement.x);
        if (climbingLadder)
        {
            Debug.Log("playerInputManager.move:" + playerManager.playerInputManager.move);
            // going down
            if (playerManager.playerInputManager.move.y < 0)
            {
                movement.y = -1 * climbingLadderSpeed * Time.deltaTime;
            }
            //if (movement.x < 0 && playerManager.playerGrounded.GroundedCheck())
            //{
            //    movement.y = -1 * climbingLadderSpeed * Time.deltaTime;
            //    movement.x = 0;
            //}
            // going up
            else if (playerManager.playerInputManager.move.y > 0) 
            {
                movement.y = climbingLadderSpeed * Time.deltaTime; 
            }
            // staying still
            else { movement.y = 0; }
        }
        return movement;
    }
}
