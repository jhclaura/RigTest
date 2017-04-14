using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour {

	public float speed = 0.1f;

	public bool strobeLightOn = false;
	private Renderer renderer;
	private float delay = 0f;

	void Start ()
	{
		renderer = GetComponent<Renderer> ();
	}
	
	void Update ()
	{
		if (strobeLightOn)
		{
			delay += (speed * Time.deltaTime);
			Debug.Log (delay);

			// off
			if(delay > 1f)
			{
				renderer.enabled = true;

				delay = 0f;
			}
			else
			{
				if(renderer.enabled)
					renderer.enabled = false;
			}
		}
	}

	public void TurnOnStrobeLight()
	{
		strobeLightOn = true;
	}

	public void TurnOffStrobeLight()
	{
		strobeLightOn = false;
		renderer.enabled = true;
	}
}
