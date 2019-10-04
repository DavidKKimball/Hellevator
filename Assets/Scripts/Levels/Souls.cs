using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souls : MonoBehaviour {

	public ParticleSystem souls;

	void OnCollisionEnter (Collision collision) {
		if(collision.gameObject.CompareTag("Player")) {
			souls.Play();
		}
	}

	void OnCollisionExit (Collision collision) {
		if(collision.gameObject.CompareTag("Player")) {
			souls.Stop();
		}
	}
}
