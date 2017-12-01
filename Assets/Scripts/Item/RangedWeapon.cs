using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * RangedWeapon.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

[AddComponentMenu("GDC/Item/Ranged Weapon")]
public class RangedWeapon : Weapon
{
    /* Public Variables */
    public float firerate = 1; // Any value that is greater than zero will work. Lower the value, faster it fires
    public int ammoCount = 0; // Ammo available
    public AmmoType ammoType = AmmoType.NONE; // Ammo type

    /* Getter and Setter */
    public float Firerate
    {
        get { return firerate; }
        set { firerate = value; }
    }
    public int Ammo
    {
        get { return ammoCount; }
        set { ammoCount = value; }
    }
    public AmmoType Type
    {
        get { return ammoType; }
        set { ammoType = value; }
    }
}

public enum AmmoType
{
    ARROW,
    BULLET,
    NONE
}
