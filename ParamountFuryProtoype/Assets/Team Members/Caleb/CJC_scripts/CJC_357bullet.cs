using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_357bullet : MonoBehaviour {

	float bulletdamage;
	float bulletspeed = 20;

	float destroytimermax = 3;
	float destroytimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		controlbuttlerkill ();
		controlmovement ();
	}

	void controlmovement()
	{
		transform.position += -transform.up * Time.deltaTime * bulletspeed;
	}

	void controlbuttlerkill()
	{
		destroytimer += Time.deltaTime;
		if (destroytimer >= destroytimermax) 
		{
			Destroy (gameObject, 0);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "wall")
		{
			print ("hitwall");
			Destroy (gameObject, 0);
		}
		else if (other.tag == "enemy")
		{
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<BoxCollider> ().enabled = false;
			Destroy (gameObject, .1f);
		}
	}
}
