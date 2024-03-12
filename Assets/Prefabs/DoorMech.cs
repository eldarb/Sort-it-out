using UnityEngine;
using TMPro;

public class DoorMechanic : MonoBehaviour
{
    public Transform playerTransform;
    public float interactionRange = 2.0f;
    public bool isOpen = false;
    public float openAngle = 90.0f;
    public float openSpeed = 2.0f;
    public KeyCode interactionKey = KeyCode.E;


    private TextMeshPro m_TextMeshPro;
    public int m_NumToUnlock = 0;
    private bool m_CanUnlock;

    private Vector3 closedRotation;
    private Vector3 openRotation;

    void Awake()
    {
        closedRotation = transform.eulerAngles;
        openRotation = new Vector3(closedRotation.x, closedRotation.y + openAngle, closedRotation.z);
        m_TextMeshPro = GameObject.Find("ItemsText").GetComponent<TextMeshPro>();
        m_CanUnlock = false;
    }

    void Update()
    {
        int m_CurrentItemCount = GameObject.Find("Recyclables").GetComponent<ItemCounter>().getItem();
        m_TextMeshPro.text = m_CurrentItemCount + " / " + m_NumToUnlock;

        if(m_CurrentItemCount >= m_NumToUnlock) { m_CanUnlock = true;}

        // Check if the player is within interaction range and presses the interaction key
        if (Vector3.Distance(playerTransform.position, transform.position) < interactionRange && Input.GetKeyDown(interactionKey) && m_CanUnlock)
        {
            ToggleDoor();
            transform.GetChild(3).gameObject.SetActive(false);
        }

        if (isOpen)
        {
            // Open door
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, openRotation, Time.deltaTime * openSpeed);
            if(transform.eulerAngles.y >= 359.0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 359.0f, transform.eulerAngles.z);
            }
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
