using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Platform.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/World/Stationary Platform")]
public class Platform : WorldObjects
{
    /* Public Variables */
    public Condition surfaceCondition = Condition.NONE; // Surface condition of this platform

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
    }

    /* Functions */
    public override void DestoryObject()
    {
        // Don't call parent function!
    }
}

public enum Condition
{
    NONE,
    WET,
    ICY
}