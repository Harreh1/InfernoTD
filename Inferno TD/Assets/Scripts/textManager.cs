﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour {

    public Text money;
    public Text health;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        money.text = "$ " + buildManager.instance.GetMoney();
        health.text = "" + buildManager.instance.GetHealth();
	}
}
