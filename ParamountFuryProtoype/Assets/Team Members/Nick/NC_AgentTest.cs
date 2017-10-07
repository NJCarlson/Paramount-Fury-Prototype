using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_AgentTest : MonoBehaviour {


    [SerializeField]
    GameObject waypoint;
    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update ()
    {
        // transform.Translate(waypoint.transform.position.x * Time.deltaTime, waypoint.transform.position.y * Time.deltaTime, 0.0f);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed * Time.deltaTime);
	}
}
