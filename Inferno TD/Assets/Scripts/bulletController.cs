using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {
    private float speed;
    private GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            Debug.Log("Bulletmove");
            Debug.Log(target.gameObject.name);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            if (transform.position == target.transform.position)
            {
                Destroy(this.gameObject);
            }
        }

	}

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
