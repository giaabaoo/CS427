using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump_speed = 100f;

    float currentMoveSpeed;


    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    private bool pickUpAllowed;

    SpriteRenderer srenderer;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //move sang trai get key and srender.FlipX = false
        //anim.Play("Ten animation")

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jump_speed));
            currentMoveSpeed = rb.velocity.x;
            animator.SetBool("Is_Jumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("Is_Jumping", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("Is_Ducking", true);
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Is_Ducking", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Is_Holding_Gun", true);
        }

        else if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("Is_Holding_Gun", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bazooka"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bazooka"))
        {
            pickUpAllowed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("HighGrounds")){
            Debug.Log("Enter collider");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("HighGrounds")){

        }
    }




    void FixedUpdate()
    {
        rb.velocity = new Vector2(currentMoveSpeed, rb.velocity.y + jump_speed);
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //      currentMoveSpeed = 0;
    //      srenderer = GetComponent<SpriteRenderer>();
    //}
}
