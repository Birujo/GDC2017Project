using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Item.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

public class Item : MonoBehaviour
{
    /* public variables */
    public string itemName = "An Item";
    public string itemDesc = "An Item";

    public int scrapValue = 0; // No scrap value
    public Status statusEffect = Status.NONE; // No status effect

    /* Getter and Setter for private variables */
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    public string ItemDesc
    {
        get { return itemDesc; }
        set { itemDesc = value; }
    }

    public int ScrapValue
    {
        get { return scrapValue; }
        set { scrapValue = value; }
    }

    public Status Effect
    {
        get { return statusEffect; }
        set { statusEffect = value; }
    }
}
