using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {
    public float damage;
    public float speed;
    private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            if (transform.position == target.transform.position)
            {
                target.GetComponent<enemyController>().removeHealth(damage);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

	}
    
    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public void setTarget(GameObject target)
    {
        this.target = target;
    }

}
