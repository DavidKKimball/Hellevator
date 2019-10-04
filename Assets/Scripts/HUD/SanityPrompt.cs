using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityPrompt : MonoBehaviour {

	CheckPoints CheckPoints;
	Pause Pause;

	public Text sanityText;

	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}


	void Update () {

		if (CheckPoints.jumpcleared == true && CheckPoints.sanityCollected == false && Pause.paused == false) {
			sanityText.gameObject.SetActive(true);
		} else if (CheckPoints.sanityCollected == true || Pause.paused == true) {
			sanityText.gameObject.SetActive(false);
		}

	}
}
