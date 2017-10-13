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
	void Update () {
		
	}

	void UpdateKillCount(string value)
	{
		GameObject jerrbear = GameObject.FindWithTag ("GameController");
		CJC_MissionControl jerry = jerrbear.GetComponent<CJC_MissionControl> ();

		//KillCountText += value;
	}
}
