using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerMovementController.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 17
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 17
 * 
 * Player movement controller for left, right, and jump
 * 
 */
[AddComponentMenu("GDC/Scripts/Player Movement Controller.cs")]
public class PlayerMovementController : MonoBehaviour
{
    /* Public variables */
    [Range(1.0f, 50.0f)]
    public float velocity = 1.0f;

    /* Private variables */
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private bool isFacingRight = true;

    private void Awake()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void UpdateHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 vel = Vector2.right * velocity * horizontal; /* (1, 0) * velocity * +/-1 */
        vel.y += body.velocity.y; /* Let gravity handle the vertical speed */

        /* If input is negative and player is facing right, flip the sprite */
        if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
        /* If input is positive and player is facing left, flip the sprite */
        else if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        body.velocity = vel; /* Set velocity of player */
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; /* Invert boolean */
        Vector3 scale = this.transform.localScale; /* Grab local scale vector */

        scale.x *= -1; /* Flip x scale to invert player position */
        this.transform.localScale = scale; /* Apply scale */
    }

    /* Since we are using velocity to control plyaer, we do our input update in FixedUpdate() */
    private void FixedUpdate()
    {
        UpdateHorizontal();
    }
}
