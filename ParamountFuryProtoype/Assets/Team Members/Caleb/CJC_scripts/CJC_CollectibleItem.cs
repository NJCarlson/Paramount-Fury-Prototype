using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_CollectibleItem : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{


		transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
		GameObject jerrbear = GameObject.FindWithTag ("GameController");
		CJC_MissionControl jerry = jerrbear.GetComponent<CJC_MissionControl> ();


		if (jerry.missionName != ("Prized Posessions"))
			{
				timer += Time.deltaTime;
			}

		if (timer > 1)
		{
			
			Destroy (gameObject, 0);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			GameObject jerrbear = GameObject.FindWithTag ("GameController");
			CJC_MissionControl jerry = jerrbear.GetComponent<CJC_MissionControl> ();

			if (jerry.missionName == ("Prized Posessions"))
			{
				jerry.PrizedCollectiblesCUR++;
			}
			Destroy (gameObject);
		}
	}
}
