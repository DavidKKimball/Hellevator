using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesHealth : MonoBehaviour {

	public ParticleSystem eyesBleeding;
	public ParticleSystem eyesBurning;

	public bool eyesDied;
	public int eyesHealthMax = 22;
	public int eyesHealthCurrent;
	private int sawbladeDamage = 3;
	private int lavaDamage = 3;
	private int fireDamage = 3;

	void Start () {
		//Checks for eyes Health maximum.
		//Important later for returning Health to eyes.
		//Debug.Log("Eyes Health max is: " + eyesHealthMax);

		//Sets eyes Health current to 100 at game start.
		eyesHealthCurrent = 22;
	}

	void Update () {

		//Tests for eyes death upon reaching 0 or less Health.
		if (eyesHealthCurrent <= 0) {
			transform.Translate(0, -1f, 0);
			eyesDied = true;
			StartCoroutine("Death");
		}
	}

    //Checks for collision with hazards and does damage to eye Health upon collision.
    public void OnCollisionEnter(Collision collision) {

        //If eyes touches hazard, eyes takes damage to Health.
        if (collision.gameObject.CompareTag("Sawblade")) {
            //Does Sawblade damage to the eyes.
            eyesHealthCurrent -= sawbladeDamage;

			eyesBleeding.Play();

            //Checks for how much Health the eyes has left after taking damage.
            //Debug.Log("Sawblade touched, the eyes have " + eyesHealthCurrent + " Health left.");
        } else if (collision.gameObject.CompareTag("Spikes")) {
            //Instantly kills the eyes.
            eyesHealthCurrent -= eyesHealthMax;

			eyesBleeding.Play();

            //Debug.Log("Spikes have crushed the eyes.");
        } else if (collision.gameObject.CompareTag("Lava")) {
            //Kills the eyes after touching the center of the Lava pool.
            eyesHealthCurrent -= eyesHealthMax;

			eyesBurning.Play();

            //Debug.Log("Lava has burned the eyes to ash.");
        }
    }

    //Function for interacting with boons and hazards.
	public void OnTriggerEnter (Collider collider) {

		//Checks what trigger the eyes has collided with and reacts accordingly.
		if (collider.gameObject.CompareTag("Lava")) {
			//Starts the Lava burning DoT from being too close to the pool.
			StartCoroutine("LavaDoT");
		}

		if (collider.gameObject.CompareTag("FirePlume")) {
			//Starts the fire burning DoT from standing in the plume.
			StartCoroutine("FireDoT");
		}
	}

//Function for leaving boons and hazards.
	public void OnTriggerExit (Collider collider) {

		//Checks if the eyes has left the trigger collider and reacts accordingly.
		if (collider.gameObject.CompareTag("Lava")) {
			//Stops the Lava burning DoT.
			StopCoroutine("LavaDoT");

			//Reports that the eyes has stopped burning.
			//Debug.Log("The Lava is no longer burning the eyes.");
		}

		if (collider.gameObject.CompareTag("FirePlume")) {
			//Debug.Log("Eyes burning");
			//Stops the fire burning DoT.
			StopCoroutine("FireDoT");
		}
	}

//Function for player death.
	IEnumerator Death () {

		yield return new WaitForSeconds(0.8f);

		gameObject.SetActive(false);
		Debug.Log("The eyes have died.");

	}

//Function for the Lava DoT for standing too close to the pool.
	IEnumerator LavaDoT () {

		//Runs until the Coroutine is turned off by leaving the Lava collider.
		while (true) {
			//Decreases eyes current Health by lavaDamage for every second spent under the effect of the DoT.
			yield return new WaitForSeconds(1);
			eyesHealthCurrent -= lavaDamage;

			eyesBurning.Play();

			//Reports that then eyes is under the effect of the Lava DoT.
			//Debug.Log("The Lava is burning the eyes, they now have " + eyesHealthCurrent + " Health left.");
		}
	}

//Function for the Fire DoT for standing in the fire plume.
	IEnumerator FireDoT () {

		//Runs until the Coroutine is turned off by leaving the Fire collider.
		while (true) {
			//Decreases eyes current health by fireDamage for every second spent under the effect of the DoT.
			yield return new WaitForSeconds(1);
			eyesHealthCurrent -= fireDamage;

			//Plays the  eyes burning particle effect.
			eyesBurning.Play();
		}
	}
}
