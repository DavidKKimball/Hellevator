using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	GruntHealth GruntHealth;

	public GameObject model;
    public ParticleSystem jab;

	private Animation anim;

	public bool punching;
	public int attackType;
	public int meleeDamage = 11;
	public float attackDistance;
	public float maxAttackDistance = 2.0f;

	public AudioSource source;
    public AudioClip miss;
    public AudioClip connect;

    void Start () {
		anim = GetComponentInChildren<Animation>();
	}

	void Update () {

		//Uses the "E" key as input for melee punch for now.
		if (Input.GetButton("Punch") && punching == false) {

			punching = true;

			attackType = Random.Range(0, 2);

			if (attackType == 0) {

				anim["Attack1"].speed = 6.0f;
				anim.Play("Attack1");
                jab.Play();
            } else if (attackType == 1) {

				anim["Attack2"].speed = 6.0f;
				anim.Play("Attack2");
                jab.Play();
            }

			playerPunch();
			StartCoroutine("attackDelay");
		}

	}

	public void playerPunch () {

		RaycastHit hit;

        //Checks to see if the Raycast hits.
        if (Physics.Raycast(transform.position, model.transform.TransformDirection(Vector3.forward), out hit)) {

            //Checks to see if the hit collider is an enemy.
            if (hit.collider.tag == "Enemy") {

                //Checks to see how far away the enemy is from the player.
                attackDistance = hit.distance;

                //If the player is close enough to the enemy, the player punches it.
                if (attackDistance < maxAttackDistance) {

                    //Does melee damage to the enemy.
                    if (hit.collider.name == "GruntCollider") {
                        hit.collider.GetComponent<GruntHealth>().gruntHealthCurrent -= meleeDamage;
                        //Debug.Log("Melee attack.");
                    } else if (hit.collider.name == "Eyeball" || hit.collider.name == "Eyeball(Clone)" || hit.collider.name == "Eyeball Tutorial") {
                        hit.collider.GetComponent<EyesHealth>().eyesHealthCurrent -= meleeDamage;
						hit.collider.GetComponent<EyesController>().meleeHit = true;
                        source.clip = connect;
                        source.Play();
                        //ebug.Log("Melee attack.");
                    }
                }
                else
                {
                    source.clip = miss;
                    source.Play();
                }
            }
            else
            {
                source.clip = miss;
                source.Play();
            }
        }
        else
        {
            source.clip = miss;
            source.Play();
        }
	}

	IEnumerator attackDelay () {
		yield return new WaitForSeconds(0.6f);
		punching = false;
		yield break;
	}

}
