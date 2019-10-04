using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightPrompt : MonoBehaviour {

	CheckPoints CheckPoints;
	ImpBoon ImpBoon;
	Pause Pause;

	public Image shift;
	public Image trigger;
	public Text flightText;


	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		ImpBoon = GameObject.Find("ImpBoon Tutorial").GetComponent<ImpBoon>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}

	void Update () {
		if (CheckPoints.flightpoint == true && CheckPoints.flightcleared == false && Pause.paused == false) {
			shift.gameObject.SetActive(true);
			trigger.gameObject.SetActive(true);
			flightText.gameObject.SetActive(true);
		} else if (CheckPoints.flightcleared == true || Pause.paused == true) {
			ImpBoon.canFly = false;
			shift.gameObject.SetActive(false);
			trigger.gameObject.SetActive(false);
			flightText.gameObject.SetActive(false);
		}
	}
}
