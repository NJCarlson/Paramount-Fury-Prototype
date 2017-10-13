using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class beerBottle: MonoBehaviour {
	
	bool thrown = false;
	bool held = false;
	float speed = 12;
	float destroytimer = .4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (held == true) {
			if (Input.GetKey (KeyCode.F) | Input.GetButton ("360_YButton")) {
				thrown = true;
			}
		}
			
		if (thrown == true && destroytimer > 0) {
			transform.position += transform.up * Time.deltaTime * speed;
			destroytimer -= Time.deltaTime;
			held = false;
		}
		if (destroytimer <= 0) {
			Destroy(gameObject, .1f);
		}
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "character")
        {
			transform.parent = other.transform;
			held = true;
        }
	}   
}
