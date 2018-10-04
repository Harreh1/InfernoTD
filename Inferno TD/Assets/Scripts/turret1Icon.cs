using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret1Icon : MonoBehaviour {

    public Color hoverColor;
    private SpriteRenderer rend;

    public GameObject turret1;

    private GameObject sampleTurret;
    private bool active;
    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        active = false;
    }

    void Update()
    {
        if (active)
        {
            rend.color = hoverColor;
        } else
        {
            buildManager.instance.SetTurretToBuild(null);
            rend.color = Color.white;
        }
    }
    // Update is called once per frame
    void OnMouseDown()
    {
        if(!active)
        {
            active = true;
            buildManager.instance.SetTurretToBuild(turret1);
        } else
        {
            active = false;
            sampleTurret.SetActive(false);
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

    public void setActive(bool b)
    {
        active = b;
    }
}
