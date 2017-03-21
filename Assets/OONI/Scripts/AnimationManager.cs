using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	public float DelayStart = 0f;
	private Animator animator;

	IEnumerator Start()
	{
		animator = GetComponent<Animator> ();
		yield return new WaitForSeconds (DelayStart);
		animator.SetTrigger ("Transform");

		//StartCoroutine (Reset(10f));
	}

	IEnumerator Reset(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		animator.SetTrigger ("Reset");

		StartCoroutine (Reset(15f));
	}
}
