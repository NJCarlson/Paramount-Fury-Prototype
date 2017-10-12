using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class healthDrop: MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CJC_HinezController player = other.GetComponent<CJC_HinezController>();
            if (player != null && player.health > 0)
            {
                player.health += 10;
                Destroy(gameObject, .1f);

            }
        }
    }

}
