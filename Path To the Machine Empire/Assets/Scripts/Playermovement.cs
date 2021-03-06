﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed;
    public float ladderspeed;
    public string startpoint;
    public float Jumppower;
    public float dashDistance;
    private bool facingRight;
    private static bool PlayerExist;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private float inputVertical;
    private bool inladder;
    private bool grounded;
    private SpriteRenderer PlayerSpriteRenderer;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(transform.gameObject);
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            inputHorizontal = Input.GetAxis("Horizontal");
            movement = new Vector2(inputHorizontal * speed, rb.velocity.y);
        
        rb.velocity = movement;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (inputHorizontal <= 0.05f)
            {
                Debug.Log("teleportleft");
                rb.velocity = new Vector2(-dashDistance, rb.velocity.y);

            }

            if (inputHorizontal >= 0.05f)
            {
                Debug.Log("teleportRight");
                rb.velocity = new Vector2(dashDistance, rb.velocity.y);
               
            }
        }


        if (Input.GetKeyDown("space") && grounded == true)
        {
            rb.AddForce(new Vector2(0, Jumppower), ForceMode2D.Impulse);

        }

        //Flip Sprite___________________________________________________________________
        if (inputHorizontal < 0)
        {
            facingRight = false;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
            PlayerSpriteRenderer.flipX = true;
        }

        if (inputHorizontal > 0)
        {
            facingRight = true;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
            PlayerSpriteRenderer.flipX = false;
        }


        //Ladder Code____________________________________________________________________
        if (inladder == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, ladderspeed);
                rb.gravityScale = 0;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0, -ladderspeed);
            }
        }

        if (inladder == false)
        {
            rb.gravityScale = 5;

        }

    }
    void Dash()
    {
        
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            inladder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            inladder = false;
        }
    }
}
