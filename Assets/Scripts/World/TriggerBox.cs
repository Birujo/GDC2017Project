using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TriggerBox.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/World/Trigger Area")]
public class TriggerBox : WorldObjects
{
    /* Public Variables */
    public bool isInstantKill = false; // Sets if this trigger box does instant kill stuff
    public int damageApplied = 0; // Sets damage value if this trigger box is part of trap

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake(); // This will set the position of trigger box
    }

    public override void OnTriggerEnter2D(Collider2D collider) { }
    public override void OnTriggerStay2D(Collider2D collider) { }
    public override void OnTriggerExit2D(Collider2D collider) { }

    /* Functions */
}
