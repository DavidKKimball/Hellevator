using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntHealth : MonoBehaviour {

	public int gruntHealthMax = 100;
	public int gruntHealthCurrent;
	private int sawbladeDamage = 10;
	private int lavaDamage = 10;

	void Start () {
		//Checks for grunt Health maximum.
		//Important later for returning Health to grunt.
		//Debug.Log("Grunt Health max is: " + gruntHealthMax);

		//Sets grunt Health current to 100 at game start.
		gruntHealthCurrent = 100;
		//Checks that the Health is correct.
		//Debug.Log("Grunt Health current is: " + gruntHealthCurrent);
	}

	void Update () {

		//Tests for grunt death upon reaching 0 or less Health.
		if (gruntHealthCurrent <= 0) {
			gameObject.SetActive(false);
			Debug.Log("The grunt has died.");
		}
	}

//Checks for collision with hazards and does damage to grunt Health upon collision.
	public void OnCollisionEnter (Collision collision) {

		//If grunt touches hazard, grunt takes damage to Health.
		if (collision.gameObject.CompareTag("Sawblade")) {
			//Does Sawblade damage to the grunt.
			gruntHealthCurrent -= sawbladeDamage;
			//Checks for how much Health the grunt has left after taking damage.
			Debug.Log("Sawblade touched, the grunt has " + gruntHealthCurrent + " Health left.");
		} else if (collision.gameObject.CompareTag("Spikes")) {
			//Instantly kills the grunt.
			gruntHealthCurrent -= gruntHealthMax;
			Debug.Log("Spikes have crushed the grunt.");
		} else if (collision.gameObject.CompareTag("Lava")) {
			//Kills the grunt after touching the center of the Lava pool.
			gruntHealthCurrent -= gruntHealthMax;
			Debug.Log("Lava has burned the grunt to ash.");
		}
	}

//Function for interacting with boons and hazards.
	public void OnTriggerEnter (Collider collider) {

		//Checks what trigger the grunt has collided with and reacts accordingly.
		if (collider.gameObject.CompareTag("Lava")) {
			//Starts the Lava burning DoT from being too close to the pool.
			StartCoroutine("LavaDoT");
		}
	}

//Function for leaving boons and hazards.
	public void OnTriggerExit (Collider collider) {

		//Checks if the grunt has left the trigger collider and reacts accordingly.
		if (collider.gameObject.CompareTag("Lava")) {
			//Stops the Lava burning DoT.
			StopCoroutine("LavaDoT");

			//Reports that the grunt has stopped burning.
			Debug.Log("The Lava is no longer burning the grunt.");
		}
	}

//Function for the Lava DoT for standing too close to the pool.
	IEnumerator LavaDoT () {

		//Runs until the Coroutine is turned off by leaving the Lava collider.
		while (true) {
			//Decreases grunt current Health by lavaDamage for every second spent under the effect of the DoT.
			yield return new WaitForSeconds(1);
			gruntHealthCurrent -= lavaDamage;

			//Reports that then grunt is under the effect of the Lava DoT.
			Debug.Log("The Lava is burning the grunt, he now has " + gruntHealthCurrent + " Health left.");
		}
	}
}
