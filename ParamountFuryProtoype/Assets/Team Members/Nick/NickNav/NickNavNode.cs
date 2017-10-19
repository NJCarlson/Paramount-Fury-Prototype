using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavNode : MonoBehaviour {

    [SerializeField] bool blocked;
    public int graphindex;
    public List<NickNavNode> Neighbors= new List<NickNavNode>();
    public NickNavNode prev = null;

   // Update is called once per frame
    void Start()
    {
        
            this.GetComponent<SpriteRenderer>().enabled = false;
        
    }

    public int GetGraphIndex()
    {

        return graphindex;
    }

    public Vector3 GetCoordinates()
    {
        return transform.position;
    }
    
    public void Clear()
    {
        prev = null;
    }

    public bool GetBlocked()
    {
        return blocked;
    }


}
