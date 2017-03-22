using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test7Mover : MonoBehaviour {

	public Rigidbody root;
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
		upForceVec.y = upForce;

		root.AddForce ( upForceVec, ForceMode.Impulse );

		forwardForceVec = (target.transform.position - root.gameObject.transform.position).normalized;

		forwardForceVec *= forwardForce;
		forwardForceVec.y = 0f;

		root.AddForce ( forwardForceVec, ForceMode.Impulse );
		root.AddTorque (forwardForceVec, ForceMode.Impulse);

	}
		
}
