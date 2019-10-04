using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
using UnityEngine.UI;

public class Sanity : MonoBehaviour {

	ThirdPersonCamera ThirdPersonCamera;

	public ParticleSystem sanityIncrease;
	public ParticleSystem playerBurning;
	public ParticleSystem playerBleeding;

    //public GameObject[] brain;
    public Slider health;
	public GameObject hurt;
    public AudioSource source;
    public AudioClip generichurt;
    public AudioClip sawhurt;
    public AudioClip spikyhurt;
    public AudioClip lavahurt;
    public AudioClip healed;
    public AudioClip scream;

    private Animation anim;

	public int playerSanityMax = 100;
	public float playerSanityCurrent;
    public bool tutorial;

	private int sawbladeDamage = 5;
	private int lavaDamage = 5;
	private int fireDamage = 8;
	private int fireDoTTime;

	private int sanityBoon = 10;

	public bool death;
	public bool norumble;

	void Start () {

		ThirdPersonCamera = GameObject.Find("Main Camera").GetComponent<ThirdPersonCamera>();

		anim = GetComponentInChildren<Animation>();

		//Checks for player Sanity maximum.
		//Important later for returning Sanity to player.
		Debug.Log("Player Sanity max is: " + playerSanityMax);

		//Sets player Sanity current to 100 at game start.
		playerSanityCurrent = 100f;
		//Checks that the Sanity is correct.
		Debug.Log("Player Sanity current is: " + playerSanityCurrent);
	}

	void Update () {

        /*if (playerSanityCurrent >= 100) {
			brain[0].SetActive(true);
			brain[1].SetActive(false);
		} else if (playerSanityCurrent < 100 && playerSanityCurrent > 91) {
			hurt.SetActive(false);
			brain[0].SetActive(false);
			brain[1].SetActive(true);
			brain[2].SetActive(false);
		} else if (playerSanityCurrent < 90 && playerSanityCurrent > 81) {
			hurt.SetActive(false);
			brain[1].SetActive(false);
			brain[2].SetActive(true);
			brain[3].SetActive(false);
		}  else if (playerSanityCurrent < 80 && playerSanityCurrent > 71) {
			hurt.SetActive(false);
			brain[2].SetActive(false);
			brain[3].SetActive(true);
			brain[4].SetActive(false);
		}  else if (playerSanityCurrent < 70 && playerSanityCurrent > 61) {
			hurt.SetActive(false);
			brain[3].SetActive(false);
			brain[4].SetActive(true);
			brain[5].SetActive(false);
		}  else if (playerSanityCurrent < 60 && playerSanityCurrent > 51) {
			hurt.SetActive(false);
			brain[4].SetActive(false);
			brain[5].SetActive(true);
			brain[6].SetActive(false);
		}  else if (playerSanityCurrent < 50 && playerSanityCurrent > 41) {
			hurt.SetActive(false);
			brain[5].SetActive(false);
			brain[6].SetActive(true);
			brain[7].SetActive(false);
		}  else if (playerSanityCurrent < 40 && playerSanityCurrent > 31) {
			hurt.SetActive(true);
			brain[6].SetActive(false);
			brain[7].SetActive(true);
			brain[8].SetActive(false);

		}  else if (playerSanityCurrent < 30 && playerSanityCurrent > 21) {
			hurt.SetActive(true);
			brain[7].SetActive(false);
			brain[8].SetActive(true);
			brain[9].SetActive(false);

		}  else if (playerSanityCurrent < 20) {
			hurt.SetActive(true);
			brain[8].SetActive(false);
			brain[9].SetActive(true);
		}*/

		if (playerSanityCurrent < 40) {
			hurt.SetActive(true);
		} else if (playerSanityCurrent > 39) {
			hurt.SetActive(false);
		}

        health.value = playerSanityCurrent/100f;

        //Tests for player death upon reaching 0 or less Sanity.
        if (playerSanityCurrent <= 0 && death == false && norumble == false) {

			StopCoroutine("Rumble");
			GamePad.SetVibration(0, 0.5f, 0.5f);

			ThirdPersonCamera.startShake = true;

			StartCoroutine("Death");
			norumble = true;
		}
	}

//Checks for collision with hazards and does damage to player Sanity upon collision.
	public void OnCollisionEnter (Collision collision) {

		//If player touches hazard, player takes damage to Sanity.
		if (collision.gameObject.CompareTag("Sawblade")) {

            source.clip = sawhurt;
            source.Play();

			if (death == false) {
				StartCoroutine("Rumble");
			}

			ThirdPersonCamera.startShake = true;

			anim["Hurt"].speed = 7.0f;
			anim.Play("Hurt");


			//Does Sawblade damage to the player.
			playerSanityCurrent -= sawbladeDamage;

			//Plays the player bleeding particle effect.
			playerBleeding.Play();

			//Checks for how much Sanity the player has left after taking damage.
			Debug.Log("Sawblade touched, you have " + playerSanityCurrent + " Sanity left.");
		} else if (collision.gameObject.CompareTag("Spikes")) {

            source.PlayOneShot(spikyhurt, 1f);

            ThirdPersonCamera.startShake = true;

			//anim["Hurt"].speed = 7.0f;
			//anim.Play("Hurt");

			//Instantly kills the player.
			playerSanityCurrent -= playerSanityMax;
			Debug.Log("Spikes have crushed you.");
		} else if (collision.gameObject.CompareTag("Lava")) {
            //Kills the player after touching the center of the Lava pool.

            source.PlayOneShot(lavahurt, 1f);

            anim["Hurt"].speed = 7.0f;
			anim.Play("Hurt");

			playerSanityCurrent -= playerSanityMax;
			Debug.Log("Lava has burned you to ash.");
		}
	}

//Function for interacting with boons and hazards.
	public void OnTriggerEnter (Collider collider) {

		//Checks what trigger the player has collided with and reacts accordingly.
		if (collider.gameObject.CompareTag("SanityBoon") && playerSanityCurrent < playerSanityMax) {
            //Turns off the collected boon and adds to player Sanity.
            source.PlayOneShot(healed, 1f);

            collider.gameObject.SetActive(false);
			playerSanityCurrent += sanityBoon;

			//Plays sanity increase particle effect.
			sanityIncrease.Play();

			//Reports that the player has successfully gained Sanity.
			Debug.Log("You gained Sanity, you now have " + playerSanityCurrent + " Sanity left.");
		} else if (collider.gameObject.CompareTag("Lava")) {
            //Starts the Lava burning DoT from being too close to the pool.
            source.PlayOneShot(generichurt, 1f);
            StartCoroutine("LavaDoT");
		} else if (collider.gameObject.CompareTag("FirePlume")) {
            //Starts the Fire burning DoT from standing in the plume.
            source.PlayOneShot(generichurt, 1f);
            StartCoroutine("FireDoT");
		}
	}

//Function for leaving boons and hazards.
	public void OnTriggerExit (Collider collider) {

		//Checks if the player has left the trigger collider and reacts accordingly.
		if (collider.gameObject.CompareTag("Lava")) {
			//Stops the Lava burning DoT.
			StopCoroutine("LavaDoT");

			//Reports that the player has stopped burning.
			Debug.Log("The Lava is no longer burning you.");
		}
		if (collider.gameObject.CompareTag("FirePlume")) {
			//Stops the Fire burning DoT.
			StopCoroutine("FireDoT");

			//Reports that the player has stopped burning.
			Debug.Log("The Fire is no longer burning you.");
		}
	}

//Function for player death.
	IEnumerator Death () {
        source.PlayOneShot(scream, 1f);

        yield return new WaitForSeconds(0.5f);

		GamePad.SetVibration(0, 0f, 0f);

		//Sets the death bool to true.
		//Important for future animations.
		death = true;

        if (tutorial)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            //Reloads current level.
            SceneManager.LoadScene("Loss Screen");
        }

	}

