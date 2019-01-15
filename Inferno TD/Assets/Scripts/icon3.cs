using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icon3 : MonoBehaviour {

    public Text t;
    public GameObject icon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        t.text = "Special turret with low \n range and high damage.\n Can damage invisible units. ";
    }
}
