using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_HinezController : CJC_UML {

	bool spawned = false;

	public Vector3 movedirection = Vector3.zero;
	public CharacterController controller;

	bool issprinting;
	bool ismoving;

	bool isexhauseted;
	float exhaustiontimermax = 25;
	float exhaustiontimer;

	// Use this for initialization
	void Start ()
	{
		charactername = "jerry";

	}

	void LateStart()
	{
		
	}
	
	void Update ()
	{
		checkname ();
		checkweapongun ();
		checkmelee ();
		checkspawned ();
		controlmovement ();
		controlsprint ();
		controlexhaustion ();
	}

	void checkspawned()
	{
		if (!spawned)
		{
			health = healthmax;
			staminabar = staminabarmax;
			furybar = 0;
			spawned = true;
		}
	}

	void controlmovement()
	{
		movedirection.x = (Input.GetAxis ("Horizontal") * Time.deltaTime * movespeed*15);
		movedirection.x *= movespeed;
		movedirection.y = (Input.GetAxis ("Vertical") * Time.deltaTime * movespeed*15);
		movedirection.y *= movespeed;

		movedirection = transform.TransformDirection (movedirection);
		controller.Move (movedirection * Time.deltaTime);

		if (Input.GetAxis ("Horizontal") > .1f | Input.GetAxis ("Horizontal") < 0 | Input.GetAxis ("Vertical") > .1f | Input.GetAxis ("Vertical") < 0)
		{
			ismoving = true;
		}
		else if (Input.GetAxis ("Horizontal") ==0 && Input.GetAxis ("Vertical") ==0)
		{
			ismoving = false;
		}

	}

	void controlsprint()
	{
		if (Input.GetKey (KeyCode.LeftShift) | Input.GetButton("360_LeftThumbStickButton"))
		{
			if (!isexhauseted)
			{
			if (staminabar <= 0)
			{
				issprinting = false;
				isexhauseted = true;
				staminabar = 0;
			} 
			else if (staminabar > 0)
			{
				issprinting = true;
			}
			}
		}
		else if (Input.GetKeyUp (KeyCode.LeftShift) | Input.GetButtonUp("360_LeftThumbStickButton"))
		{
			issprinting = false;
		}

		if (staminabar <= 0)
		{
			isexhauseted = true;
			staminabar = 0;
		}


		if (!issprinting)
		{
			staminabar += Time.deltaTime*5;
			if (staminabar >= staminabarmax)
			{
				staminabar = staminabarmax;
			}
			movespeed = 4;
		}
		else if (issprinting && ismoving)
		{
			staminabar -= Time.deltaTime*20;
			movespeed = 6;
		}
	}

	void controlexhaustion()
	{
		if (isexhauseted) {
			exhaustiontimer += Time.deltaTime *5;
			if (exhaustiontimer >= exhaustiontimermax) {
				isexhauseted = false;
			}
		} else if (!isexhauseted)
		{
			exhaustiontimer = 0;
		}
	}

	void checkname()
	{
		if (charactername == "jerry")
		{
			meleeweapon = "wrench";
			gunname = "357magnum";
			healthmax = 200;
			staminabarmax = 75;

			furybarmax = 100;
		}
	}

	void checkweapongun()
	{
		if (gunname == "357magnum")
		{
			gunfirerate = .33f;
			gundamage = 175;
		}
	}

	void checkmelee()
	{
		if (meleeweapon == "wrench")
		{
			meleeattackspeed = 1;
			meleedamage = 175;
		}
	}
}
