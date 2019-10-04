using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	public Transform player;

	void Start () {

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update () {

		//Sets the grunt on a path towards the player.
		agent.SetDestination(player.position);
	}
}
