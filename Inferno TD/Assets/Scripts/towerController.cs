﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class towerController : MonoBehaviour {

    public int range;
    public int damage;
    public int cost;
    public int level;
    public GameObject bullet;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<CircleCollider2D>().radius = range;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Instantiate(bullet);
            bullet.transform.position = this.gameObject.transform.position;
            //bullet.gameObject.
            //bc.setTarget(collision.gameObject);
        }
    }
}