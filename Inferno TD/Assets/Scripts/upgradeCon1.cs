using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeCon1 : MonoBehaviour {

    public GameObject tower;

    public GameObject tower1;

    public Text upgradeText;

    void Start()
    {
    }

    void Update()
    {
        if (tower != null)
        {
            if (tower.tag.ToString() == tower1.tag.ToString())
            {
                if (tower.GetComponent<towerController>().getLevel() == 1)
                {
                    upgradeText.text = "Upgrade \ndamage $140";
                }
                else
                {
                    upgradeText.text = "";
                }
            }
        }

    }
    void OnMouseDown()
    {
        if (tower != null)
        {
            if(tower.tag.ToString() == "tower1")
            {
                int level = tower.GetComponent<towerController>().getLevel();
                if (level == 1 || level == 2 || level == 3)
                {
                    if (buildManager.instance.GetMoney() >= 140)
                    {
                        bool b = tower.GetComponent<towerController>().LevelUpDamage();
                        if (b)
                        {
                            buildManager.instance.subtractMoney(140);
                        }
                    }
                }
            }
        }
    }
    
    public void SetTower(GameObject t)
    {
        tower = t;
    }
}
