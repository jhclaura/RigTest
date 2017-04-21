using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test12Mover : MonoBehaviour {

	public GameObject target;
	public Rigidbody root;
	//public Rigidbody[] beatJoints;
	public Animation talkAnimation;

	public float rotateSpeed = 0.1f;
	public float waitDelay = 0.1f;
	public bool toMove = false;

	public GameObject vinyl;
	public GameObject handle;

	private Vector3 upForceVec;
	private Vector3 downForceVec;
	private bool inCoroutine = false;
	private Vector3 vinylRotation;
	private Vector3 handleDistance;

	void Start()
	{
		//upForceVec = new Vector3 (0f, upForce, 0f);
		//downForceVec = new Vector3 (0f, upForce*-1f, 0f);
		vinylRotation = new Vector3 ();
		handleDistance = root.position - handle.transform.position;
	}

	void Update()
	{
		vinylRotation.y += rotateSpeed * Time.deltaTime;
		vinyl.transform.localEulerAngles = vinylRotation;
	}

	void FixedUpdate()
	{
		root.position = target.transform.position;
		//handle.transform.position = root.position - handleDistance;

		if(toMove)
		{
			if(!inCoroutine)
				StartCoroutine(OnBeat());
			toMove = false;
		}
	}

	IEnumerator OnBeat()
	{
		inCoroutine = true;

		/*
		Vector3 upF = beatJoints [0].transform.up.normalized * upForce;
		Vector3 downF = beatJoints [1].transform.up.normalized * upForce * -1f;
		beatJoints[0].AddForce ( upF, ForceMode.Impulse );
		beatJoints[1].AddForce ( downF, ForceMode.Impulse );
		*/

		talkAnimation.CrossFadeQueued ("TalkAnimationClip", 0.2f, QueueMode.PlayNow);

		yield return new WaitForSeconds(waitDelay);
		inCoroutine = false;
	}
}
