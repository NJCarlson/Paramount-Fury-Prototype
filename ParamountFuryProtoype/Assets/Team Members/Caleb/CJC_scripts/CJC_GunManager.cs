using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_GunManager : MonoBehaviour {

	[SerializeField]
	GameObject jerrygun;
	[SerializeField]
	GameObject jerryprojectile;
	[SerializeField]
	GameObject bulletspawn;

	[SerializeField]
	GameObject playerparent;

	[SerializeField]
	float gundamage;
	[SerializeField]
	float gunspeed;


	[SerializeField]
	float weaponcooldown;


	// Use this for initialization
	void Start () {
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
		if (jerry.furyactive) {
			jerrygun.SetActive (true);
			weaponcooldown += Time.deltaTime;

			if (weaponcooldown >= gunspeed) {
				weaponcooldown = gunspeed;
			}

			if (Input.GetKey (KeyCode.Mouse0) | Input.GetAxis ("360_Triggers") < 0) {
				if (weaponcooldown >= gunspeed) {
					Instantiate (jerryprojectile, bulletspawn.transform.position, bulletspawn.transform.rotation);
					weaponcooldown = 0;
				}
			}
		} else if (!jerry.furyactive)
		{
			jerrygun.SetActive (false);
		}
	}

	void checkforplayerparent()
	{
		GameObject jerrbear = playerparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();

		if (jerry.charactername == "jerry")
		{
			//jerrygun.SetActive (true);
			gundamage = jerry.gundamage;
			gunspeed = jerry.gunfirerate;
		}
	}
}
