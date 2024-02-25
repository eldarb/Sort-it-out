using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    public Transform playerTransform;
    public float interactionRange = 2.0f;
    public bool isOpen = false;
    public float openAngle = 90.0f;
    public float openSpeed = 2.0f;
    public KeyCode interactionKey = KeyCode.E;

    private Vector3 closedRotation;
    private Vector3 openRotation;

    void Start()
    {
        closedRotation = transform.eulerAngles;
        openRotation = new Vector3(closedRotation.x, closedRotation.y + openAngle, closedRotation.z);
    }

    void Update()
    {
        // Check if the player is within interaction range and presses the interaction key
        if (Vector3.Distance(playerTransform.position, transform.position) < interactionRange && Input.GetKeyDown(interactionKey))
        {
            ToggleDoor();
        }

        if (isOpen)
        {
            // Open door
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            // Close door
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, closedRotation, Time.deltaTime * openSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }
}
