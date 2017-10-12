using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavNode : MonoBehaviour {

    [SerializeField] bool blocked;
    [SerializeField] int row, column;
    public List<Node> Neighbors = new List<Node>();
    public Node prev = null;

    // Update is called once per frame
    //   void Update () {
    //       if (blocked)
    //       {
    //           this.GetComponent<SpriteRenderer>().color = Color.red;
    //       }
    //}

    public void Clear()
    {
        prev = null;
    }

    public bool GetBlocked()
    {
        return blocked;
    }

    public void setrowcol(int r, int c)
    {
        row = r;
        column = c;
    }

}
