using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CJC_HubClicky : MonoBehaviour {

	[SerializeField]
	string levelToTrans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LevelTransition()
	{
		SceneManager.LoadScene (levelToTrans);
	}
}
