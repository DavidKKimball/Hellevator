using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonSpawner : MonoBehaviour {

	CheckPoints CheckPoints;

	public bool active;
	public bool impBoonDropped;
	public int sanitySpawn;
	public int jumpPadRNG;
	public int sanityBoonRNG;

	void Start () {

		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

		//Starts all events off at 0;
		jumpPadRNG = 0;
		sanityBoonRNG = 9;
	}

	void Update () {
		if (CheckPoints.level1 == true && active == false) {
			StartCoroutine("thirtySeconds");
			StartCoroutine("fifteenSeconds");
			active = true;
		}
	}


//Function that spits out an random number to call an event every fifteen seconds.
	IEnumerator fifteenSeconds () {

		while (enabled) {

			yield return new WaitForSeconds(10);

			//Rolls to see if a sanity boon will spawn, and if one does, which one.
			sanityBoonRNG = Random.Range(0, 10);
			sanitySpawn = Random.Range(0, 23);
		}

	}

//Function that spits out an random number to call an event every thirty seconds.
	IEnumerator thirtySeconds () {

		while (enabled) {

			yield return new WaitForSeconds(30);

			//Rolls for which jump pads will be turned on.
			jumpPadRNG = Random.Range(0, 4);
		}

	}
}
