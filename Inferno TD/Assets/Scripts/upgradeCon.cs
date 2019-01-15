using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeCon : MonoBehaviour {

    public GameObject tower;

    public GameObject tower1;
    public GameObject tower2;
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
                if (tower.GetComponent<towerController>().getLevel() < 3)
                {
                    upgradeText.text = "Upgrade attack \nspeed  $70";
                }
                else
                {
                    upgradeText.text = "";
                }
            }
            if (tower.tag.ToString() == tower2.tag.ToString())
            {
                if (tower.GetComponent<towerController>().getLevel() < 2)
                {
                    upgradeText.text = "Supercharge tower \n$100";
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
                if (level == 1 || level == 2)
                {
                    if (buildManager.instance.GetMoney() >= 70)
                    {
                        bool b = tower.GetComponent<towerController>().LevelUpSpeed();
                        if (b)
                        {
                            buildManager.instance.subtractMoney(70);
                        }
                    }
                }
            }
            if(tower.tag.ToString() == "tower2")
            {
                if(tower.GetComponent<towerController2>().getLevel() == 1)
                {
                    if (buildManager.instance.GetMoney() >= 100)
                    {
                        bool b = tower.GetComponent<towerController2>().LevelUp();
                        if (b)
                        {
                            buildManager.instance.subtractMoney(100);
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
