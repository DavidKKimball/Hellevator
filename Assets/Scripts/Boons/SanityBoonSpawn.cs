using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityBoonSpawn : MonoBehaviour {

	BoonSpawner BoonSpawner;

	public GameObject[] sanityBoons;

	public bool[] sanityBs;

	void Start () {

		BoonSpawner = GameObject.Find("BoonRNG").GetComponent<BoonSpawner>();

		sanityBs = new bool[22];

		for (int i = 0; i < 22; i++) {
			sanityBs[i] = false;
		}
	}


	void Update () {

		for (int i = 0; i < 22; i++) {
			if (BoonSpawner.sanityBoonRNG < 6 && sanityBs[i] == false) {

				if (BoonSpawner.sanitySpawn == i) {

					sanityBs[i] = true;
					sanityBoons[i].SetActive(true);
					sanityBoons[i].GetComponent<ParticleSystem>().Play();

					StartCoroutine(Despawn(i));
				}
			}
		}

	}

//Despawns the boon after 20 seconds of not being picked up.
	IEnumerator Despawn (int i) {
			yield return new WaitForSeconds(17);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();
			yield return new WaitForSeconds(0.5f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();
			yield return new WaitForSeconds(0.5f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();
			yield return new WaitForSeconds(0.5f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();
			yield return new WaitForSeconds(0.5f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();
			yield return new WaitForSeconds(0.5f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
			sanityBoons[i].GetComponent<ParticleSystem>().Stop();
			yield return new WaitForSeconds(0.2f);
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[0].enabled = true;
			sanityBoons[i].GetComponentsInChildren<MeshRenderer>()[1].enabled = true;
			sanityBoons[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
			sanityBoons[i].GetComponent<ParticleSystem>().Play();

			if (sanityBs[i] == true) {
				sanityBoons[i].SetActive(false);
				yield break;
			}
	}
}
