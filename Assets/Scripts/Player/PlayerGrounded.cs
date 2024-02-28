using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] float gravityForce;
    [SerializeField] float groundedRadius = 0.5f;
    [SerializeField] float groundedOffSet = 0.55f;
    [SerializeField] float jumpHeight;
    public bool isGrounded;
    [SerializeField] LayerMask groundedLayerMask;
    float yVelocity;
    float terminalVelocity = 53.0f;
    public float jumpTimeout = 0.1f;
    public float fallTimeout = 0.15f;

    private float jumpTimeoutDelta;
    private float fallTimeoutDelta;

    /// <summary>
    /// private AudioClip variable to hold the footsteps SFX.
    /// </summary>
    public AudioClip m_JumpingSFX;
    /// <summary>
    /// private AudioSource variable to hold the Player's AudioSource.
    /// </summary>
    private AudioSource m_AudioSource;

    private bool playedSound;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        jumpTimeoutDelta = jumpTimeout;
        fallTimeoutDelta = fallTimeout;
        m_AudioSource = GetComponent<AudioSource>();
        playedSound = false;
    }
    public void GroundedCheck()
    {
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - groundedOffSet, transform.position.z), groundedRadius, groundedLayerMask, QueryTriggerInteraction.Ignore);
        if (isGrounded)
        {
            fallTimeoutDelta = fallTimeout;

            if (yVelocity < 0.0f)
            {
                yVelocity = -2f;
            }

            if (playerManager.playerInputManager.isJumping && jumpTimeoutDelta <= 0.0f)
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
                if(!playedSound)
                {
                    m_AudioSource.PlayOneShot(m_JumpingSFX);
                    playedSound = true;
                    Debug.Log("Jump");
                }
                
            }

            if (jumpTimeoutDelta >= 0.0f)
            {
                jumpTimeoutDelta -= Time.deltaTime;
            }
        }
        else
        {
            jumpTimeoutDelta = jumpTimeout;

            if(fallTimeoutDelta >= 0.0f)
            {
                fallTimeoutDelta -= Time.deltaTime;
            }

            playerManager.playerInputManager.SetJump(false);
            playedSound = false;
        }

        if (yVelocity < terminalVelocity)
        {
            yVelocity += gravityForce * Time.deltaTime;
        }
        playerManager.movement.y = yVelocity * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundedOffSet, transform.position.z), groundedRadius);
    }
}
