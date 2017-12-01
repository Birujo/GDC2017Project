using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Armour.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

[AddComponentMenu("GDC/Item/Armour")]
public class Armour : Equipment
{
    /* Public Variables */
    public float armourValue = 0; // Percentage based (0~1)
    public float armourHealth = 1; // Prevents armour disappearing instantly

    /* Getter and Setter */
    public float Value
    {
        get { return armourValue; }
        set { armourValue = value; }
    }
    public float Health
    {
        get { return armourHealth; }
        set { armourHealth = value; }
    }
}
