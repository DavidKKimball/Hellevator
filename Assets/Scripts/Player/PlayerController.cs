using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TEMP
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	PlayerAttacks PlayerAttacks;
	ImpBoon ImpBoon;
	ImpBoon TutBoon;

	public ParticleSystem footLeft;
	public ParticleSystem footRight;

	private Animation anim;

    public AudioClip jump;
    public AudioClip walk;

    public AudioSource source;

	public float speed = 5.0f;
	public bool grounded;

	public float jumpVelocity;
	public float jumpDampening = 0.035f;
	public bool jumping;
	public bool highJump;
	public bool jumpPad;
	public bool hasJumped;

	public float flySpeed;
	public bool isFlying;
	public float flightMeter = 1.5f;
	public float maxFlightMeter = 1.5f;

	Vector3 currentPos = new Vector3 ();
	Vector3 lastPos = new Vector3 ();

	//Rect flightRect;
	//Texture2D flightTexture;


	void Start () {

		PlayerAttacks = GetComponent<PlayerAttacks>();
		ImpBoon = GameObject.Find("ImpBoon").GetComponent<ImpBoon>();
		TutBoon = GameObject.Find("ImpBoon Tutorial").GetComponent<ImpBoon>();
		anim = GetComponentInChildren<Animation>();

		lastPos = currentPos;

		/*//Flight meter texture.
		flightRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
		flightTexture = new Texture2D(1, 1);
		flightTexture.SetPixel(0, 0, Color.white);
		flightTexture.Apply();*/
	}

	void Update () {

		//Player movement behavior.
		float translation = Input.GetAxis("Vertical") * speed;
		float strafe = Input.GetAxis("Horizontal") * speed;

		translation *= Time.deltaTime;
		strafe *= Time.deltaTime;

		//Flight script.
		if (Input.GetButton("Fly") && ImpBoon.canFly == true || Input.GetButton("Fly") && TutBoon.canFly == true) {
			Fly(true);
		} else if (Input.GetButtonUp("Fly") && ImpBoon.canFly == true || Input.GetButtonUp("Fly") && TutBoon.canFly == true)  {
			Fly(false);
		}

		if (isFlying == true) {
			flightMeter -= Time.deltaTime;
			if (flightMeter < 0) {
				flightMeter = 0;
				Fly(false);
			}
		} else if (flightMeter < maxFlightMeter) {
			flightMeter += Time.deltaTime;

			if (flightMeter > 1.5f) {
				flightMeter = 1.5f;
			}
		}

		transform.Rotate(0, strafe, 0);
		transform.Translate(strafe, flySpeed, translation);

		currentPos = transform.position;

		if (currentPos != lastPos && hasJumped == false) {
			anim["Run"].speed = 6.0f;
			anim.Play("Run");
            /*source.clip = walk;
            source.Play();*/
		}

		if (Input.GetButtonDown("Punch") && PlayerAttacks.punching == false) {
			//anim["Attack"].speed = 6.0f;
			//anim.Play("Attack");
		}

		if (currentPos == lastPos && !anim.IsPlaying("Attack1")) {
			if (!anim.IsPlaying("Attack2") && !anim.IsPlaying("Jump") && !anim.IsPlaying("Hurt")) {
				anim.Play("Idle");
			}
		}

		lastPos = currentPos;

		//Player jumping behavior.
		//Continued in Jump script.
		if (Input.GetButtonDown("Jump")) {
			if (jumping == false) {
				Jump();
			}
		}

	}

	void FixedUpdate () {

		//Player turning behavior.
		Quaternion rot = Quaternion.Euler( 0, transform.rotation.eulerAngles.y, 0 );
		transform.rotation = rot;

		Vector3 pos = transform.position;

		//Checks if the player has jumped.
         if (jumpVelocity != 0) {
             pos.y += jumpVelocity;
             jumpVelocity -= jumpDampening;

			 //Resets the player back to pre-jump state.
             if (jumpVelocity <= 0) {
                 gameObject.GetComponent<Rigidbody>().useGravity = true;
                 jumpVelocity = 0;
             }
         }

         transform.position = pos;
	}

/*//Draws Flight Meter;
	void OnGUI () {

		float ratio = flightMeter / maxFlightMeter;

		float rectWidth = ratio * Screen.width / 3;

		flightRect.width = rectWidth;

		//Only draws the flight meter if the player can fly.
		if (ImpBoon.canFly == true) {
			GUI.DrawTexture(flightRect, flightTexture);
		}
	}*/


//Function for jumping.
	public void Jump () {

			anim.Play("Jump");
        source.clip = jump;
        source.Play();

			//Checks if the player is on the Jump Pad and sets the jumpVelocity based on if that is true.
			if (highJump == false) {

					jumpVelocity = 0.3f;

			} else if (highJump == true) {

					jumpVelocity = 0.6f;

			}

		//Turns off player gravity while jumping.
		gameObject.GetComponent<Rigidbody>().useGravity = false;

		//Sets the number of times the player has jumped. Applicable only to Double Jump.
		hasJumped = true;
	}

//Function for flight after ImpBoon is collected.
	public void Fly (bool playerFlying) {

		//Sets flying to true or false based on player input.
		this.isFlying = playerFlying;

		 flySpeed = 0;

		 //Sets player gravity off if flying and flight speed. Turns gravity back on when not flying.
		 if (isFlying) {
			 footLeft.Play();
			 footRight.Play();
			 anim.Play("Hover");
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			flySpeed = 0.05f;
		 } else {
			 footLeft.Stop();
			 footRight.Stop();
			gameObject.GetComponent<Rigidbody>().useGravity = true;
		 }
	}

//Function tests to see if player is grounded by collision with the floor object.
	public void OnCollisionEnter (Collision collision) {

		//If true, sets grounded bool to true, and jumping bool to false.
		if (collision.gameObject.CompareTag("Ground")) {
			grounded = true;
            //Allows player to jump again.
            jumping = false;
			hasJumped = false;
		} else if (collision.gameObject.CompareTag("Jump Pad")) {

			grounded = true;
			//Allows player to jump again.
			jumping = false;
			hasJumped = false;
		}
	}

//Function tests to see if player is jumping by collision exit with the floor object.
	public void OnCollisionExit (Collision collision) {

		//Checks that the player has left the ground, but is not on a jump pad.
		if (collision.gameObject.CompareTag("Ground") && jumpPad == false) {
			grounded = false;
			//Disables player jumping.
			if (isFlying == false) {
				jumping = true;
			}
		}
	}
}
