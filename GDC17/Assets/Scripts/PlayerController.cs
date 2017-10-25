/*
 * PlayerController.cs
 * 
 * Created By: Joseph Brewster
 * Created On: 2017 Oct 13
 * Last Edited By: Joseph Brewster
 * Last Edited On: 2017 Oct 13
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("GDC/Scripts/PlayerController.cs")]
public class PlayerController : MonoBehaviour {
    [Range(5.0f, 10.0f)]
    public float forceMove = 1.0f;
    public bool facingRight = true;

    private Rigidbody2D body;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        float force_horizontal = Input.GetAxis("Horizontal");
        float force_vertical = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(force_horizontal));

        if (force_horizontal > 0 && !facingRight)
            Flip();
        else if (force_horizontal < 0 && facingRight)
            Flip();
        
        Vector2 force = new Vector3(force_horizontal * forceMove,  force_vertical * forceMove);

        body.AddForce(force);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
