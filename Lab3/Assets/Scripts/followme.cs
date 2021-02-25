using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followme : MonoBehaviour
{


    private Rigidbody2D body;
    private float horizontal;
    private float runSpeed = 7f;
    public float moveLimiter = 2;
    public float jumpForce = 400f;
    private bool jumping;
    SpriteRenderer sr;
    private bool sliding;



    void Start()
    {
 
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sliding = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!sliding)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        } 


        if (horizontal <= 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }


        if (Input.GetKeyDown("space") && !jumping)
        {
            body.AddForce(new Vector2(0, jumpForce));
            jumping = true;
        }
        
    }
    private void FixedUpdate()
    {
        
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

    public void Slide(bool sliding)
    {
        this.sliding = sliding;
    }
}