using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_MeleeWeaponManager : MonoBehaviour {

	[SerializeField]
	GameObject jerrymelee;

	[SerializeField]
	GameObject playerparent;

	[SerializeField]
	float weapondamage;
	[SerializeField]
	float weaponspeed;

	Animator weaponanim;

	[SerializeField]
	float weaponcooldown;


	// Use this for initialization
	void Start () {
		weaponanim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkforplayerparent ();
		controlmeleeattack ();
	}

	void controlmeleeattack()
	{
		GameObject jerrbear = playerparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();
		if (!jerry.furyactive)
		{

			weaponcooldown += Time.deltaTime;

			if (weaponcooldown >= weaponspeed) {
				weaponcooldown = weaponspeed;
			}

			if (Input.GetKey (KeyCode.Mouse0) | Input.GetAxis ("360_Triggers") < 0) {
				if (weaponcooldown >= weaponspeed) {

					weaponanim.SetBool ("attackmade", true);
					weaponcooldown = 0;
				}
			}
		}
	}

	public void resetweapon()
	{
		weaponanim.SetBool ("attackmade", false);
	}

	void checkforplayerparent()
	{
		GameObject jerrbear = playerparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();

		if (jerry.charactername == "jerry")
		{
			jerrymelee.SetActive (true);
			weapondamage = jerry.meleedamage;
			weaponspeed = jerry.meleeattackspeed;
		}
	}
}
