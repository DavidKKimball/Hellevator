using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlumeColliders : MonoBehaviour {

	Collider thinCollider;
	Collider wideCollider;

//Starts the coroutine to spawn the colliders when the fire plume is turned on.
	 void OnEnable() {
		if (this.name == "Fire Collider 1") {
  			thinCollider = GetComponent<CapsuleCollider>();
  			StartCoroutine("frontCollider");
  	   	} else if (this.name == "Fire Collider 2") {
  			wideCollider = GetComponent<CapsuleCollider>();
  			StartCoroutine("endCollider");
  		}
   	}

//Stops the coroutines and turns off the colliders when the fire plume is turned off.
	void OnDisable() {
		if (this.name == "Fire Collider 1") {
			thinCollider.enabled = false;
			StopCoroutine("frontCollider");
		} else if (this.name == "Fire Collider 2") {
			wideCollider.enabled = false;
			StopCoroutine("endCollider");
		}
	}

//Spawns the thin collider at the front of the fire plume after 0.4 seconds.
	 IEnumerator frontCollider () {

		 yield return new WaitForSeconds(0.4f);
		 thinCollider.enabled = true;
	 }

//Spawns the wide collider at the end of the fire plume after 0.8 seconds.
	 IEnumerator endCollider () {

		 yield return new WaitForSeconds(0.8f);
		 wideCollider.enabled = true;
	 }
}
