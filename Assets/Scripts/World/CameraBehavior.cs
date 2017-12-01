/*
 *CameraBehavior.cs
 * 
 * Created By: Connor Morris
 * Created On: 2017 Nov 16
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("GDC/World/CameraBehavior.cs")]
public class CameraBehavior : MonoBehaviour
{
    /* Public Variables */
    public GameObject player;

    /* Private Veriables */
    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
    {
        this.transform.position = player.transform.position + offset;
	}
}
