using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * HealthStation.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/World/Health Station")]
public class HealthStation : CheckPoint
{
    /* Public Variables */
    public int health = 0; // Amount of health this HS will give to player
    public int healthCount = 1; // How many times can this station give health to player

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
    }

    /* Functions */
    public void Heal(Character target)
    {
        // Give heal to target
        // Decrement 1 from healthCount
    }

    public override void DestoryObject()
    {
        // Don't destory HS
    }
}
