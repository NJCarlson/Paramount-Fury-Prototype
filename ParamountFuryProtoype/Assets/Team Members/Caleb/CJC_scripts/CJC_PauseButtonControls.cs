using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CJC_PauseButtonControls : MonoBehaviour {

	[SerializeField]
	GameObject TurnOBJOff;
	[SerializeField]
	GameObject TurnOBJON;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!CJC_PauseManager.gamepaused)
		{
			TurnOBJOff.SetActive (false);
		}
		
	}

	public void ReturnToHub()
	{
		SceneManager.LoadScene (5);
		CJC_PauseManager.gamepaused = false;
	}
	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene (0);
		CJC_PauseManager.gamepaused = false;
	}

	public void TurnOffAndTurnOn()
	{
		TurnOBJON.SetActive (true);
		TurnOBJOff.SetActive (false);
	}
}
