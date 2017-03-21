using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoint : MonoBehaviour {

	public Rigidbody theJoint;
	public bool toUp = false;

	void FixedUpdate()
	{
		if(toUp)
		{
			theJoint.AddForce ( new Vector3(0,10f,0), ForceMode.Impulse );
			toUp = false;
		}
	}
}
