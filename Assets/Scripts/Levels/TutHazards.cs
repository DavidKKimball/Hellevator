using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutHazards : MonoBehaviour {

	CheckPoints CheckPoints;
	TutJumpPad TutJumpPad1;
	TutJumpPad TutJumpPad2;
	TutJumpPad TutJumpPad3;
	//TutJumpPad TutJumpPad4;

	public Animation[] traps;
	public Animation[] jumps;
	public Animation[] saws;
	public GameObject[] sawsOn;

	public bool active;


	void Start () {
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();
		TutJumpPad1 = GameObject.Find("Tutorial Springboard").GetComponent<TutJumpPad>();
		TutJumpPad2 = GameObject.Find("Tutorial Springboard 2").GetComponent<TutJumpPad>();
		TutJumpPad3 = GameObject.Find("Tutorial Springboard 3").GetComponent<TutJumpPad>();
		//TutJumpPad4 = GameObject.Find("Tutorial Springboard 4").GetComponent<TutJumpPad>();
	}


	void Update () {
		if (CheckPoints.flightcleared == true && CheckPoints.jumpcleared == false && active == false) {
			for(int i = 0; i < 2; i++) {
				traps[i].Play("ElevatorFloorTrapDoorOpen");
				sawsOn[i].SetActive(true);
				saws[i].Play("SawBladeGoUp");
			}

			for(int i = 0; i < 3; i++) {
				jumps[i].Play("Flip to Activate");
				TutJumpPad1.jumpPadActive = true;
				TutJumpPad2.jumpPadActive = true;
				TutJumpPad3.jumpPadActive = true;
				//TutJumpPad4.jumpPadActive = true;
			}

			active = true;
		}
	}
}
