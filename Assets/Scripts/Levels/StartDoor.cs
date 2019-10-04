using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor : MonoBehaviour {

	CheckPoints CheckPoints;

	public GameObject door;
	private Animation anim;

	public bool firstDoorDone;
	public bool gameStart;

	void Start () {

		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

		anim = GetComponent<Animation>();
		StartCoroutine("StartGame");
	}


	void Update () {
		if (CheckPoints.firstdoor == true && firstDoorDone == false) {
			StopCoroutine("StartGame");
			anim.Play("Door Close Vertically");
			firstDoorDone = true;
		}
	}

	IEnumerator StartGame () {
		yield return new WaitForSeconds(1);
		anim.Play("Door Open Vertically");
		gameStart = true;
	}
}
