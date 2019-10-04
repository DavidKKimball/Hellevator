using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpBoon : MonoBehaviour {

	public bool canFly = false;
	public float amplitude = 0.3f;
	public float frequency = 0.3f;

	public ParticleSystem impBoonLightning;
	public ParticleSystem playerImp;

	public AudioClip impB;
	public AudioSource source;

	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	void Start () {

		//Records the starting position of the ImpBoon.
		posOffset = transform.position;
	}

	void Update () {

		//Rotates the ImpBoon around the Y axis.
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);

		//Makes the ImpBoon bounce up and down.
		tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

		if(this.GetComponent<MeshRenderer>().enabled == true) {
			impBoonLightning.Play();
		}
	}

//Checks to see if the player has picked up the ImpBoon.
	public void OnTriggerEnter (Collider collider) {

		if (collider.gameObject.CompareTag("Player")) {

			source.clip = impB;
			source.Play();

			playerImp.Play();

			//Picks up the ImpBoon.
			this.gameObject.SetActive(false);
			Debug.Log("You may now fly!");

			//Turns on player Flight.
			canFly = true;
		}
	}

}
