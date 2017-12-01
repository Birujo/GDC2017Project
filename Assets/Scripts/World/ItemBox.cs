using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ItemBox.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/World/Item Box")]
public class ItemBox : WorldObjects
{
    /* Public Variables */
    public Item boxContent; // Sets content of item box

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnTriggerEnter2D(Collider2D collider) { }
    public override void OnTriggerStay2D(Collider2D collider) { }
    public override void OnTriggerExit2D(Collider2D collider) { }

    /* Fuctions */
    public override void DestoryObject()
    {
        // We don't want to destroy box so just keep it empty!
    }
    public void OpenBox()
    {
        // Change sprite to open sprite
        DestoryObject(); // Destory object
    }
}
