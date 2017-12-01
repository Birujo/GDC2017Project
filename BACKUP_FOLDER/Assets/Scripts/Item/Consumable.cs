using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Consumable.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

[AddComponentMenu("GDC/Item/Consumable")]
public class Consumable : Item
{
    /* Public Variables */
    public int quantity = 1; // Prevents items disappearing instantly
    public float healthValue = 0; // How much health will this item give

    /* Getter and Setter */
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    public float HealthVal
    {
        get { return healthValue; }
        set { healthValue = value; }
    }
}
