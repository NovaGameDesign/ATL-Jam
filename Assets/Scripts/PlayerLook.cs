using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    float mouseSens = 100f;
    Vector2 mouseLook;
    float xRotation = 0f;

    Transform playerBody;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    private void Update()
    {
        //gets input from the mouse
        mouseLook = playerInput.actions["Mouse"].ReadValue<Vector2>();
        float mouseX = mouseLook.x * mouseSens * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSens * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //applies mouse movement
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        
    }


}

