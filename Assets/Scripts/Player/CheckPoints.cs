using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPoints : MonoBehaviour {

	PlayerController PlayerController;
	ImpBoon ImpBoon;
	TutSanityBoon TutSanityBoon;

	public Animation[] doorAnim;
	public Animation platformAnim;
	public Animation trapFinal;
    public Camera playercam;
    public Image fadetoblack;
    public Animator anim;

	public GameObject fade;

	public GameObject tutEyes;
	public GameObject[] fires;
    public GameObject floormanager;

	public bool firstdoor;
	public bool flightpoint;
	public bool flightcleared;
	public bool jumpcleared;
	public bool sanityCollected;
	public bool tutEnded;
	public bool level1;
	public bool level2;
	public bool level3;

	void Start () {
		PlayerController = GetComponent<PlayerController>();
		ImpBoon = GameObject.Find("ImpBoon Tutorial").GetComponent<ImpBoon>();
		TutSanityBoon = GameObject.Find("Sanity Potion 1").GetComponent<TutSanityBoon>();
	}


	void Update () {

	}

	public void OnTriggerEnter (Collider collider) {
		if (collider.name == "FirstCheck") {
			if (firstdoor == false) {
				StartCoroutine("freeze");
			}
			firstdoor = true;
		} else if (collider.name == "SecondCheck" && ImpBoon.canFly == true) {
			flightpoint = true;
		} else if (collider.name == "ThirdCheck" && ImpBoon.canFly == true) {
			flightcleared = true;
		} else if (collider.name == "FourthCheck") {
			if (jumpcleared == false) {
				StartCoroutine("freezeTwo");
			}
			jumpcleared = true;
		} else if (collider.name == "SanityTarget") {
			doorAnim[1].Play("Door Close Vertically");
			fires[1].SetActive(false);
			sanityCollected = true;
		} else if (collider.name == "Sanity Potion Trap") {
			trapFinal.Play("ElevatorFloorTrapDoorOpen");
			tutEnded = true;
            playercam.GetComponent<ThirdPersonCamera>().enabled = false;
            PlayerController.speed = 0f;
			fade.SetActive(true);
            anim.SetBool("fadeout", true);
            Invoke("finishTut", 1.5f);
		} else if (collider.name == "Level1Start" && level1 == false) {
			level1 = true;
            PlayerController.speed = 5f;
		} else if (collider.name == "Level2Start" && level2 == false) {
			level2 = true;
		} else if (collider.name == "Level3Start" && level3 == false) {
			level3 = true;
			PlayerController.speed = 0f;
		}
	}

    public void finishTut()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	IEnumerator freeze() {
		yield return new WaitForSeconds(0.5f);
		tutEyes.SetActive(true);
		PlayerController.speed = 0f;
		yield return new WaitForSeconds(3.5f);
		PlayerController.speed = 5f;
		yield break;
	}

	IEnumerator freezeTwo() {
		yield return new WaitForSeconds(0.5f);
		PlayerController.speed = 0f;
		doorAnim[0].Play("Door Open Vertically");
		doorAnim[1].Play("Door Open Vertically");
		fires[0].SetActive(true);
		fires[1].SetActive(true);
		yield return new WaitForSeconds(3.5f);
		fires[0].SetActive(false);
		platformAnim.Play("PlatformMoveOut");
		TutSanityBoon.active = true;
		PlayerController.speed = 5f;
		yield break;
	}
}
