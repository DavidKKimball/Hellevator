using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	PlayerController PlayerController;

	public float fallMultiplier = 2.0f;
	public float lowJumpMultiplier = 1.0f;

	private Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();

		PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void Update () {

		//Checks for long press or short press on jump input.
		if (rb.velocity.y < 0 && PlayerController.isFlying == false) {

			//On long press, player jumps higher with increased fall speed.
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

		} else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && !Input.GetButton("Fly")) {

			//On short press, player executes a small jump.
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}
}
