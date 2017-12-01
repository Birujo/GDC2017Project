using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject projectile;
	public float speed = 10f;

	void FireProjectile()
	{
		Debug.Log ("Firing");
		GameObject projectileClone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
		//projectileClone.velocity = Transform.TransformDirection(Vector2.forward * 10);
	}

	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			FireProjectile();
		}
	}

}
