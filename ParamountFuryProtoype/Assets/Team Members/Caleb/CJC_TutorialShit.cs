using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_TutorialShit : MonoBehaviour {

	[SerializeField]
	GameObject tutorialToShow;

	bool currentlyInTutBox;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" && !currentlyInTutBox)
		{
			currentlyInTutBox = true;
			tutorialToShow.SetActive (true);
			Time.timeScale = 0;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			currentlyInTutBox = false;
		}
	}
}
