using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialEyes : MonoBehaviour {

	EyesHealth EyesHealth;
	AttackPrompt AttackPrompt;

	void Start () {
		EyesHealth = GetComponent<EyesHealth>();
		AttackPrompt = GameObject.Find("GameManager").GetComponent<AttackPrompt>();
	}


	void Update () {

		if (EyesHealth.eyesHealthCurrent <= 0) {
			AttackPrompt.tuteyesDied = true;
		}
	}
}
