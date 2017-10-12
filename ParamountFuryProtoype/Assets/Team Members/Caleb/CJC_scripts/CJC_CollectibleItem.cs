using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_CollectibleItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy (gameObject);
		}
	}
}
