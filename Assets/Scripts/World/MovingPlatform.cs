using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MovingPlatform.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 * NOTE: RIGIDBODY BASED VERSION!
 */

[AddComponentMenu("GDC/World/Moving Platform")]
public class MovingPlatform : Platform
{
    /* Public Variables */
    public float delay = 1; // How much time will this platform wait before moving to next position
    public float threshold = 0.1f; // How far will platform move?

    public float speedX = 1; // Horizontal speed
    public float speedY = 1; // Vertical speed

    public bool moveHorizontal = false; // Does this platform move in horizontal direction?
    public bool moveVertical = false; // Does this platform move in vertical direction?

    public Vector2[] positions; // To store positions for moving platform

    /* Private Variables */
    private float timer; // For delay

    private int curr_position = 0; // Current position
    private int direction = 1; // Moving to next position

    private bool arrived = false; // To check if platform arrived at target position

    private Rigidbody2D body; // To add velocity

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
        body = this.GetComponent<Rigidbody2D>();
    }

    public override void Update()
    {
        if(arrived)
        {
            timer += Time.deltaTime;
            if(timer >= delay)
            {
                arrived = false;
                timer = 0;
            }
        }
    }

    public override void FixedUpdate()
    {
        // Force based; speed X and Y are used as velocity
        if(!arrived) // If we haven't arrived, move
            MoveObject();
    }

    /* Functions */
    public void MoveObject()
    {
        Vector2 nextPos = positions[curr_position]; // our current target
        Vector2 currPos = this.transform.position; // Get current position
        Vector2 dist = nextPos - currPos;

        float diffX = nextPos.x - currPos.x; // Get X difference
        float diffY = nextPos.y - currPos.y; // Get Y difference

        float velX = 0; // X axis velocity
        float velY = 0; // Y axis velocity

        if (dist.magnitude <= threshold) // Have we arrived?
        {
            body.velocity = new Vector2(0, 0); // Stop first

            if (curr_position + direction >= positions.Length || curr_position + direction < 0) direction *= -1; // If next position is out of bound, change direction
            curr_position += direction; // Set next waypoint
            arrived = true; // We have arrived!
        }
        else // If not, move
        {
            if((diffX > 0 || diffX < 0) && moveHorizontal) // Can we move in X axis?
                velX = diffX > 0 ? speedX : -speedX;
            if ((diffY > 0 || diffY < 0) && moveVertical) // Can we move in Y axis?
                velY = diffY > 0 ? speedY : -speedY;

            Vector2 velocity = new Vector2(velX, velY);
            body.MovePosition(currPos + (velocity * Time.fixedDeltaTime));
        }
    }

    public override void DestoryObject()
    {
        // Don't call parent function!
    }
}
