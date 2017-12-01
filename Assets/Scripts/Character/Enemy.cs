using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 23
 * 
 */

[AddComponentMenu("GDC/Character/Enemy")]
public class Enemy : NPCharacter
{
    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
        Chartype = CharType.ENEMY; // Set self as enemy
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if(!IsTriggered && InDetectionRange(collision.transform))
        {
            // Player First, then NPC
            if (collision.gameObject.tag.Equals("Player"))
            {
                IsTriggered = true;
                FollowTarget = collision.gameObject;
                AttackTarget = collision.gameObject;
            }
            else if (collision.gameObject.tag.Equals("Neutral"))
            {
                isTriggered = true;
                FollowTarget = collision.gameObject;
                AttackTarget = collision.gameObject;
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Neutral"))
        {
            IsTriggered = false;
            FollowTarget = null;
            AttackTarget = null;
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            IsTriggered = false;
            FollowTarget = null;
            AttackTarget = null;
        }
    }

    /* Functions */
}
