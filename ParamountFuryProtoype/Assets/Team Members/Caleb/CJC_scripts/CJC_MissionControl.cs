using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CJC_MissionControl : MonoBehaviour {

	public string[] missiontypes;

	public int missionnumber;
	public string missionName;

	public bool MissionChosen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ChooseMission ();
	}

	void ChooseMission()
	{
		if (!MissionChosen)
		{
			int randIndex = Random.Range (0, missiontypes.Length);
			missionnumber = randIndex;
			MissionChosen = true;
		} 
		else if (MissionChosen)
		{
			if (missionnumber == 0)
			{
				missionName = missiontypes [0];
			}
			else if (missionnumber == 1)
			{
				missionName = missiontypes [1];
			}
			if (missionnumber == 2)
			{
				missionName = missiontypes [2];
			}
			else if (missionnumber == 3)
			{
				missionName = missiontypes [3];
			}

			print ("Mission number selected is" + missionnumber);
		}
	}
}
