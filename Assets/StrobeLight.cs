using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour {

	public enum MaskType
	{
		Mesh,
		Shader
	}
	public MaskType maskType = MaskType.Shader;

	public float flashPerSecond = 60f;
	public bool strobeLightOn = false;

	private Renderer renderer;
	private float delay = 0f;
	private Color maskOn;
	private Color maskOff; //transparent
	private float accumulatedTime = 0f;
	private float timeInterval;
	private bool inStrobeMode = false;
	private bool inBlack = false;

	void Start ()
	{
		switch(maskType)
		{
		case MaskType.Mesh:
			renderer = GetComponent<Renderer> ();
			maskOff = renderer.material.color;
			maskOn = new Color (maskOff.a, maskOff.g, maskOff.b, 1f);
			break;

		case MaskType.Shader:
			break;
		}

	}
	
	void Update ()
	{
		if (strobeLightOn)
		{
			if(!inStrobeMode)
				inStrobeMode = true;

			timeInterval = 1f / flashPerSecond;
			accumulatedTime += Time.deltaTime;

			if (accumulatedTime > timeInterval)
			{
				// light:1
				if (renderer != null)
					renderer.material.color = maskOff;
				else
					SteamVR_Fade.Start (Color.clear, 0);

				accumulatedTime = 0f;
				inBlack = true;
			}
			else if(inBlack)
			{
				// light:0
				if (renderer != null)
					renderer.material.color = maskOff;
				else
					SteamVR_Fade.Start (Color.black, 0);

				inBlack = false;
			}
		}
		else if(inStrobeMode)
		{
			Debug.Log ("reset");
			Reset ();
		}
	}

	// === Public functions ===
	public void TurnOnStrobeLight()
	{
		strobeLightOn = true;
		inStrobeMode = true;
	}

	public void TurnOffStrobeLight()
	{
		// reset
		strobeLightOn = false;


		//renderer.material.color = maskOff;
		//accumulatedTime = 0f;
	}

	private void Reset()
	{
		switch(maskType)
		{
		case MaskType.Mesh:
			renderer.material.color = maskOff;
			break;

		case MaskType.Shader:
			SteamVR_Fade.Start(Color.clear, 0);
			break;
		}

		// universal ones
		accumulatedTime = 0f;
		inBlack = false;
		inStrobeMode = false;
	}
}
