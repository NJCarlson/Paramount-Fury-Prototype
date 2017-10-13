using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Dummy: MonoBehaviour {

    [SerializeField]
    GameObject[] droppableobjects;
    public float health = 100;
    

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject jerrbear = GameObject.FindWithTag ("GameController");
		CJC_MissionControl jerry = jerrbear.GetComponent<CJC_MissionControl> ();

        if (health <= 0)
        {
            int randindex = Random.RandomRange(0, droppableobjects.Length);
            if (droppableobjects[randindex] != null)
			{
                Instantiate(droppableobjects[randindex], transform.position, transform.rotation);
            }
			if (jerry.missionName == ("Body Count"))
			{
				jerry.KillCountCUR++;
			}
         Destroy(gameObject,0);
        }
	}
}
