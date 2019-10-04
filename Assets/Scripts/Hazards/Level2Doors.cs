using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Doors : MonoBehaviour {

	FirePlumeSpawn FirePlumeSpawn;
	ElevatorMove ElevatorMove;

	public GameObject[] doors;
	public GameObject[] telegraphs;
	public Animation[] anim;
	public bool[] open;

	void Start () {

		FirePlumeSpawn = GameObject.Find("Fire Plumes").GetComponent<FirePlumeSpawn>();
		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();

		open = new bool[6];

		for (int i = 0; i < 6; i++) {

			open[i] = false;
		}

	}

	// Update is called once per frame
	void Update () {

		if (ElevatorMove.level2 == true) {
			//Opens/Closes doors vertically based on fire plume.
			for (int i = 0; i < 6; i++) {
				if (FirePlumeSpawn.fires[i] == true && open[i] == false) {

					openVertically(i);
				} else if (FirePlumeSpawn.fires[i] == false && open[i] == true) {

					closeVertically(i);
				}
			}

			//Opens/Closes doors horizontally based on spike balls.
			//Only closes the door if no fire plume is active.
			if (SpikeBallSpawn.spikes[0] == true) {

				if (open[1] == false) {
					openHorizontally(1);
				}
				if (open[4] == false) {
					openHorizontally(4);
				}

			} else if (SpikeBallSpawn.spikes[0] == false) {

				if (FirePlumeSpawn.fires[1] == false && open[1] == true) {
					closeHorizontally(1);
				}
				if (FirePlumeSpawn.fires[4] == false && open[4] == true) {
					closeHorizontally(4);
				}
			}

			if (SpikeBallSpawn.spikes[1] == true) {

				if (open[2] == false) {
					openHorizontally(2);
				}
				if (open[5] == false) {
					openHorizontally(5);
				}

			} else if (SpikeBallSpawn.spikes[1] == false) {

				if (FirePlumeSpawn.fires[2] == false && open[2] == true) {
					closeHorizontally(2);
				}
				if (FirePlumeSpawn.fires[5] == false && open[5] == true) {
					closeHorizontally(5);
				}
			}

			//This code SHOULD be unnecssary, but things break if you remove it.
			//TEMP FIX WHEN LESS TIRED.
			for (int i = 0; i < 6; i++) {
				if (FirePlumeSpawn.fires[i] == true && open[i] == false) {

					openHorizontally(i);
				} else if (FirePlumeSpawn.fires[i] == false && open[i] == true) {

					closeHorizontally(i);
				}
			}
		}

	}

	//Opens the doors vertically for fire plumes.
		public void openVertically (int door) {
			telegraphs[door].SetActive(true);
			open[door] = true;
			anim[door].Play("Door Open Vertically");
		}

	//Closes the doors vertically for fire plumes.
		public void closeVertically (int door) {
			telegraphs[door].SetActive(false);
			open[door] = false;
			anim[door].Play("Door Close Vertically");
		}

	//Opens the doors horizontally for fire plumes.
		public void openHorizontally (int door) {
			telegraphs[door].SetActive(true);
			open[door] = true;
			anim[door].Play("Door Open");
		}

	//Closes the doors horizontally for fire plumes.
		public void closeHorizontally (int door) {
			telegraphs[door].SetActive(false);
			open[door] = false;
			anim[door].Play("Door Close");
		}
}
