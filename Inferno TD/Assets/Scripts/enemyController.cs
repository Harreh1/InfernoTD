using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public float Speed;
    private Vector3[] enemyPath = new Vector3[8];
    private int currentTarget = 1;
    private int health = 100;

	// Use this for initialization
	void Start () {
        enemyPath[0] = new Vector3(-1.973324f + 0.43f, -0.5282958f, 0f);
        enemyPath[1] = new Vector3(-0.696f + 0.43f, -0.5282958f, 0f);
        enemyPath[2] = new Vector3(-0.696f + 0.43f, 0.749f, 0f);
        enemyPath[3] = new Vector3(1.213676f + 0.43f, 0.749f, 0f);
        enemyPath[4] = new Vector3(1.213676f + 0.43f, -1.807f, 0f);
        enemyPath[5] = new Vector3(3.128352f + 0.43f, -1.807f, 0f);
        enemyPath[6] = new Vector3(3.128352f + 0.43f, -0.5282958f, 0f);
        enemyPath[7] = new Vector3(5.044f + 0.43f, -0.5282958f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, enemyPath[currentTarget], step);
        if (transform.position == enemyPath[currentTarget])
        {
            currentTarget++;
        }
        if(currentTarget == 8)
        {
            Destroy(this.gameObject);
        }
	}

    public void removeHealth(int damage)
    {
        this.health -= damage;
    }
}
