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
 */

[AddComponentMenu("GDC/World/Moving Platform")]
public class MovingPlatform : Platform
{
    /* Public Variables */
    public float delay = 1; // How much time will this platform wait before moving to next position

    public int speedX = 1; // Horizontal speed
    public int speedY = 1; // Vertical speed

    public bool moveHorizontal = false; // Does this platform move in horizontal direction?
    public bool moveVertical = false; // Does this platform move in vertical direction?

    public Vector2[] positions; // To store positions for moving platform

    /* Private Variables */
    private int curr_position = 0; // Current position
    private int direction = 1; // Moving to next position

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        MoveObject();
    }

    /* Functions */
    public void MoveObject()
    {
        if (curr_position + direction >= positions.Length || curr_position + direction < 0) direction *= -1; // If next position is out of bound, change direction
        curr_position += direction; // Set next waypoint
    }

    public override void DestoryObject()
    {
        // Don't call parent function!
    }
}
