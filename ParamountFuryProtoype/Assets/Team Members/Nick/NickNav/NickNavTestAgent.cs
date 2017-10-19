using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavTestAgent : MonoBehaviour {

    [SerializeField] NickNavMain Main;
    [SerializeField] NickNavNode nStart;
    [SerializeField] NickNavNode nEnd;
    [SerializeField] NickNavMapgroup mapgroup;

   [SerializeField] float speed;
   
    Vector3 waypoint;
    Vector3[] NodePos;
    List<NickNavNode> path;
    int pathindex;
    bool reachedgoal;

	// Use this for initialization
	void Start ()
    {
        reachedgoal = false;
        NodePos = mapgroup.Getpos();
        path = Main.Findpath(nStart, nEnd);
        pathindex = 0;
        waypoint = NodePos[path[pathindex].graphindex];
    }
	
	// Update is called once per frame
	void Update ()
    {
        float step = speed * Time.deltaTime;
        waypoint = NodePos[path[pathindex].graphindex];
        transform.position = Vector3.MoveTowards(transform.position, waypoint, step);

        if (transform.position == waypoint && !reachedgoal)
        {
            pathindex++;

            if (pathindex == path.Count-1)
            {
                reachedgoal = true;
            }

        }
    }
}
