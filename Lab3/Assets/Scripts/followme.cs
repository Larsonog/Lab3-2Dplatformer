using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followme : MonoBehaviour
{

    
    private Rigidbody2D body;
    private float horizontal;
    private float vertical;
    private float runSpeed = 7f;
    public float moveLimiter = .7f;
    public float jumpForce = 400f;
    private bool jumping;
    SpriteRenderer sr;
    private bool flying;
    public GameObject trail;




    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        flying = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        horizontal = Input.GetAxisRaw("Horizontal");

        if (flying)
        {
            vertical = Input.GetAxisRaw("Vertical");
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
        if (flying)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

    public void Fly(bool flying)
    {
        this.flying = flying;
        if (flying)
        {
            trail.GetComponent<TrailRenderer>().emitting = true;
            
        } if (!flying)
        {
            trail.GetComponent<TrailRenderer>().emitting = false;
        }
    }

    
} 