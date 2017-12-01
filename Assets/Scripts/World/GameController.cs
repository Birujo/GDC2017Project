using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GameController.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

public class GameController : MonoBehaviour
{
    /* Private Variables */
    private GameObject player; // To save player's data

    /* Unity Functions */
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
