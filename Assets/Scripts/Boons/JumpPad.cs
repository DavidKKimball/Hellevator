using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	PlayerController PlayerController;
	BoonSpawner BoonSpawner;

	public AudioClip springSound;
	public AudioSource spring;

	public bool jumpPadActive;
	private Animation anim;

	void Start () {

		PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
		BoonSpawner = GameObject.Find("BoonRNG").GetComponent<BoonSpawner>();
		anim = GetComponent<Animation>();

		//Starts the jump pads off at start.
		jumpPadActive = false;
		anim.Play("Flip to Upside Down (Deactivated)");
	}

	void Update () {

		//Activates or deactivates the jump pads on an RNG timer.
		if (BoonSpawner.jumpPadRNG == 0 && jumpPadActive == true) {

		   deactivateJumpPad();

	   	} else if (BoonSpawner.jumpPadRNG == 1 && jumpPadActive == false) {

		   activateJumpPad();

	   	} else if (BoonSpawner.jumpPadRNG == 2) {

			if (this.name == "Springboard_With_Animation_WEST" && jumpPadActive == false) {

				activateJumpPad();

			} else if (this.name == "Springboard_With_Animation_EAST" && jumpPadActive == true) {

				deactivateJumpPad();
			}

		} else if (BoonSpawner.jumpPadRNG == 3) {

			if (this.name == "Springboard_With_Animation_WEST" && jumpPadActive == true) {

				deactivateJumpPad();

			} else if (this.name == "Springboard_With_Animation_EAST" && jumpPadActive == false) {

				activateJumpPad();
			}

		}

	}

//Function that turns off JumpPad when called.
	public void deactivateJumpPad () {

		jumpPadActive = false;
		PlayerController.highJump = false;
		anim.Play("Flip to Upside Down (Deactivated)");
	}

//Function that turns on JumpPad when called.
	public void activateJumpPad () {

		jumpPadActive = true;
		anim.Play("Flip to Activate");
	}

//Function enables the highJump bool to allow the player to use the Jump Pad.
	public void OnCollisionEnter (Collision collision) {

		//Checks if the player has collided with the Jump Pad.
		if (collision.gameObject.CompareTag("Player")) {

			//Sets the player states appropriately and turns on the highJump bool.
			PlayerController.grounded = true;
			PlayerController.jumping = false;
			PlayerController.hasJumped = false;
			PlayerController.jumpPad = true;

			if (jumpPadActive == true) {
				PlayerController.highJump = true;
			}
		}
	}

//Function turns off the highJump bool to indicate the player is no longer on the Jump Pad.
	public void OnCollisionExit (Collision collision) {

		//Checks if the player has left the Jump Pad.
		if (collision.gameObject.CompareTag("Player")) {

			//Checks to see if the player has actually jumped.
			//Also helps prevent Double Jumping while on the Jump Pad.
			if (PlayerController.hasJumped == true && jumpPadActive == true) {
				PlayerController.jumping = true;
				anim.Play("Spring Jump Activate");
				spring.clip = springSound;
				spring.Play();
			}
			//Sets the player states appropriately and turns off the highJump bool.
			PlayerController.grounded = false;
			PlayerController.highJump = false;
			PlayerController.jumpPad = false;
		}
	}
}
