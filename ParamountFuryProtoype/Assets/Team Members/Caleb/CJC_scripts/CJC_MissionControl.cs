using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CJC_MissionControl : MonoBehaviour {

	public string[] missiontypes;

	public int missionnumber;
	public string missionName;

	public bool MissionChosen;

	public int PrizedCollectiblesCUR;
	int PrizedCollectiblesMAX;

	public int KillCountCUR;
	public int KillCountMAX;

	public int MessagesSentCUR;
	public int MessagesSentMAX;

	public bool HVTkilled;

	public int missionsCompleted;
	public bool missioncompleted;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		ChooseMission ();
		checkforMissionComplete ();

		if (missionName == "Body Count")
		{
			BodyCountMission ();
		} 
		else if (missionName == "Prized Posessions")
		{
			PrizedPosessionMission ();
		} 
		else if (missionName == "Send A Message")
		{
			SendAMessageMission ();
		} 
		else if (missionName == "High Value Target")
		{
			HVTMission ();
		}
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
		}
	}

	void checkforMissionComplete()
	{
		
	}

	void BodyCountMission()
	{
		print ("body count mission active");
		KillCountMAX = 25;


		if (!missioncompleted)
		{

			if (KillCountCUR == KillCountMAX)
			{
				missionsCompleted += 1;
			}
		}
	}

	void PrizedPosessionMission()
	{
		print ("prized posession mission active");
	}

	void SendAMessageMission()
	{
		print ("send a message mission active");
	}

	void HVTMission()
	{
		print ("HVT mission active");
	}
}
