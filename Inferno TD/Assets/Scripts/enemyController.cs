using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {

    public float Speed;
    public int value;
    private Vector3[] enemyPath = new Vector3[8];
    private int currentTarget = 1;
    private float health = 100f;
    private float MaxHealth = 100f;
    public Slider healthBar;
    public GameObject canvas;
    private Slider currentHealthbar;
	// Use this for initialization
	void Start () {
        enemyPath[0] = new Vector3(-1.973324f + 0.43f, -0.5282958f, 0f);
        enemyPath[1] = new Vector3(-0.696f + 0.43f, -0.5282958f, 0f);
        enemyPath[2] = new Vector3(-0.696f + 0.43f, 0.749f, 0f);
        enemyPath[3] = new Vector3(1.213676f + 0.43f, 0.749f, 0f);
        enemyPath[4] = new Vector3(1.213676f + 0.43f, -1.807f, 0f);
        enemyPath[5] = new Vector3(3.128352f + 0.43f, -1.807f, 0f);
        enemyPath[6] = new Vector3(3.128352f + 0.43f, -0.5282958f, 0f);
        enemyPath[7] = new Vector3(4.405676f + 0.43f, -0.5282958f, 0f);

        currentHealthbar = Instantiate(healthBar);
        currentHealthbar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        currentHealthbar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

    }
	
	// Update is called once per frame
	void Update () {
        currentHealthbar.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        currentHealthbar.value = health / MaxHealth;
        checkHealth();
        float step = Speed * Time.deltaTime;
        this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, enemyPath[currentTarget], step);
        if (transform.position == enemyPath[currentTarget])
        {
            currentTarget++;
        }
        if(currentTarget == 8)
        {
            buildManager.instance.subtractHealth(1);
            Destroy(this.gameObject);
            Destroy(currentHealthbar.gameObject);
        }
	}

    public void removeHealth(float damage)
    {
        this.health -= damage;
    }

    public void checkHealth()
    {
        if(health <= 0)
        {
            buildManager.instance.SetMoney(value);
            Destroy(this.gameObject);
            Destroy(currentHealthbar.gameObject);
        }
    }
}
