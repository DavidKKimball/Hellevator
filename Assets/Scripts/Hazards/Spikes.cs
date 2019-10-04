using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	SpikeBallSpawn SpikeBallSpawn;
	EyesHealth EyesHealth;

	public Transform leftTarget;
	public Transform rightTarget;
	public bool rollPlay;
	public bool frontBall;
	public bool backBall;
	public float speed;
	private float forward = 1f;
	private float backwards = -1f;

	private Animator anim;

	void Start () {

		SpikeBallSpawn = GameObject.Find("SpikeBalls").GetComponent<SpikeBallSpawn>();

		anim = GetComponent<Animator>();

		//Sets the balls to true at their starting locations.
		frontBall = true;
		backBall = true;
	}

    void Update () {

		//Checks that the spikes have indeed spawned.
		if (rollPlay == true) {

			if (this.name == "TRAP_Mace_Ball_LeftMiddle" && frontBall == true) {
				rollRight();
			} else if (this.name == "TRAP_Mace_Ball_LeftMiddle" && frontBall == false) {
				rollLeft();
			} else if (this.name == "TRAP_Mace_Ball_RightBack" && backBall == true) {
				rollLeft();
			}  else if (this.name == "TRAP_Mace_Ball_RightBack" && backBall == false) {
				rollRight();
			}
		}
    }

//Rolls the spikes towards the left side of the room.
	public void rollLeft () {

		if (transform.position != leftTarget.position) {

			//Reverses roll animation.
			anim.SetFloat("Speed", backwards);

			anim.Play("MaceSpikeBallSpin");

			transform.position = Vector3.MoveTowards(transform.position, leftTarget.position, speed * Time.deltaTime);

		} else if (transform.position == leftTarget.position) {

			//Stops the rolling from playing once it has reached its target.
			rollPlay = false;

			if (this.name == "TRAP_Mace_Ball_LeftMiddle") {
				SpikeBallSpawn.spikes[0] = false;
				frontBall = true;
			} else if (this.name == "TRAP_Mace_Ball_RightBack") {
				SpikeBallSpawn.spikes[1] = false;
				backBall = false;
			}
		}
	}

//Rolls the spikes towards the right side of the room.
	public void rollRight () {

		if (transform.position != rightTarget.position) {

			//Plays roll animation normally.
			anim.SetFloat("Speed", forward);

			anim.Play("MaceSpikeBallSpin");

			transform.position = Vector3.MoveTowards(transform.position, rightTarget.position, speed * Time.deltaTime);

		} else if (transform.position == rightTarget.position) {

			//Stops the rolling from playing once it has reached its target.
			rollPlay = false;

			if (this.name == "TRAP_Mace_Ball_LeftMiddle") {
				SpikeBallSpawn.spikes[0] = false;
				frontBall = false;
			} else if (this.name == "TRAP_Mace_Ball_RightBack") {
				SpikeBallSpawn.spikes[1] = false;
				backBall = true;
			}
		}
	}
}
