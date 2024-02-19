using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpDrop : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float dist = 2.5f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float throwForce;
    bool isHolding = false;

    GameObject gameobj;

    private void OnEnable()
    {
        if(!TryGetComponent(out PlayerInput pInput)) return;

        InputAction pickupAction = pInput.actions.FindAction("PickUpDrop");
        InputAction throwAction = pInput.actions.FindAction("Throw");

        if (pickupAction != null) pickupAction.performed += OnInteraction;
        if (throwAction != null) throwAction.performed += OnThrow;
    }

    private void OnDisable()
    {
        if(!TryGetComponent(out PlayerInput pInput)) return;

        InputAction pickupAction = pInput.actions.FindAction("PickUpDrop");
        InputAction throwAction = pInput.actions.FindAction("Throw");

        if (pickupAction != null) pickupAction.performed -= OnInteraction;
        if (throwAction != null) pickupAction.performed -= OnThrow;
    }

    void Update()
    {
        if (isHolding) OnPickUp();
    }

    public void OnInteraction(InputAction.CallbackContext cxt)
    {
        isHolding = !isHolding;
        if(!isHolding && gameobj.TryGetComponent(out Rigidbody rb)) rb.isKinematic = false;
    }
    
    public void OnPickUp()
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

    public void OnThrow(InputAction.CallbackContext cxt)
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
