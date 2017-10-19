using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CJC_MissionControl : MonoBehaviour {

	public string[] missiontypes;

	public int missionnumber;
	public string missionName;

	public bool MissionChosen;

	public int PrizedCollectiblesCUR;
	public int PrizedCollectiblesMAX;

	public int KillCountCUR;
	public int KillCountMAX;

	public int MessagesSentCUR;
	public int MessagesSentMAX;

	public bool HVTkilled;

	public int missionsCompleted;
	public int missionsRequired;
	public bool missioncompleted;

	public string CurrentLevel;



	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CurrentLevel != "Tutorial")
		{

			ChooseMission ();
			checkforMissionComplete ();

	
			if (missionName == "Body Count")
			{
				BodyCountMission ();
			} else if (missionName == "Prized Posessions")
			{
				PrizedPosessionMission ();
			} else if (missionName == "Send A Message")
			{
				SendAMessageMission ();
			}
			else if (missionName == "High Value Target")
			{
				HVTMission ();
			}
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
		missionsRequired = 1;



		if (missionsCompleted >= 1)
		{
			missioncompleted = true;
			print ("mission complete");
		}
	}

	void BodyCountMission()
	{
		//print ("body count mission active");
		KillCountMAX = 25;

		if (KillCountCUR >= KillCountMAX)
		{
			KillCountCUR = KillCountMAX;
		}
		else if (KillCountCUR < 0)
		{
			KillCountCUR = 0;
		}


		if (!missioncompleted)
		{

			if (KillCountCUR >= KillCountMAX)
			{
				missionsCompleted += 1;
				KillCountCUR = KillCountMAX;
			}
		}


	}

	void PrizedPosessionMission()
	{
		//print ("prized posession mission active");
		PrizedCollectiblesMAX = 3;

		if (PrizedCollectiblesCUR >= PrizedCollectiblesMAX)
		{
			PrizedCollectiblesCUR = PrizedCollectiblesMAX;
		}
		else if (PrizedCollectiblesCUR < 0)
		{
			PrizedCollectiblesCUR = 0;
		}


		if (!missioncompleted)
		{

			if (PrizedCollectiblesCUR >= PrizedCollectiblesMAX)
			{
				missionsCompleted += 1;
				PrizedCollectiblesCUR = PrizedCollectiblesMAX;
			}
		}
	}

	void SendAMessageMission()
	{
		//print ("send a message mission active");
		MessagesSentMAX = 10;

		if (MessagesSentCUR >= MessagesSentMAX)
		{
			MessagesSentCUR = MessagesSentMAX;
		}
		else if (MessagesSentCUR < 0)
		{
			MessagesSentCUR = 0;
		}


		if (!missioncompleted)
		{

			if (MessagesSentCUR >= MessagesSentMAX)
			{
				missionsCompleted += 1;
				MessagesSentCUR = MessagesSentMAX;
			}
		}
	}

	void HVTMission()
	{
		//print ("HVT mission active");
		if (!missioncompleted) {
			if (HVTkilled) {
				missionsCompleted += 1;
			}
		}

	}
}
