using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_UML : MonoBehaviour {

	 public string charactername;


	public float movespeed;

	public int playerlives;


	public float health;

	public float healthmax;


	public float furybar;

	public float furybarmax;


	public float staminabar;

	public float staminabarmax;


	public string meleeweapon;

	public float meleedamage;

	public float meleeattackspeed;


	public string gunname;

	public float gundamage;

	public float gunfirerate;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		checkname ();
		checkweapongun ();
		checkmelee ();
	}

	void checkname()
	{
		if (charactername == "jerry")
		{
			meleeweapon = "wrench";
			gunname = "357magnum";
			healthmax = 200;
			staminabarmax = 75;
			movespeed = 4;
			furybarmax = 100;
		}
		else 	if (charactername == "amanda")
		{
			meleeweapon = "brass";
			gunname = "shotgun";
			healthmax = 80;
			staminabarmax = 100;
			movespeed = 8;
			furybarmax = 100;
		}
		else 	if (charactername == "melissa")
		{
			meleeweapon = "knife";
			gunname = "uzi";
			healthmax = 120;
			staminabarmax = 120;
			movespeed = 4;
			furybarmax = 100;
		}
		else 	if (charactername == "justin")
		{
			meleeweapon = "bat";
			gunname = "m4";
			healthmax = 100;
			staminabarmax = 30;
			movespeed = 5;
			furybarmax = 100;
		}
	}

	void checkweapongun()
	{
		if (gunname == "357magnum")
		{
			gunfirerate = .33f;
			gundamage = 125;
		}
		else if (gunname == "shotgun")
		{
			gunfirerate = .5f;
			gundamage = 175;
		} 
		else if (gunname == "uzi")
		{
			gunfirerate = .1f;
			gundamage = 50;
		}
		else 	if (gunname == "m4")
		{
			gunfirerate = .25f;
			gundamage = 100;
		}
	}

	void checkmelee()
	{
		if (gunname == "wrench")
		{
			meleeattackspeed = 1;
			meleedamage = 90;
		}
		else if (gunname == "brass")
		{
			meleeattackspeed = .5f;
			meleedamage = 40;
		} 
		else if (gunname == "knife")
		{
			meleeattackspeed = .25f;
			meleedamage = 40;
		}
		else 	if (gunname == "bat")
		{
			meleeattackspeed = 1;
			meleedamage = 100;
		}
	}
}
