using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5Mover : MonoBehaviour {

	public Rigidbody theJoint;
	public bool toUp = false;
	public float upForce = 10f;

	void FixedUpdate()
	{
		if(toUp)
		{
			theJoint.AddForce ( new Vector3(0,upForce,0), ForceMode.Impulse );
			toUp = false;
		}
	}
}
