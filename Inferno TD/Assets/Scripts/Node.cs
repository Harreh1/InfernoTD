using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class based on the tutorial by brackeys.
 * Available at: https://www.youtube.com/watch?v=t7GuWvP_IEQ
 **/

public class Node : MonoBehaviour {

    public Color hoverColor;
    private SpriteRenderer rend;
    private GameObject turretToBuild;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        turretToBuild = buildManager.instance.GetTurretToBuild();

        if (turretToBuild != null)
        {
            buildManager.instance.subtractMoney(turretToBuild.GetComponent<towerController>().getCost());
            turretToBuild = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
            transform.position = new Vector3(transform.position.x, transform.position.y, 3);
        } else
        {

        }

    }

	void OnMouseEnter()
    {
        rend.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.color = Color.white;
    }
}
