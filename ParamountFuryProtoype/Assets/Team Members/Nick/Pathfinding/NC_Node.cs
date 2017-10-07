using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{

    public List<Node> Neighbors = new List<Node>();
    public Node prev = null;
    public string label = "";

    public void Clear()
    {
        prev = null;
    }

 

}
