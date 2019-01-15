using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Class structured from tutorial by brackeys. Edits have been made beyond basic placing of turret.
//Available at: https://www.youtube.com/watch?v=t7GuWvP_IEQ
//Last accessed 7/09/2018
public class buildManager : MonoBehaviour {

    public static buildManager instance;

    private GameObject turretToBuild;
    public GameObject icon1;
    private int lives;

    private int money;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lives = 10;
        money = 200;
        turretToBuild = null;
    }

    public GameObject GetTurretToBuild()
    {
        icon1.GetComponent<turret1Icon>().setActive(false);
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public int GetMoney()
    {
        return money;
    }

    public void SetMoney(int mon)
    {
        money += mon;

    }
    public int GetHealth()
    {
        return lives;
    }

    public void subtractHealth(int damage)
    {
        lives -= damage;
    }

    public void subtractMoney(int mon)
    {
        money -= mon;
    }

    public void resetButtons()
    {

    }

}
