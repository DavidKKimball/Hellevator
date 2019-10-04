using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutJumpPad : MonoBehaviour {

	PlayerController PlayerController;

	private Animation anim;

	public bool jumpPadActive;

	void Start () {

		PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
		anim = GetComponent<Animation>();

		jumpPadActive = false;
		anim.Play("Flip to Upside Down (Deactivated)");
	}

	// Update is called once per frame
	void Update () {

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
				}
				//Sets the player states appropriately and turns off the highJump bool.
				PlayerController.grounded = false;
				PlayerController.highJump = false;
				PlayerController.jumpPad = false;
			}
		}
}
