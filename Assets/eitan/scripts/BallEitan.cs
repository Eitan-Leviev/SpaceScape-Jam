using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEitan : MonoBehaviour
{
    private GameObject dir;
    private Rigidbody2D rb;
    public float initSpeed = 10;
    public float speed = 1;
    private float x = 0;
    private bool moving = false;
    private Vector2 previousVelocity;

    private void Awake()
    {
        dir = transform.Find("direction").gameObject;
        rb = GetComponent<Rigidbody2D>();
        previousVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        previousVelocity = rb.velocity;

        // hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit();
        }

        if (moving)
        {
            // add to x
            x += Time.deltaTime * speed;
            var y = SlowDownFunc(x);
            // slow down ball
            if (y <= 0)
            {
                print("stop moving");
                rb.velocity = Vector2.zero;
                moving = false;
                x = 0;
            }
            else
            {
                rb.velocity = rb.velocity.normalized * (float) y;
            }
        }
    }

    private void Hit()
    {
        // get direction
        var velocity = Vector2.left;
        // Vector3 velocity = Arrow.GetDirection();
        // give initial velocity
        rb.velocity = velocity * initSpeed;
        moving = true;
    }

    private double SlowDownFunc(float x)
    {
        return -0.01 * Math.Pow(x, 2) + initSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        ContactPoint2D contact = other.contacts[0];

        Vector2 contactNormal = contact.normal;

        Vector2 newVelocity = Vector2.Reflect(previousVelocity, contactNormal);
        print(previousVelocity);
        print(newVelocity);

        rb.velocity = newVelocity;
        
        previousVelocity = newVelocity;
    }
}
