using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour {

	public float flashPerSecond = 60f;
	public bool strobeLightOn = false;

	private Renderer renderer;
	private float delay = 0f;
	private Color maskOn;
	private Color maskOff; //transparent
	private float accumulatedTime = 0f;
	private float timeInterval;

	void Start ()
	{
		renderer = GetComponent<Renderer> ();

		maskOff = renderer.material.color;
		maskOn = new Color (maskOff.a, maskOff.g, maskOff.b, 1f);

	}
	
	void Update ()
	{
		if (strobeLightOn) {
			timeInterval = 1f / flashPerSecond;

			accumulatedTime += Time.deltaTime;
			//Debug.Log (delay);

			// off
			if (accumulatedTime > timeInterval) {
				renderer.material.color = maskOff;

				accumulatedTime = 0f;
			} else {
				renderer.material.color = maskOn;
			}
		} else {
			// reset
			renderer.material.color = maskOff;
			accumulatedTime = 0f;
		}
	}

	public void TurnOnStrobeLight()
	{
		strobeLightOn = true;
	}

	public void TurnOffStrobeLight()
	{
		// reset
		strobeLightOn = false;
		renderer.material.color = maskOff;
		accumulatedTime = 0f;
	}
}
