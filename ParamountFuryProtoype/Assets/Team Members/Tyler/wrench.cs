using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class wrench: MonoBehaviour {

	[SerializeField]
	GameObject playerparent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
    void OnTriggerEnter(Collider other)
    { 
		GameObject jerrbear = playerparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();

        if (other.tag == "enemy")
        {
            GameObject target = other.gameObject;
            Dummy dummyStats = target.GetComponent<Dummy>();
			jerry.furybar += jerry.meleedamage / 20;
			dummyStats.health -= jerry.meleedamage;
        }
    }

}
