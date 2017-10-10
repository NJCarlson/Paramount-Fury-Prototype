using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_CheckforController : MonoBehaviour {

	public static bool controlleractive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TestForController ();
	}

	void TestForController()
	{
		string[] temp = Input.GetJoystickNames ();

		if (temp.Length > 0)
		{
			for (int i = 0; i < temp.Length; i++)
			{
				if (!string.IsNullOrEmpty (temp [i]))
				{
					controlleractive = true;
					print ("controller plugged in, hiding mouse");
				}
				else 
				{
					controlleractive = false;
					print ("controller not plugged in, not showing mouse");
				}
			}
		}
	}
}
