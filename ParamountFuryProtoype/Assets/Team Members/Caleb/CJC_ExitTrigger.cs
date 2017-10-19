using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CJC_ExitTrigger : MonoBehaviour {

	[SerializeField]
	string level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "character parent")
		{
			print ("doing the thing");
			SceneManager.LoadScene (level);
		}
	}
}
