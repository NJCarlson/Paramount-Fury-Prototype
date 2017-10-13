using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class wrench: MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "enemy")
        {
            GameObject target = other.gameObject;
            Dummy dummyStats = target.GetComponent<Dummy>();
            dummyStats.health -= 50;
        }
    }

}
