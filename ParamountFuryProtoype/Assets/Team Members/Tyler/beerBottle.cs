using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class beerBottle: MonoBehaviour {

	bool broken;
	bool thrown = false;
	bool held = false;
	float speed = 12;
	float destroytimer = .4f;
	[SerializeField]
	AudioClip bottlebreak;
	[SerializeField]
	AudioSource source;




	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject jerrbear = GameObject.Find("character parent");
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();



		if (held == true) {

			transform.localRotation = new Quaternion (0, 0, 1, 1);

			if (Input.GetKeyDown (KeyCode.F) | Input.GetButtonDown ("360_YButton")) {
				transform.parent = null;
				thrown = true;
			}
		}
			
		if (thrown == true && destroytimer > 0)
		{
			transform.position += transform.up * Time.deltaTime * speed;
			destroytimer -= Time.deltaTime;
			held = false;
			jerry.throwableheld = false;
		}
		if (destroytimer <= 0 && !broken) {
			speed = 0;
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			source.PlayOneShot (bottlebreak);
			Destroy(gameObject,bottlebreak.length);
			broken = true;
		}
	}
    void OnTriggerEnter(Collider other)
    {
		GameObject jerrbear = GameObject.Find("character parent");
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();

	
		if (other.name == "wall" && thrown && !broken)
		{
			speed = 0;
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			source.PlayOneShot (bottlebreak);
			Destroy(gameObject,bottlebreak.length);
			broken = true;
		}
		else if (other.name == "enemy" && thrown && !broken)
		{
			GameObject target = other.gameObject;
			Dummy dummyStats = target.GetComponent<Dummy>();
			dummyStats.health -= 50;
			speed = 0;
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			source.PlayOneShot (bottlebreak);
			Destroy(gameObject,bottlebreak.length);
			broken = true;
		}
	}   

	void OnTriggerStay(Collider other)
	{
		GameObject jerrbear = GameObject.Find("character parent");
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();

		if (other.name == "character" && !jerry.throwableheld)
		{
			if (Input.GetKeyUp (KeyCode.F) | Input.GetButtonUp ("360_YButton"))
			{
				transform.parent = other.transform;
				held = true;
				jerry.throwableheld = true;
			}
		}
	}
}
