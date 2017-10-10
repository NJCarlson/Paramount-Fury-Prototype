using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_cameraTrans : MonoBehaviour {

	[SerializeField]
	GameObject cameraobj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			cameraobj.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			cameraobj.SetActive (false);
		}
	}
}
