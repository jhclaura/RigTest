using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test6Mover : MonoBehaviour {

	public Rigidbody root;
	public Rigidbody[] legs;
	public float upForce = 10f;
	public float forwardForce = 2f;

	public GameObject target;

	public bool toMove = false;

	private Vector3 upForceVec;
	private Vector3 forwardForceVec;
	private bool inCoroutine = false;

	void Start()
	{
		upForceVec = new Vector3 (0f, upForce, 0f);
		forwardForceVec = root.gameObject.transform.forward * forwardForce;
	}

	void FixedUpdate()
	{
		if(toMove)
		{
			OnBeat ();
			toMove = false;
		}
	}

	public void OnBeat()
	{
		root.AddForce ( upForceVec, ForceMode.Impulse );

		// legs move 0&2 first, 1&3 second
		if (inCoroutine)
			return;
		
		StartCoroutine( MoveLegs() );
	}

	private IEnumerator MoveLegs()
	{
		inCoroutine = true;
		forwardForceVec = (target.transform.position - root.gameObject.transform.position).normalized;
		forwardForceVec *= forwardForce;

		yield return new WaitForSeconds (1f);

		MoveSingleLeg (0);
		yield return new WaitForSeconds (0.3f);
		MoveSingleLeg (2);

		yield return new WaitForSeconds (1);

		MoveSingleLeg (1);
		yield return new WaitForSeconds (0.3f);
		MoveSingleLeg (3);

		inCoroutine = false;
	}

	private void MoveSingleLeg(int legIndex)
	{
		legs[legIndex].AddForce ( upForceVec, ForceMode.Impulse );
		legs[legIndex].AddForce ( forwardForceVec, ForceMode.Impulse );
	}
}
