using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icon1 : MonoBehaviour {

    public Text t;
    public GameObject icon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        t.text = "Basic turret with medium \n range and medium damage. ";
    }
}
