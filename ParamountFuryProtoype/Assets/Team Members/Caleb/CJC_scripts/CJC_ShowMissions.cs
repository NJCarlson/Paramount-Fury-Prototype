using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class CJC_ShowMissions : MonoBehaviour {

	[SerializeField]
	Text KillCountText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject jerrbear = GameObject.FindWithTag ("GameController");
		CJC_MissionControl jerry = jerrbear.GetComponent<CJC_MissionControl> ();

		if (jerry.missionName == "Body Count")
		{
			if (!jerry.missioncompleted)
			{
				UpdateKillCount ("Enemies Killed: " + jerry.KillCountCUR + "/" + jerry.KillCountMAX);
			}
			else if (jerry.missioncompleted)
			{ 
				UpdateKillCount ("Mission Complete!");
			}
		}
		else if (jerry.missionName == "Prized Posessions")
		{
			if (!jerry.missioncompleted)
			{
				UpdateKillCount ("ObjectsCollected: " + jerry.PrizedCollectiblesCUR + "/" + jerry.PrizedCollectiblesMAX);
			}
		else if (jerry.missioncompleted)
			{ 
				UpdateKillCount ("Mission Complete!");
			}
		}
		else if (jerry.missionName == "Send A Message")
		{
			if (!jerry.missioncompleted)
			{
				UpdateKillCount ("Objects Broken: " + jerry.MessagesSentCUR + "/" + jerry.MessagesSentMAX);
			}
		else if (jerry.missioncompleted)
			{ 
				UpdateKillCount ("Mission Complete!");
			}
		}
		else if (jerry.missionName == "High Value Target")
		{
			if (!jerry.missioncompleted)
			{
				UpdateKillCount ("Boss killed = " + jerry.HVTkilled);
			}
		else if (jerry.missioncompleted)
			{ 
				UpdateKillCount ("Mission Complete!");
			}
		}
	}

	void UpdateKillCount(string value)
	{
		
		KillCountText.text = value;
	}
}
