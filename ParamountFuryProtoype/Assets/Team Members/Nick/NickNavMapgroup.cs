using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavMapgroup : MonoBehaviour {

    public Vector3[] positions;

    // Use this for initialization
    void Start ()
    {
        NickNavNode[] nodes =  gameObject.GetComponentsInChildren<NickNavNode>();
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

}
