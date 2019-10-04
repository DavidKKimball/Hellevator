using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPrompt : MonoBehaviour {

	CheckPoints CheckPoints;
	Pause Pause;

	public GameObject impBoon;

	public bool tuteyesDied;

	public Image E;
	public Image A;
	public Text attackText;


	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		Pause = GameObject.Find("PauseButtons").GetComponent<Pause>();
	}

	void Update () {
		if (CheckPoints.firstdoor == true && tuteyesDied == false && Pause.paused == false) {
			E.gameObject.SetActive(true);
			A.gameObject.SetActive(true);
			attackText.gameObject.SetActive(true);
		} else if (tuteyesDied == true || Pause.paused == true) {
			impBoon.GetComponent<SphereCollider>().enabled = true;
			impBoon.GetComponent<MeshRenderer>().enabled = true;
			E.gameObject.SetActive(false);
			A.gameObject.SetActive(false);
			attackText.gameObject.SetActive(false);
		}
	}
}
