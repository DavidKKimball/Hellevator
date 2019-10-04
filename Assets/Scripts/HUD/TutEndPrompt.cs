using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutEndPrompt : MonoBehaviour {

	CheckPoints CheckPoints;
	Pause Pause;

	public Text endText;

	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}

	void Update () {

		if (CheckPoints.sanityCollected == true && CheckPoints.tutEnded == false && Pause.paused == false) {
			endText.gameObject.SetActive(true);
		} else if (CheckPoints.tutEnded == true || Pause.paused == true) {
			endText.gameObject.SetActive(false);
		}

	}
}
