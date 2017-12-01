using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Character.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 27
 * 
 */

public class Character : MonoBehaviour
{
    /* Public Variables */
    public bool invulnerable = false; //  Is character invulnerable

    public GameObject gameobject; // Character's game object info

    public Animation char_animation; // Character's animation info
    public Animator char_animator; // Character's animator info

    public Rigidbody2D body; // To apply movements

    public AudioClip[] soundclips; // To play sounds for character

    public Item curr_item = null; // Character's weapon

    public float health = 1; //  Place holder value
    public float horizontalSpeed = 1; //  Place holder value
    public float verticalSpeed = 1; //  For jump; it is named as speed but it really is a force; just keeping the naming streamlined.

    public string charName = "Character"; //  Character name

    /* Private Variables */
    private Armour armour = null; //  Place holder value

    private Vector2 spawnLocation = new Vector2(0, 0); //  Spawn location tracking

    private List<Status> status_resist = new List<Status>(); //  For any status character is resisting
    private List<Status> status_affect = new List<Status>(); //  For any status character is affected

    private CharType chartype = CharType.NONE; //  Character type

    private bool inAir = false; // For ground check

    private float curr_speed_h; // Current horizontal speed

    private DefaultCharSound curraudio = DefaultCharSound.NONE; // To check if we need to play any sound

    private AudioSource audiosource; // To play our sound

    /* Getter and Setters */
    public Armour Armour
    {
        get { return armour; }
        set { armour = value; }
    }

    public Vector2 Spawn_Loc
    {
        get { return spawnLocation; }
        set { spawnLocation = value; }
    }

    public Item Equipped
    {
        get { return curr_item; }
        set { curr_item = value; }
    }

    public string Name
    {
        get { return charName; }
        set { charName = value; }
    }

    public bool InAir
    {
        get { return inAir; }
        set { inAir = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float H_CurrSpeed
    {
        get { return curr_speed_h; }
        set { curr_speed_h = value; }
    }

    // For others, Horizontal and Vertical speeds are read-only. If they want to change direction/speed, they need to use H_CurrSpeed
    public float H_Speed
    {
        get { return horizontalSpeed; }
    }
    public float V_Speed
    {
        get { return verticalSpeed; }
    }

    public CharType Chartype
    {
        get { return chartype; }
        set { chartype = value; }
    }

    public DefaultCharSound CurrAudio
    {
        get { return curraudio; }
        set { curraudio = value; }
    }

    /* Unity Functions */
    public virtual void Awake() // Note that it is protected. We only want to override our Awake call from inherited classes
    {
        // All characters should have rigidbody component.
        body = this.GetComponent<Rigidbody2D>();
        if (body == null) // If body happens to be a null, add rigidbody component to this character
        {
            gameObject.AddComponent<Rigidbody2D>();
            body = GetComponent<Rigidbody2D>();
        }
        char_animator = this.GetComponent<Animator>();

        audiosource = GetComponent<AudioSource>(); // Whatever game object that has Character class, it SHOULD have AudioSource to play clips.
        if(audiosource == null) // But if we forgot to put AudioSource to our GO, then we will add one
        {
            gameObject.AddComponent<AudioSource>();
            audiosource = GetComponent<AudioSource>();
        }
    }

    public virtual void Start() { }
    public virtual void FixedUpdate() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }

    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            InAir = false;
        }
        else if(collision.gameObject.tag.Equals("KinPlatform"))
        {
            InAir = false;
        }
    }
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            if (!InAir)
                InAir = true;
        }
        else if (collision.gameObject.tag.Equals("KinPlatform"))
        {
            if (!InAir)
                InAir = true;
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision) { }
    public virtual void OnTriggerStay2D(Collider2D collision) { }
    public virtual void OnTriggerExit2D(Collider2D collision) { }

    /* Functions */
    public bool HasResistStatus(Status target) { return status_resist.Contains(target); } // If list contains enum value, it will return true, otherwise returns false
    public bool HasAffectStatus(Status target) { return status_affect.Contains(target); } // If list contains enum value, it will return true, otherwise returns false
    public bool AddResistStatus(Status target)
    {
        if (HasResistStatus(target)) return false; // If status is already in the list, don't add. (return false)
        else status_resist.Add(target); // Otherwise add the new status to list and return true.
        return true;
    }
    public bool AddAffectStatus(Status target)
    {
        if (HasAffectStatus(target)) return false; // If status is already in the list, don't add (return false)
        else status_affect.Add(target); // Otherwise add the new status to list and return true.
        return true;
    }

    public virtual void Kill()
    {
        // Play death animation (Not shown)
        audiosource.clip = soundclips[(int)DefaultCharSound.DEATH]; // Also play sound if applicable

        if(!char_animation.isPlaying) // If death animation stops playing, destory object
            Destroy(gameobject);
    }

    public virtual void Damage(Character attacker)
    {
        if (attacker.Equipped != null) // Is this filthy attacker having weapon?
            if (attacker.Equipped is Weapon) // Yes
            {
                Debug.Log("Attacker: " + attacker.Name + " Defender: " + this.Name);
                Weapon p = attacker.Equipped as Weapon; // Get Weapon
                float dmg = p.Value; // Get Weapon's damage

                if(Armour != null) // Time to check if character is wearing an armour
                {
                    float dmg_ignored = Armour.Value * dmg; // Damage ignored by armour
                    Armour.Health = Armour.Health - dmg_ignored; // Degrade Armour
                    Health = Health - (dmg - dmg_ignored); // Apply reduced damage to health
                }
                else // Otherwise get 100% damage
                {
                    Health = Health - dmg;
                }

                if(p.Effect != Status.NONE) // Also need to check if attacker's weapon has any status effect
                {
                    if (!HasResistStatus(p.Effect)) // Is this character NOT resist to following weapon's status effect?
                        AddAffectStatus(p.Effect); // Then add new affect status to character.
                }

                //if (audiosource.isPlaying) audiosource.Stop(); // Make sure audio source is not playing

                //audiosource.clip = soundclips[(int)DefaultCharSound.DAMAGE];
                //audiosource.Play(); // Play damage sound
            }
    }

    public virtual void Attack(Character target)
    {
        if (!target.invulnerable) // Is target character invulnerable?
        {
            target.Damage(this); // Character attacking should have all the data needed for target Character to process damage.

            // Play attack animation

            //if (audiosource.isPlaying) audiosource.Stop(); // Make sure audio source is not playing

            //audiosource.clip = soundclips[(int)DefaultCharSound.ATTACK];
            //audiosource.Play(); // Play attack sound
        }
    }

    public virtual void Jump() // Didn't add grounded check since player need double jump
    {
        body.AddForce(new Vector2(0, V_Speed)); // Jump!
    }

    public virtual void Move()
    {
        Vector2 vel = new Vector2(H_CurrSpeed, body.velocity.y); // Update velocity profile

        body.velocity = vel; // Set velocity to our character
    }
}

/* Enums */
public enum Status
{
    BLEED,
    BURN,
    POISON,
    NONE
}

public enum CharType
{
    PLAYER,
    ENEMY,
    NPC,
    NONE
}

/* 
 * How to use 
 * 
 * When saving AudioClips to array, make sure first three is death, attack, and block. From there, custom AudioClips can be
 * stored array index 3...
 * If no sound is needed, set curraudio variable to NONE, that way no sound is played.
 * 
 */
public enum DefaultCharSound : int
{
    DEATH = 0,
    ATTACK = 1,
    DAMAGE = 2,
    NONE = -1
}