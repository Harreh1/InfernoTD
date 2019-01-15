using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerController2 : MonoBehaviour {

    public float range;
    public float damage;
    public int cost;
    public int level =1;
    public GameObject bullet;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;
    public Sprite levelTwoSprite;
    public Sprite levelThreeSprite;
    public GameObject levelTwoBullet;
    public GameObject upgrade;
    public GameObject rangeIndicator;
    private SpriteRenderer rangeSprite;

    public GameObject powerUP;
    int init = 0;
    public GameObject rangeCircle;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<CircleCollider2D>().radius = range;
        level = 1;
        upgrade = GameObject.FindGameObjectWithTag("upgrade");

    }
	
	// Update is called once per frame
	void Update () {
        upgrade = GameObject.Find("upgradebox");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "invis")
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
                //


                GameObject bulletInGame = Instantiate(bullet);
                bulletInGame.transform.position = this.gameObject.transform.position;
                bulletInGame.GetComponent<bulletController>().setTarget(collision.gameObject);
                bulletInGame.GetComponent<bulletController>().setDamage(damage);
                lastShot = Time.time;
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
    }

    public int getCost()
    {
        return cost;
    }

    public int getLevel()
    {
        return level;
    }
    public bool LevelUp()
    {
        if(level == 1)
        {
            damage *= 2f;
            level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelTwoSprite;
            bullet = levelTwoBullet;
            powerUP.GetComponent<SpriteRenderer>().enabled = true;
            return true;
        }
        return false;

    }

    void OnMouseDown()
    {
        Debug.Log("HIT");
        if(level < 2)
        {
            upgrade.SetActive(true);
            upgrade.GetComponent<upgradeCon>().SetTower(this.gameObject);
            //rangeSprite.enabled = true;
        }

    }
}
