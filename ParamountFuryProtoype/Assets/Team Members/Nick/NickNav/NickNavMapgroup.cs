using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavMapgroup : MonoBehaviour {

    private Vector3[] positions;
    private NickNavNode[] nodes;
    private NickNavNode NearestNode;
    private float prevDif = float.MaxValue;

    // Use this for initialization
    void Awake ()
    {
        nodes =  gameObject.GetComponentsInChildren<NickNavNode>();
        positions = new Vector3[nodes.Length];

        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].graphindex = i;
            positions[i] = nodes[i].GetCoordinates();
        }

	}

    public Vector3[] Getpos()
    {
        return positions;
    }

    public NickNavNode GetNearestNode(Vector3 pos)
    {
        NearestNode = new NickNavNode();
        prevDif = float.MaxValue;
       
        for (int i = 0; i < nodes.Length; i++)
        {
            float dif = 0.0f;
            dif = Vector3.Distance(nodes[i].GetCoordinates(), pos); 

            if (dif < prevDif )
            {
                prevDif = dif;
                NearestNode = nodes[i];
            }
        }

        return NearestNode;

    }

}
