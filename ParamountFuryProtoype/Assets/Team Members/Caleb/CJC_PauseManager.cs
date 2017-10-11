using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_PauseManager : MonoBehaviour {

	public static bool gamepaused;

	[SerializeField]
	GameObject pausedOBJ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		controlpuased ();
		pausecontrols ();
	}

	void pausecontrols()
	{
		if (Input.GetKeyDown (KeyCode.Escape) | Input.GetKeyDown (KeyCode.P) | Input.GetButtonDown ("360_StartButton"))
		{
			if (gamepaused)
			{
				gamepaused = false;
				pausedOBJ.SetActive (false);
			}
			else if (!gamepaused)
			{
				gamepaused = true;
				pausedOBJ.SetActive (true);
			}
		}
	}

	void controlpuased()
	{
		if (gamepaused) 
		{
			Time.timeScale = 0;
		}
		else if (!gamepaused) 
		{
			Time.timeScale = 1;
		}
	}
}
