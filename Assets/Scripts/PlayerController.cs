using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float movementSpeedModifier;
    [SerializeField] float jumpMultiplier;


    [Header("Object Referenes")]
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody rb;


    float turnSmoothVelocity;
    Vector2 move;
    bool grounded;
    bool glide;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get and use player movement
        if (!glide)
        {
            move = playerInput.actions["Movement"].ReadValue<Vector2>() * movementSpeedModifier;
            transform.Translate(move.x * Time.deltaTime, 0, move.y * Time.deltaTime);
        }

        //jump
        if (playerInput.actions["Jump"].triggered)
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpMultiplier);
            }
        }

        //glide movement for air level
        if (glide)
        {
            if (grounded)
            {
                glide = false;
            }
            else
            {
                move = playerInput.actions["Movement"].ReadValue<Vector2>() * movementSpeedModifier;
                Vector3 t_pos = rb.position + (transform.forward * move.y * (movementSpeedModifier/2) * Time.deltaTime) + (transform.right * move.x * (movementSpeedModifier/2) * Time.deltaTime);
                Vector3 lerp_pos = Vector3.Lerp(rb.position, t_pos, 0.2f);

                rb.MovePosition(lerp_pos);
            }
        }

    }

    //tells the code if the player is touching the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = true;
        }
    }

    //tells the code if the player is not on the ground
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = false;
        }
    }

    public void EnableGlide()
    {
        glide = true;
    }




}
