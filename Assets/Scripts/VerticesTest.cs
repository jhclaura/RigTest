using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticesTest : MonoBehaviour {

	public Vector3[] vertices;

	private int[] triangels = new int[]
	{
		0, 1, 2
	};

	private Vector3[] normals = new Vector3[]
	{
		Vector3.forward, Vector3.forward, Vector3.forward
	};

	private MeshFilter mf;

	void Start ()
	{
		mf = GetComponent<MeshFilter> ();
		mf.mesh = new Mesh ();
		mf.mesh.vertices = vertices;
		mf.mesh.triangles = triangels;
		mf.mesh.normals = normals;
	}
	
	void Update ()
	{
		if(Input.GetKeyDown("space"))
		{
			vertices = new Vector3[]
			{ 
				Random.insideUnitSphere, Random.insideUnitSphere, Random.insideUnitSphere
			};
			mf.mesh.vertices = vertices;

			Debug.Log ("update!");
		}
	}
}
