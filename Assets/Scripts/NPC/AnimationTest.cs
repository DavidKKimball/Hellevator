using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour {

	public GameObject testObject;

	void Start () {
		PrintAnimations(testObject);
	}

	public void PrintAnimations(GameObject character)
	{
		Animation anim = character.GetComponent<Animation>();

	    foreach(AnimationState state in anim)
	    {
	    	Debug.Log(state.name);
	    }

		anim.Play("Eyeball Better Move");
	}
}
