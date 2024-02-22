using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpDrop : MonoBehaviour
{
    PlayerManager playerManager;
    GameObject cam;
    [SerializeField] private float dist = 2.5f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float throwForce;
    bool isHolding = false;

    GameObject gameobj;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        cam = Camera.main.gameObject;
    }

    void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onPickUp += OnItemInteract;
        GameEventsManager.Instance.playerEvents.onThrow += OnThrow;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onPickUp -= OnItemInteract;
        GameEventsManager.Instance.playerEvents.onThrow -= OnThrow;
    }

    void Update()
    {
        if (isHolding) HoldItem();
    }

    public void OnItemInteract()
    {
        isHolding = playerManager.playerInputManager.isHolding;
        Debug.Log(isHolding);
        if (gameobj != null && gameobj.TryGetComponent(out Rigidbody rb))
        {
            if(isHolding)
                rb.isKinematic = !isHolding;
            else
            {
                rb.isKinematic = isHolding;
                gameobj = null;
            }
        }
    }


    public void HoldItem()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, dist, mask))
        {
            gameobj = hitInfo.collider.gameObject;
            if (hitInfo.collider.tag == "Recycling"
                || hitInfo.collider.tag == "Metal"
                || hitInfo.collider.tag == "Glass"
                || hitInfo.collider.tag == "Plastic")
            {
                hitInfo.transform.position = cam.transform.position + cam.transform.forward; // place object in front of camera
                gameobj.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    public void OnThrow()
    {
        if (gameobj != null && gameobj.TryGetComponent(out Rigidbody rb))
        {
            rb.isKinematic = false;
            rb.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
            gameobj = null;
            isHolding = false;
        }
    }
}
