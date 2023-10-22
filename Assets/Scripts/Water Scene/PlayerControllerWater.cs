using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerWater : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float movementSpeedModifier;
    [SerializeField] float sprintModifier;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float gravity;
    [SerializeField] float constForward;


    [Header("Object Referenes")]
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;
    [SerializeField] ConstantForce cf;


    float turnSmoothVelocity;
    Vector2 move;
    bool grounded;
    bool glide;


    //Input Related
    private InputAction sprint;

    private void Awake()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        sprint = playerInput.actions["Sprint"];
        sprint.performed += EnableSprint;
        sprint.canceled += EnableSprint;
  

    }

    private void Update()
    {
        //get and use player movement
        move = playerInput.actions["Movement"].ReadValue<Vector2>() * movementSpeedModifier;
        cf.relativeForce = new Vector3(0f, 0f, constForward);
        cf.relativeForce = cf.relativeForce + new Vector3((move.x*2), 0f, move.y);



        animator.SetBool("Jump", !grounded);

        //jump
        if (playerInput.actions["Jump"].triggered)
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpMultiplier);
                
            }
        }

        if (playerInput.actions["Attack"].triggered)
        {
            print("started atacj");
            StartCoroutine(AttackSequence());
            //animator.Play("slash");
        }




        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Horizontal", move.x);
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
   
    private void EnableSprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            movementSpeedModifier *= 2;
            //stamina logic? 
        }
        if(context.canceled)
        {
            movementSpeedModifier /= 2;
        }
    }


    IEnumerator AttackSequence()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        
    }
}
