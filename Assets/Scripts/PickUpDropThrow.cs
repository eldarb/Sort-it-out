using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDropThrow : MonoBehaviour
{
    GameObject cam;
    [SerializeField] private float dist = 2.5f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float throwForce = 10;
    PlayerInventory inventory;
    PowerGauge powerGauge;

    public float recoilPower { private set; get; }
    public bool recoiling {private set; get;}
    public float recoilStartTime { private set; get; }
    [SerializeField] float recoilThreshold = 0.4f;
    [SerializeField] float recoilStrength = 10;
    void Start()
    {
        cam = Camera.main.gameObject;
        inventory = GetComponent<PlayerInventory>();
        powerGauge = GetComponentInChildren<PowerGauge>();
    }

    // void OnEnable()
    // {
    //     GameEventsManager.Instance.playerEvents.onPickUp += OnPickUp;
    //     //GameEventsManager.Instance.playerEvents.onThrow += OnThrow;
    // }

    // void OnDisable()
    // {
    //     GameEventsManager.Instance.playerEvents.onPickUp -= OnPickUp;
    //     //GameEventsManager.Instance.playerEvents.onThrow -= OnThrow;
    // }

    public void OnPickUp()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, dist, mask))
        {
            Debug.Log("Raycast made a Hit");
            GameObject gameobj = hitInfo.collider.gameObject;
            if (gameobj.CompareTag("Recycling")
                || gameobj.CompareTag("Metal")
                || gameobj.CompareTag("Glass")
                || gameobj.CompareTag("Plastic"))
            {
                gameobj.transform.position = cam.transform.position + cam.transform.forward;
                if (!inventory.CheckFull())
                {
                    Debug.Log("Inventory is not full");
                    gameobj.SetActive(false);
                    inventory.OnCollect(gameobj);
                }
            }
        }
    }

    public void OnThrow()
    {
        Debug.Log("Throw called");
        GameObject heldObject = inventory.OnRelease();
        if (heldObject != null)
        {
            heldObject.transform.position = cam.transform.position + cam.transform.forward;
            heldObject.SetActive(true);
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                if(powerGauge != null)
                {
                    rb.AddForce(cam.transform.forward * throwForce * rb.mass * powerGauge.slider.value, ForceMode.Impulse);
                    recoiling = true;
                    recoilPower = powerGauge.slider.value;
                    recoilStartTime = Time.time;
                }
                else
                {
                    rb.AddForce(cam.transform.forward * throwForce * rb.mass, ForceMode.Impulse);
                }
                
                Debug.Log("Object Thrown");
            }
        }
    }        
    public Vector3 recoil(Vector3 movement)
        {
            if(recoilPower < powerGauge.slider.maxValue * recoilThreshold) { return movement; }
            Vector3 recoilDir = (-1 * transform.forward) * recoilPower * recoilStrength * Time.deltaTime;
            if (Time.time - recoilStartTime > .2f) { recoiling = false; return movement; }
            else
            {
                //Debug.Log("Recoiling");
                return movement + recoilDir;
            }

        }
}