using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMove : MonoBehaviour{

public Rigidbody2D rb2D;


public float moveSpeed, jumpForce;

public Transform groundPoint;
public LayerMask whatIsGround;

private bool IsGrounded;

private bool playerFacingRight = true;
private bool playerFacingLeft = false;

private float inputx;

public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player
        //rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);

        rb2D.velocity = new Vector2(inputx * moveSpeed, rb2D.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));

        //check if on the ground
        IsGrounded = Physics2D.OverlapCircle(groundPoint.position, .5f, whatIsGround);
        if (IsGrounded){
            anim.SetBool("IsJumping", false);
        }
        //Jump the player
        /*if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }*/




        //flip the player
        if (rb2D.velocity.x > 0f)
         {
         transform.localScale = new Vector3(4f, 4f, 1f);
         }
        else if (rb2D.velocity.x < 0f) 
        {
         transform.localScale = new Vector3(-4f, 4f, 1f);
   }


    }

	public void Move(InputAction.CallbackContext context)
    {
        inputx = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded)
        {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }

        anim.SetBool("IsJumping", true);
    }




}
