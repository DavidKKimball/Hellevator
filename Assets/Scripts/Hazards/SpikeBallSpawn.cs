using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallSpawn : MonoBehaviour {

	HazardSpawner HazardSpawner;
	ElevatorMove ElevatorMove;
	CheckPoints CheckPoints;
	Spikes SpikesFront;
	Spikes SpikesBack;
	EyeSpawn EyeSpawn;

    public AudioSource source;

	public GameObject[] spikeBalls;

	public static bool[] spikes;

	void Start () {

		HazardSpawner = GameObject.Find("HazardRNG").GetComponent<HazardSpawner>();
		SpikesFront = GameObject.Find("TRAP_Mace_Ball_LeftMiddle").GetComponent<Spikes>();
		SpikesBack = GameObject.Find("TRAP_Mace_Ball_RightBack").GetComponent<Spikes>();
		EyeSpawn = GameObject.Find("Enemy Spawns").GetComponent<EyeSpawn>();
		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();
		CheckPoints = GameObject.Find("Player").GetComponent<CheckPoints>();

		spikes = new bool[2];

		for (int i = 0; i < 2; i++) {
			spikes[i] = false;
		}
	}

    private void stopAudio()
    {
        source.Stop();
    }

	void Update () {
		
		if (EyeSpawn.level2Clear == true) {
			spikeBalls[0].SetActive(false);
			spikeBalls[1].SetActive(false);
		}

		if (EyeSpawn.levelClear == true && CheckPoints.level2 == false || EyeSpawn.level2Clear == true && ElevatorMove.level3 == false) {

			for (int i = 0; i < 2; i++) {

				spikes[i] = false;
			}

		} else if (ElevatorMove.level3 == false) {

		//Loops through both spikes.
		for (int i = 0; i < 2; i++) {

			//Checks if the a spike should spawn or not.
			if (HazardSpawner.spikeBallRNG > 4 && spikes[i] == true) {
                    spikes[i] = false;
			} else if (HazardSpawner.spikeBallRNG < 5) {

				//Spawns either a front spike ball, a back ball, or both at the same time.
				if (HazardSpawner.spikeCount == 0 && HazardSpawner.spikeBool == true) {
					spikes[0] = true;

					HazardSpawner.spikeBool = false;

					SpikesFront.rollPlay = true;
                        source.Play();
                        Invoke("stopAudio", 3.5f);

                    } else if (HazardSpawner.spikeCount == 1  && HazardSpawner.spikeBool == true) {

					spikes[1] = true;

					HazardSpawner.spikeBool = false;

					SpikesBack.rollPlay = true;

                        source.Play();
                        Invoke("stopAudio", 3.5f);


				} else if (HazardSpawner.spikeCount == 2 && HazardSpawner.spikeBool == true) {

					spikes[0] = true;
					spikes[1] = true;

					HazardSpawner.spikeBool = false;

					SpikesFront.rollPlay = true;

					SpikesBack.rollPlay = true;

                        source.Play();
                        Invoke("stopAudio", 3.5f);
                    }
			}

		}
		}
	}
}
