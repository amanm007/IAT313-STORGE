using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector2 lastPosition;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;

        // Check if the enemy has moved horizontally
        if (currentPosition.x != lastPosition.x)
        {
            // Flip the sprite based on the direction of movement
            // If moving left (current position is less than last position), flipX is true
            spriteRenderer.flipX = currentPosition.x < lastPosition.x;
        }

        lastPosition = currentPosition;
    }
}

