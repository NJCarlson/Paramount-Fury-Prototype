using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickNavNode : MonoBehaviour {

    [SerializeField] bool blocked;
    
	
	// Update is called once per frame
	void Update () {
        if (blocked)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
	}
}
