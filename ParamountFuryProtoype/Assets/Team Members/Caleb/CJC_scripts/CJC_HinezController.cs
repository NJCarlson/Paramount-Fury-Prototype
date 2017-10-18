using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class CJC_HinezController : CJC_UML {

	bool spawned = false;

	public Vector3 movedirection = Vector3.zero;
	public CharacterController controller;

	public bool throwableheld;

	public bool furyactive;

	bool issprinting;
	bool ismoving;
	public bool hasdied;

	bool isexhauseted;
	float exhaustiontimermax = 25;
	float exhaustiontimer;

	AudioSource playersound;
	[SerializeField]
	AudioClip deathsound;
	[SerializeField]
	AudioClip ouch;

	float damagetimer;
	bool gothit;

	public Animator corecharacteranim;
	[SerializeField]
	GameObject completiontext;


	// Use this for initialization
	void Start ()
	{
		corecharacteranim = gameObject.GetComponent<Animator> ();
		playersound = gameObject.GetComponent<AudioSource> ();
		charactername = "jerry";
		playerlives = 3;
	}

	void refreshdamage()
	{
		if (gothit)
		{
			damagetimer += Time.deltaTime;

			if (damagetimer >= 1)
			{
				damagetimer = 0;
				gothit = false;
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "enemy" && !gothit)
		{
			playersound.PlayOneShot (ouch);
			furybar += 2.5f;
			if (!furyactive) {
				health -= 20;
			} else if (furyactive)
			{
				health -= 10;
			}
			gothit = true;
		}
	}
	
	void Update ()
	{
		GameObject pitbull = GameObject.FindWithTag("GameController");
		CJC_MissionControl mr305 = pitbull.GetComponent<CJC_MissionControl> ();

		if (!hasdied && !mr305.missioncompleted)
		{
			refreshdamage ();
			checkname ();
			checkweapongun ();
			checkmelee ();
			checkspawned ();
			controlmovement ();
			controlsprint ();
			controlexhaustion ();
			controlfury ();
			ManageHealth ();
		}

		Managelives ();
		CheckForMissioncomplete ();
	}

	void CheckForMissioncomplete()
	{
		GameObject pitbull = GameObject.FindWithTag("GameController");
		CJC_MissionControl mr305 = pitbull.GetComponent<CJC_MissionControl> ();

		if (mr305.missioncompleted)
		{
			corecharacteranim.SetBool ("MissionCompleted", true);
		}
	}

	public void TransitionToHub()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (5);
	}

	void Managelives()
	{
		if (playerlives <= 0)
		{
			
		}
	}

	void ManageHealth()
	{
		

		if (health >= healthmax)
		{
			health = healthmax;
		} 
		else if (health <= 0)
		{
			
			health = 0;
			hasdied = true;
			playersound.PlayOneShot (deathsound);
			Invoke ("DoDeath", .5f);
		}
	}

	void DoDeath()
	{
		playerlives--;
		health = healthmax;
		staminabar = staminabarmax;
		furybar += 75;
		hasdied = false;
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

	void controlfury()
	{
		if (!furyactive)
		{

			furybar += Time.deltaTime;

			if (furybar >= furybarmax)
			{
				furybar = furybarmax;
			} 
			else if (furybar <= 0)
			{
				furybar = 0;
			}


			if (Input.GetKeyDown (KeyCode.Space) | Input.GetButtonDown ("360_XButton")) {
				if (furybar >= furybarmax / 2) {
					furyactive = true;
				}
			}
		}
		else if (furyactive)
		{
			furybar -= Time.deltaTime*10;
			health += Time.deltaTime * 2.5f;

			if (furybar <= 0)
			{
				furybar = 0;
				furyactive = false;
			}
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
			gundamage = 125;
		}
	}

	void checkmelee()
	{
		if (meleeweapon == "wrench")
		{
			meleeattackspeed = 1;
			meleedamage = 90;
		}
	}
}
