using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_PutTutAway : MonoBehaviour {

	public string TutorialName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Time.timeScale = 0;
		OnButtonPress ();
	}

	void CheckForTutorial()
	{
		GameObject pitbull = GameObject.FindWithTag("GameController");
		CJC_MissionControl mr305 = pitbull.GetComponent<CJC_MissionControl> ();
		GameObject body = GameObject.Find("character parent");
		CJC_HinezController hinez = body.GetComponent<CJC_HinezController> ();

		if (TutorialName == "BodyCount")
		{
			mr305.missionName = "Body Count";
			mr305.KillCountMAX = 5;
		} 
		else if (TutorialName == "PrizedPosessions")
		{
			mr305.missionName = "Prized Posessions";
			mr305.PrizedCollectiblesMAX = 1;
		}
		else if (TutorialName == "Health")
		{
			hinez.health = hinez.healthmax * .8f;
		} 
		else if (TutorialName == "Stamina")
		{
			hinez.staminabar = hinez.staminabarmax / 2;
		}
		else if (TutorialName == "Fury")
		{
			hinez.furybar = 75;
		}
		else if (TutorialName == "ChangeScreen")
		{

		}
	}

	void OnButtonPress()
	{
		if (Input.GetButtonDown ("360_AButton") | Input.GetKeyDown (KeyCode.Return))
		{
			Time.timeScale = 1;
			CheckForTutorial ();
			gameObject.SetActive (false);

		}
	}

	public void OnClickyFuckingClick()
	{
		Time.timeScale = 1;
		CheckForTutorial ();
		gameObject.SetActive (false);
			
	}
}
