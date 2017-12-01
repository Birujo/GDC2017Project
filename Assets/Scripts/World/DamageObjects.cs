using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DamageObjects.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/World/Destructible Object")]
public class DamageObjects : WorldObjects
{
    /* Public Variables */
    public int healthValue = 0; // How much health does this damage object has

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
    }

    /* Functions */
    public void Damage(int amount)
    {
        // Remove health value as amount
        if (healthValue <= 0) DestoryObject(); // If health value is less than or equal to 0, destory object
    }
}
