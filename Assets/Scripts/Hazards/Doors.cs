using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	FirePlumeSpawn FirePlumeSpawn;
	SpikeBallSpawn SpikeBallSpawn;
	TrapDoorSpawn TrapDoorSpawn;

	public GameObject[] doors;
	public GameObject[] trapdoors;
	public GameObject[] telegraphs;
	public GameObject[] telegraphsSpikes;
	public Animation[] anim;
	public bool[] open;
	public bool[] trapopen;
	public bool spikes1Recently;
	public bool spikes2Recently;


	void Start () {

		FirePlumeSpawn = GameObject.Find("Fire Plumes").GetComponent<FirePlumeSpawn>();
		SpikeBallSpawn = GameObject.Find("SpikeBalls").GetComponent<SpikeBallSpawn>();
		TrapDoorSpawn = GameObject.Find("Trap Doors").GetComponent<TrapDoorSpawn>();

		open = new bool[6];
		trapopen = new bool[4];

		for (int i = 0; i < 6; i++) {

			open[i] = false;
		}

		for (int i = 0; i < 4; i++) {

			trapopen[i] = false;
		}
	}


	void Update () {

		//Opens/Closes doors vertically based on fire plume.
		for (int i = 0; i < 6; i++) {
			if (FirePlumeSpawn.fires[i] == true && open[i] == false) {

				openVertically(i);
			} else if (FirePlumeSpawn.fires[i] == false && open[i] == true) {
				if (i == 1 || i == 4) {
					if (SpikeBallSpawn.spikes[0] == false && spikes1Recently == false) {
						closeVertically(i);
					} else if (SpikeBallSpawn.spikes[1] == false && spikes1Recently == true) {
						//closeHorizontally(i);
						//telegraphsSpikes[0].SetActive(false);
						//telegraphsSpikes[1].SetActive(false);
					}
				} else if (i == 2 || i == 5) {
					if (SpikeBallSpawn.spikes[1] == false && spikes2Recently == false) {
						closeVertically(i);
					} else if (SpikeBallSpawn.spikes[1] == false && spikes2Recently == true) {
						closeHorizontally(i);
						telegraphsSpikes[2].SetActive(false);
						telegraphsSpikes[3].SetActive(false);
					}
				} else {
					closeVertically(i);
				}
			}
		}

		//Opens/Closes doors horizontally based on spike balls.
		//Only closes the door if no fire plume is active.
		if (SpikeBallSpawn.spikes[0] == true) {
			StartCoroutine("spike1Recent");
			telegraphsSpikes[0].SetActive(true);
			telegraphsSpikes[1].SetActive(true);
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
			telegraphsSpikes[0].SetActive(false);
			telegraphsSpikes[1].SetActive(false);
		}

		if (SpikeBallSpawn.spikes[1] == true) {
			StartCoroutine("spike2Recent");
			telegraphsSpikes[2].SetActive(true);
			telegraphsSpikes[3].SetActive(true);
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
			telegraphsSpikes[2].SetActive(false);
			telegraphsSpikes[3].SetActive(false);
		}

		for (int i = 0; i < 4; i++) {

			if (TrapDoorSpawn.trapDoors[i] == true && trapopen[i] == false) {

				openTrap(i);

			} else if (TrapDoorSpawn.trapDoors[i] == false && trapopen[i] == true) {

				StartCoroutine(closeTrap(i));

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
		//telegraphs[door].SetActive(true);
		open[door] = true;
		anim[door].Play("Door Open");
	}

//Closes the doors horizontally for fire plumes.
	public void closeHorizontally (int door) {
		//telegraphsSpikes[door].SetActive(false);
		open[door] = false;
		anim[door].Play("Door Close");
	}

//Opens trap doors.
	public void openTrap (int trap) {

		trapopen[trap] = true;
		trapdoors[trap].GetComponent<Animation>().Play("ElevatorFloorTrapDoorOpen");
	}

//Closes trap doors.
	IEnumerator closeTrap (int trap) {

		yield return new WaitForSeconds(1);

		trapopen[trap] = false;
		trapdoors[trap].GetComponent<Animation>().Play("ElevatorFloorTrapDoorClose");

		yield break;
	}

	IEnumerator spike1Recent () {
		spikes1Recently = true;
		yield return new WaitForSeconds(1.5f);
		spikes1Recently = false;
		yield break;
	}

	IEnumerator spike2Recent () {
		spikes2Recently = true;
		yield return new WaitForSeconds(1.5f);
		spikes2Recently = false;
		yield break;
	}
}
