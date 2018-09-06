using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLoop : MonoBehaviour {

    private SpriteRenderer sp;
    //Variable to check whether value should be added or subracted from RGB. 
    //1 for True
    //0 for False
    private int adding;
	// Use this for initialization
	void Start () {
        sp = gameObject.GetComponent<SpriteRenderer>();
        adding = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Color c = sp.color;
        if (c.b > 1)
        {
            adding = 0;
        }
        if (c.b < 0)
        {
            adding = 1;
        }
        if(adding == 1)
        {
            c.b+=0.01f;
        }
        if(adding == 0)
        {
            c.b-=0.01f;
        }
        sp.color = c;
    }
}
