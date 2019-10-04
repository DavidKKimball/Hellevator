using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour {

	ThirdPersonCamera ThirdPersonCamera;
	BoonSpawner BoonSpawner;
	EyesHealth EyesHealth;
	MeshCollider MeshCollider;
	Sanity Sanity;

	public ParticleSystem eyesBleeding;
	public ParticleSystem eyesHurt;
	private ParticleSystem playerBleeding;

	private Animation[] anim;
	private Animation playeranim;
	private UnityEngine.AI.NavMeshAgent agent;
	private GameObject impBoon;
	private Transform playerN;
	private Transform playerS;
	private Transform playerW;
	private Transform playerE;

	public bool dead;
	public bool eyesAttacking;
	public bool meleeHit;
	public bool littleEyesDead;
	public int didBoonDrop;
	public int eyesHealthTemp;
	public int eyesDamage = 2;

	public AudioSource eyeDie;
	public AudioSource eyeHit;

	void Start () {

		ThirdPersonCamera = GameObject.Find("Main Camera").GetComponent<ThirdPersonCamera>();
		BoonSpawner = GameObject.Find("BoonRNG").GetComponent<BoonSpawner>();
		EyesHealth = GetComponent<EyesHealth>();
		MeshCollider = GetComponentInChildren<MeshCollider>();
		Sanity = GameObject.Find("Player").GetComponent<Sanity>();
		playeranim = GameObject.Find("playermodel").GetComponent<Animation>();
		playerBleeding = GameObject.Find("BloodSplash P").GetComponent<ParticleSystem>();

		anim = GetComponentsInChildren<Animation>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		impBoon = GameObject.Find("ImpBoon");
		playerN = GameObject.Find("enemyTarget_N").GetComponent<Transform>();
		playerS = GameObject.Find("enemyTarget_S").GetComponent<Transform>();
		playerW = GameObject.Find("enemyTarget_W").GetComponent<Transform>();
		playerE = GameObject.Find("enemyTarget_E").GetComponent<Transform>();

		eyesHealthTemp = 66;

        Invoke("turnOnParticles", .5f);
	}

	void Update () {

		if (eyesAttacking == false) {
			int queueRoll = Random.Range(0, 3);

			if (queueRoll == 0) {
				agent.SetDestination(playerN.position);
			} else if (queueRoll == 1) {
				agent.SetDestination(playerS.position);
			} else if (queueRoll == 2) {
				agent.SetDestination(playerW.position);
			} else if (queueRoll == 3) {
				agent.SetDestination(playerE.position);
			}
		}

		//Plays the proper animation for what the agent is doing.
		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					//anim.Play("Eyeball Better Idle");
				}
			}

		} else {
			if (dead == false) {
				anim[1].Play("Eyeball Better Move");
			}
		}

		if (eyesHealthTemp > EyesHealth.eyesHealthCurrent && dead == false) {
            eyesBleeding.Play();
			eyesHurt.Play();
			anim[1].Play("Eyeball Better Take Damage");
			eyesHealthTemp = EyesHealth.eyesHealthCurrent;
		} else if (dead == false && meleeHit == true) {
            eyesBleeding.Play();
			eyesHurt.Play();
			anim[1].Play("Eyeball Better Take Damage");

			if (littleEyesDead == false) {
				anim[0].Play("Eyeball Group Death");
				littleEyesDead = true;
			}
			
			meleeHit = false;
			eyesHealthTemp = EyesHealth.eyesHealthCurrent;
		} else if (EyesHealth.eyesDied == true && dead == false) {
			MeshCollider.enabled = false;
			dead = true;
			eyeDie.Play();
			anim[1].Play("Eyeball Death");
			//anim[0].Play("Eyeball Group Death");
			agent.isStopped = true;

			if (BoonSpawner.impBoonDropped == false) {
				didBoonDrop = Random.Range(0, 20);

				if (didBoonDrop < 4) {
					BoonSpawner.impBoonDropped = true;
					Debug.Log("Imp Boon Dropped");
					impBoon.GetComponent<SphereCollider>().enabled = true;
					impBoon.GetComponent<MeshRenderer>().enabled = true;
				}
			}
		}
	}

    public void turnOnParticles()
    {
        eyesHurt.gameObject.SetActive(true);
		eyesBleeding.gameObject.SetActive(true);
    }

	public void OnTriggerEnter (Collider collider) {

		if (collider.tag == "EnemyTarget" && dead == false) {
			agent.isStopped = true;
			StartCoroutine("EyesAttack");
		}
	}

	public void OnTriggerExit (Collider collider) {
		if (collider.tag == "EnemyTarget") {
			eyesAttacking = false;
			StopCoroutine("EyesAttack");

			if (dead == false) {
				agent.isStopped = false;
				anim[1].Play("Eyeball Better Move");
			}
		}
	}

	IEnumerator EyesAttack () {

		while (Sanity.playerSanityCurrent > 0) {
			eyesAttacking = true;
			yield return new WaitForSeconds(1);
			if (!anim[1].IsPlaying("Eyeball Attack") && Sanity.playerSanityCurrent > 0) {
				playeranim["Hurt"].speed = 7.0f;
				playeranim.Play("Hurt");
				playerBleeding.Play();
				Sanity.playerSanityCurrent -= eyesDamage;
				anim[1].Play("Eyeball Attack");
				eyeHit.Play();
   			}
		}

		if (Sanity.playerSanityCurrent <= 0) {
			eyesAttacking = false;
			anim[1].Play("Eyeball Better Idle");
		}

	}
}
