/*
 * HealthController.cs
 * 
 * Created By: Joshua Gibbs
 * Created On: November 31, 2017
 * Last Edited By: 
 * Last Edited On: 
 * 
 * This script manages a character's health, player, NPC or enemy. The armor value and max health can be changed in the inspector.
 * This script can also update a slider if one is linked in the inspector.
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
	[AddComponentMenu("GDC/Character/HealthController.cs")]

	public Slider healthSlider = null;
	public int maxHealth = 10;
	public int minHealth = 0;
	public int armor = 5;

	private int currentHealth;


	void Start ()
	{
		currentHealth = maxHealth;

		if (healthSlider != null)
			healthSlider.maxValue = currentHealth;
	}

	// This function returns true if the player did take damage after the damage reduction from armor. Otherwise, the function returns false.
	public bool applyDamage(int damageAmount)
	{
		// This line should be changed to the formula we decide to use for calculating how much damage armor absorbs.
		int damageAfterArmor = damageAmount - armor;

		if (damageAfterArmor <= 0)
		{
			return false;
		}
		else if (currentHealth - minHealth < damageAfterArmor)
		{
			currentHealth = minHealth;
			updateSlider ();
			return true;
		}
		else
		{
			currentHealth -= damageAfterArmor;
			updateSlider ();
			return true;
		}
	}

	// This function returns true if the player's health did increase. Otherwise, the function returns false.
	public bool applyHeal(int healAmount)
	{
		if (currentHealth == maxHealth)
		{
			return false;
		}
		else if (currentHealth + healAmount > maxHealth)
		{
			currentHealth = maxHealth;
			updateSlider ();
			return true;
		}
		else
		{
			currentHealth += healAmount;
			updateSlider ();
			return true;
		}
	}

	// This function is here to directly change the object's health without going through armor calculations or checking for max/min health bounds.
	// Warning: This could lead to unexpected behavior.
	public void changeHealth (int changeAmount)
	{
		currentHealth += changeAmount;
		updateSlider ();
	}

	// This function is solely for this script to update the associated slider if one is assigned.
	private void updateSlider ()
	{
		if (healthSlider != null)
			healthSlider.value = currentHealth;
	}
}
