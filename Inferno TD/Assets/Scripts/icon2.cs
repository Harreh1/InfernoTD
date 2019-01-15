using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icon2 : MonoBehaviour {

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
        t.text = "Special turret with high \n range and low damage.\n Can damage units with sheilds. ";
    }
}
