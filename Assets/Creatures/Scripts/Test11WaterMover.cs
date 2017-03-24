using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test11WaterMover : MonoBehaviour {

	public GameObject target;
	public Rigidbody root;
	public Rigidbody beatJoint;
	public float upForce = 10f;
	public float waitDelay = 0.1f;
	public bool toMove = false;

	private Vector3 upForceVec;
	private bool inCoroutine = false;

	void Start()
	{
		upForceVec = new Vector3 (0f, upForce, 0f);
	}

	void FixedUpdate()
	{
		root.position = target.transform.position;

		if(toMove)
		{
			if(!inCoroutine)
				StartCoroutine(OnBeat());
			toMove = false;
		}
	}

	IEnumerator OnBeat()
	{
		upForceVec.y = upForce;

		beatJoint.AddForce ( upForceVec, ForceMode.Impulse );

		yield return new WaitForSeconds(waitDelay);
	}
}
