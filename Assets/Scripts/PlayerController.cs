using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float movementSpeedModifier;
    [SerializeField] float sprintModifier;
    [SerializeField] float jumpMultiplier;


    [Header("Object Referenes")]
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator animator;


    float turnSmoothVelocity;
    Vector2 move;
    bool grounded;
    Transform groundHit;
    bool glide;
    bool isSprint;


    //Input Related
    private InputAction sprint;

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        sprint = playerInput.actions["Sprint"];
        sprint.performed += EnableSprint;
        sprint.canceled += EnableSprint;
        
        isSprint = false;

    }

    private void Update()
    {
       
        grounded = GroundCheck();
        Debug.Log("The player is: " + grounded);
        //get and use player movement
        if (!glide)
        {
            move = playerInput.actions["Movement"].ReadValue<Vector2>() * movementSpeedModifier;
            transform.Translate(move.x * Time.deltaTime, 0, move.y * Time.deltaTime);
        }


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
                Vector3 t_pos = new Vector3(0,0,0);
                if (!isSprint)
                { t_pos = rb.position + (transform.forward * move.y * (movementSpeedModifier / 2) * Time.deltaTime) + (transform.right * move.x * (movementSpeedModifier / 2) * Time.deltaTime); }
                if (isSprint)
                { t_pos = rb.position + (transform.forward * move.y * (movementSpeedModifier / 4) * Time.deltaTime) + (transform.right * move.x * (movementSpeedModifier / 4) * Time.deltaTime); }
                Vector3 lerp_pos = Vector3.Lerp(rb.position, t_pos, 0.2f);

                rb.MovePosition(lerp_pos);
            }
        }




        animator.SetFloat("Vertical", move.y);
        animator.SetFloat("Horizontal", move.x);
    }

    //tells the code if the player is touching the ground
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = true;
        }
    }*/

    //tells the code if the player is not on the ground
    /*/private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            grounded = false;
        }
    }*/
   
    private void EnableSprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            movementSpeedModifier *= 2;
            isSprint = true;
            //stamina logic? 
        }
        if(context.canceled)
        {
            movementSpeedModifier /= 2;
            isSprint = false;
        }
    }


    IEnumerator AttackSequence()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("Attack", false);
        
    }

    public void EnableGlide()
    {
        glide = true;
    }

    private bool GroundCheck()
    {
        //If the player is falling or jumping we set it so they are not grounded. 
        if (rb.velocity.y < -3 || rb.velocity.y > 2)
        {
            return false;
        }


        return Physics.Raycast(transform.position, -transform.up, .1f);
       
    }
}
