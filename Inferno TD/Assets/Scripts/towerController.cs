﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerController : MonoBehaviour {

    public float range;
    public float damage;
    public int cost;
    public int level =1;
    public GameObject bullet;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;
    public Sprite levelTwoSprite;
    public Sprite levelThreeSprite;
    public Sprite levelFourSprite;
    public GameObject levelTwoBullet;
    public GameObject upgrade;
    public GameObject upgrade2;
    public GameObject rangeIndicator;
    private SpriteRenderer rangeSprite;
    int init = 0;
    public GameObject rangeCircle;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<CircleCollider2D>().radius = range;
        level = 1;
        upgrade = GameObject.FindGameObjectWithTag("upgrade");
        GameObject rangeCircle = Instantiate(rangeIndicator);
        rangeCircle.transform.SetParent(this.transform);
        rangeCircle.transform.localPosition = new Vector3(0, 0, -7);
        rangeCircle.transform.localScale += new Vector3((float)10.6 * range, (float)10.6 * range, 0);
        rangeSprite = rangeCircle.GetComponent<SpriteRenderer>();
        rangeSprite.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        upgrade = GameObject.Find("upgradebox");

        upgrade2= GameObject.Find("upgradebox2");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //(How to set the fire rate) retreived from unity answers: How to limit the players rate of fire
            //Only the if statement taken from https://answers.unity.com/questions/132154/how-to-limit-the-players-rate-of-fire.html 
            //Last accessed 06/09/2018
            if (Time.time > fireRate + lastShot)
            {
                //Code to rotate turret to face target taken from https://answers.unity.com/questions/1350050/how-do-i-rotate-a-2d-object-to-face-another-object.html
                Vector3 targ = collision.transform.position;
                targ.z = 0f;
                Vector3 objectPos = transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;
                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));


                GameObject bulletInGame = Instantiate(bullet);
                bulletInGame.transform.position = this.gameObject.transform.position;
                bulletInGame.GetComponent<bulletController>().setTarget(collision.gameObject);
                bulletInGame.GetComponent<bulletController>().setDamage(damage);
                lastShot = Time.time;
            }
         
        }
        if (collision.gameObject.tag == "shield")
        {
            //(How to set the fire rate) retreived from unity answers: How to limit the players rate of fire
            //Only the if statement taken from https://answers.unity.com/questions/132154/how-to-limit-the-players-rate-of-fire.html 
            //Last accessed 06/09/2018
            if (Time.time > fireRate + lastShot)
            {
                //Code to rotate turret to face target taken from https://answers.unity.com/questions/1350050/how-do-i-rotate-a-2d-object-to-face-another-object.html
                Vector3 targ = collision.transform.position;
                targ.z = 0f;
                Vector3 objectPos = transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;
                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


                GameObject bulletInGame = Instantiate(bullet);
                bulletInGame.transform.position = this.gameObject.transform.position;
                bulletInGame.GetComponent<bulletController>().setTarget(collision.gameObject);
                bulletInGame.GetComponent<bulletController>().setDamage(0);
                lastShot = Time.time;
            }

        }
    }

    public int getCost()
    {
        return cost;
    }

    public int getLevel()
    {
        return level;
    }
    public bool LevelUpSpeed()
    {
        if(level == 1)
        {
            damage *= 0.8f;
            fireRate *= 0.5f;
            level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelTwoSprite;
            return true;
        }
        else if (level == 2)
        {
            damage *= 0.8f;
            fireRate *= 0.5f;
            level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelThreeSprite;
            return true;
        }
        return false;

    }

    public bool LevelUpDamage()
    {
        if (level == 1)
        {
            damage *= 4f;
            fireRate *= 3f;
            level = 4;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelFourSprite;
            bullet = levelTwoBullet;
            return true;
        }
        return false;

    }

    void OnMouseDown()
    {
        Debug.Log("HIT");
        if(level < 5)
        {
            upgrade.GetComponent<upgradeCon>().SetTower(this.gameObject);
            upgrade2.GetComponent<upgradeCon1>().SetTower(this.gameObject);
            //rangeSprite.enabled = true;
        }

    }
}
