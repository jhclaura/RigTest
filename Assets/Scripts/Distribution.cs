using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribution : MonoBehaviour {

	public List<GameObject> stuffs;
	public float radius = 3f;
	public bool rotateMode = true;
	[Tooltip("how many revolutions per second")]
	public float revolutions = 60f;

	private float speed;

	void Start ()
	{
		stuffs = new List<GameObject> ();
		int amount = transform.childCount;

		for(int i=0; i<amount; i++)
		{
			var child = transform.GetChild (i).gameObject;

			child.transform.position = new Vector3 (
				Mathf.Sin(Mathf.PI*2/amount*i) * radius,
				transform.position.y,
				Mathf.Cos(Mathf.PI*2/amount*i) * radius
			);
			child.transform.eulerAngles = new Vector3 (0f, 360f/amount*i+90f, 0f);
			stuffs.Add (child);
		}

		/*
		creatureMesh.position.x = Math.sin((360/12*0)*(Math.PI/180))*radiusC;
		creatureMesh.position.z = Math.sin((Math.PI/2 + (360/12*0)*(Math.PI/180)))*radiusC;
		creatureMesh.position.y = posYC;
		creatureMesh.rotation.y = (360/12*0+90)*(Math.PI/180);
		*/

	}

	void Update()
	{
		speed = revolutions * 360f;

		//float rotationValue = speed * Time.deltaTime;
		transform.Rotate (Vector3.up * Time.deltaTime * speed);
	}

}
