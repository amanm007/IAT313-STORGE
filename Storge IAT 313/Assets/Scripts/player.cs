using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float walkSpeed = 20.0f;
    private const float DiagonalMoveLimiter = 0.7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");


        if (horizontalMove != 0 && verticalMove != 0)
        {
            horizontalMove *= DiagonalMoveLimiter;
            verticalMove *= DiagonalMoveLimiter;
        }

        rb.velocity = new Vector2(horizontalMove * walkSpeed, verticalMove * walkSpeed);

        UpdateAnimationState(horizontalMove, verticalMove);
    }

    private void UpdateAnimationState(float horizontalMove, float verticalMove)
    {
        bool isWalking = horizontalMove != 0 || verticalMove != 0;
        animator.SetBool("walking", isWalking);

        if (isWalking)
        {
            spriteRenderer.flipX = horizontalMove < 0;
        }
    }
}
