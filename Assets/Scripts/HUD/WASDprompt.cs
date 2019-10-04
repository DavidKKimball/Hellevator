using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASDprompt : MonoBehaviour {

	StartDoor StartDoor;
	CheckPoints CheckPoints;
	Pause Pause;

	public Image WASD;
	public Image Joystick;
	public Text moveText;


	void Start () {
		StartDoor = GameObject.Find("Door One").GetComponent<StartDoor>();
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}

	void Update () {
		if (StartDoor.gameStart == true && CheckPoints.firstdoor == false) {
			WASD.gameObject.SetActive(true);
			Joystick.gameObject.SetActive(true);
			moveText.gameObject.SetActive(true);
		} else if (CheckPoints.firstdoor == true || Pause.paused == true) {
			WASD.gameObject.SetActive(false);
			Joystick.gameObject.SetActive(false);
			moveText.gameObject.SetActive(false);
		}
	}
}
