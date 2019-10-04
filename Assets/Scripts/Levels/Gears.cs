using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gears : MonoBehaviour {

	ElevatorMove ElevatorMove;
	EyeSpawn EyeSpawn;
	SoundEffectPlayer SoundEffectPlayer;

	public GameObject fade;

	public AudioSource source;
	public AudioClip scream;

	public Animation anim;
	public Animation anim2;
	public Animation anim3;


	void Start () {

		ElevatorMove = GameObject.Find("Moveable").GetComponent<ElevatorMove>();
		EyeSpawn = GameObject.Find("Enemy Spawns").GetComponent<EyeSpawn>();
		SoundEffectPlayer = GameObject.Find("AudioManager").GetComponent<SoundEffectPlayer>();
	}

	void Update () {

		if (ElevatorMove.incomingSwap == true && !anim.IsPlaying("FIRSTFLOOR_MOVE") && ElevatorMove.level2 == false) {
			StartCoroutine("spinDown");
		}

		if (ElevatorMove.incomingSwap == true && !anim.IsPlaying("SECONDFLOOR_MOVE") && !anim.IsPlaying("FIRSTFLOOR_MOVE") && EyeSpawn.level2Clear == true && ElevatorMove.level3 == false) {
			StartCoroutine("spinDown2");
		}

		if (!anim2.IsPlaying("NEWGEARS_ENGAGE_2ND_FLOOR") && !anim2.IsPlaying("NEWGEARS_ENGAGE_3RD_FLOOR")) {
			anim2.Play("NEWGEARS_ONGOING");
		}

		//if (ElevatorMove.levelSwap == true && !anim.IsPlaying("VertibraeGearsSteadyDown")) {
			//StartCoroutine("spinDown");
		//}
	}

	IEnumerator spinDown () {
		anim.Play("FIRSTFLOOR_MOVE");
		SoundEffectPlayer.StopBackgroundMusic();
		anim2.Play("NEWGEARS_ENGAGE_2ND_FLOOR");
		yield return new WaitForSeconds(4);
		ElevatorMove.levelSwap = true;
		yield return new WaitForSeconds(2);
		//anim.Play("VertibraeGearsSpinDownBackSolo");
		ElevatorMove.incomingSwap = false;
		yield return new WaitForSeconds(1);
		ElevatorMove.level2 = true;
		yield return new WaitForSeconds(4);
		anim3.Play("FloorGraphicChangeFloor2");
		SoundEffectPlayer.StartBackgroundMusic();
		yield break;
	}

	IEnumerator spinDown2 () {
		anim.Play("SECONDFLOOR_MOVE");
		SoundEffectPlayer.StopBackgroundMusic();
		anim2.Play("NEWGEARS_ENGAGE_3RD_FLOOR");
		yield return new WaitForSeconds(4);
		ElevatorMove.levelSwap = true;
		yield return new WaitForSeconds(0.6f);
		//SceneManager.LoadScene("WinScreen 1");
		yield return new WaitForSeconds(2);
		//anim.Play("VertibraeGearsSpinDownBackSolo");
		ElevatorMove.incomingSwap = false;
		yield return new WaitForSeconds(5);
		fade.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		source.clip = scream;
		source.Play();
		ElevatorMove.level3 = true;
		SceneManager.LoadScene("WinScreen 1");
		yield break;
	}

	/*IEnumerator spinUp () {

		anim.Play("VertibraeGearsSpinup");
		ElevatorMove.incomingSwap = false;
		yield break;
	}*/
}
