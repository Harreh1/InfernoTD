using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeCon : MonoBehaviour {

    public GameObject tower;

    void Start()
    {
    }

    void OnMouseDown()
    {
        if (tower != null)
        {
            if(buildManager.instance.GetMoney() >= 50)
            {
                tower.GetComponent<towerController>().LevelUp();
                buildManager.instance.subtractMoney(50);
            }
        }
    }
    
    public void SetTower(GameObject t)
    {
        tower = t;
    }
}
