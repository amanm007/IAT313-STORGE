using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D body;

    float horizontalMove;
    float verticalMove;
    float diagonalMoveLimiter = 0.7f;

    public float walkSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontalMove = Input.GetAxisRaw("Horizontal"); // -1 is left
        verticalMove = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontalMove != 0 && verticalMove != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontalMove *= diagonalMoveLimiter;
            verticalMove *= diagonalMoveLimiter;
        }

        body.velocity = new Vector2(horizontalMove * walkSpeed, verticalMove * walkSpeed);
    }
}
