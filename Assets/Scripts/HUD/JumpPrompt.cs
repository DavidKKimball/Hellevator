using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpPrompt : MonoBehaviour {

	CheckPoints CheckPoints;
	Pause Pause;

	public Image space;
	public Image bumper;
	public Text jumpText;

	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}


	void Update () {
		if (CheckPoints.flightcleared == true && CheckPoints.jumpcleared == false && Pause.paused == false) {
			space.gameObject.SetActive(true);
			bumper.gameObject.SetActive(true);
			jumpText.gameObject.SetActive(true);
		} else if (CheckPoints.jumpcleared == true || Pause.paused == true) {
			space.gameObject.SetActive(false);
			bumper.gameObject.SetActive(false);
			jumpText.gameObject.SetActive(false);
		}
	}
}
