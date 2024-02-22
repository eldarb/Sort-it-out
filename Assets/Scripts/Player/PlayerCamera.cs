using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject cinemachineTarget;
    Vector2 look;
    float mouseX;
    float mouseY;
    [SerializeField] float verticalSensetivity;
    [SerializeField] float horizontalSensetivity;
    [SerializeField] float MaxAngle;
    [SerializeField] float MinAngle;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        CameraBehavior();
    }

    void CameraBehavior()
    {
        look = playerManager.playerInputManager.look;
        if(look.sqrMagnitude > 0.01f)
        {
            mouseX = look.x * horizontalSensetivity * Time.deltaTime;
            mouseY += look.y * verticalSensetivity * Time.deltaTime;
            mouseY = Mathf.Clamp(mouseY, MinAngle, MaxAngle);
            //vertical rotation
            cinemachineTarget.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
            //horizontal rotation
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
