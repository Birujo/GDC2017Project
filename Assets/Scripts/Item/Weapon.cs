using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Weapon.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

public class Weapon : Equipment
{
    /* Public Variables */
    public float attackValue = 0; // Attack damage value
    public float attackRange = 0; // How far can this weapon reach

    /* Getter and Setter */
    public float Value
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    public float Range
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
}
