using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * WorldObjects.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 17
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

public class WorldObjects : MonoBehaviour
{
    /* Public Varibles */
    public Vector2 objectPosition; // This position will be applied to GameObject on the Awake() call
    public bool isDestructible = false; // Is this world object destructible?

    /* Private Variables */
    private Animator obj_animator; // For controlling world object's animation
    private Animation obj_animation; // Current animation playing

    /* Unity Functions */
    public virtual void Awake()
    {
        obj_animator = this.gameObject.GetComponent<Animator>();
        obj_animation = this.gameObject.GetComponent<Animation>();

        this.transform.position = objectPosition;
    }

    public virtual void Start() { }
    public virtual void FixedUpdate() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }

    public virtual void OnTriggerEnter2D(Collider2D collider) { }
    public virtual void OnTriggerStay2D(Collider2D collider) { }
    public virtual void OnTriggerExit2D(Collider2D collider) { }

    /* Functions */
    public virtual void DestoryObject() // Override this function if world object shouldn't be destoryed
    {
        // Play destruction animation

        Destroy(this.gameObject); // Destory current object
    }
}