//Function for the Lava DoT for standing too close to the pool.
	IEnumerator LavaDoT () {

		//Runs until the Coroutine is turned off by leaving the Lava collider.
		while (true) {
			//Decreases player current Sanity by lavaDamage for every second spent under the effect of the DoT.
			yield return new WaitForSeconds(0.5f);

			anim["Hurt"].speed = 7.0f;
			anim.Play("Hurt");
			playerSanityCurrent -= lavaDamage;

			//Plays the player burning particle effect.
			playerBurning.Play();

			//Reports that then player is under the effect of the Lava DoT.
			Debug.Log("The Lava is burning you, you now have " + playerSanityCurrent + " Sanity left.");
		}
	}

//Function for the Fire DoT for standing in the fire plume.
	IEnumerator FireDoT () {

		//Runs until the Coroutine is turned off by leaving the Fire collider.
		while (true) {
			//Decreases player current Sanity by fireDamage for every second spent under the effect of the DoT.
			yield return new WaitForSeconds(0.5f);

			anim["Hurt"].speed = 7.0f;
			anim.Play("Hurt");
			playerSanityCurrent -= fireDamage;

			//Plays the player burning particle effect.
			playerBurning.Play();

			//Reports that then player is under the effect of the Fire DoT.
			Debug.Log("The Fire is burning you, you now have " + playerSanityCurrent + " Sanity left.");
		}
	}

//Controller Rumble on health loss.
	IEnumerator Rumble () {

		GamePad.SetVibration(0, 1f, 1f);

		yield return new WaitForSeconds(1);

		GamePad.SetVibration(0, 0f, 0f);

		yield break;
	}
}
