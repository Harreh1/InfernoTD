using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerController : MonoBehaviour {

    public float range;
    public float damage;
    public int cost;
    public int level;
    public GameObject bullet;
    private float lastShot = 0.0f;
    private float fireRate = 0.5f;
    public Sprite levelTwoSprite;
    public Sprite levelThreeSprite;
    public GameObject levelTwoBullet;
    public GameObject upgrade;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<CircleCollider2D>().radius = range;
        level = 1;
        upgrade = GameObject.FindGameObjectWithTag("upgrade");

    }
	
	// Update is called once per frame
	void Update () {
        upgrade = GameObject.FindGameObjectWithTag("upgrade");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {

            //If statement taken from https://answers.unity.com/questions/132154/how-to-limit-the-players-rate-of-fire.html 
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
         
        }
    }

    public int getCost()
    {
        return cost;
    }

    public void LevelUp()
    {
        if(level == 1)
        {
            damage *= 1.3f;
            level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelTwoSprite;
            bullet = levelTwoBullet;
        }
        else if (level == 2)
        {
            fireRate *= 0.5f; ;
            level++;
            gameObject.GetComponent<SpriteRenderer>().sprite = levelThreeSprite;
        }

    }

    void OnMouseDown()
    {
        Debug.Log("HIT");
        if(level < 3)
        {
            upgrade.SetActive(true);
            upgrade.GetComponent<upgradeCon>().SetTower(this.gameObject);

        }

    }
}
