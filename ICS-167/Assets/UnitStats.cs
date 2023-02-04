using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public string unitName;
    //public int unitLv;

    public int damage = 5;


    public int maxHP = 30;
    public int Hp = 10; //currentHp

    public bool TakeDamage(int dmg)
    {
        Hp -= dmg; 

        if(Hp <= 0)  //checks if the unit has died
        {
            return true;
        }
        else 
            return false;  //false if it hasnt 
    }

    /** public void Heal(int amount)
    {
        Hp += amount;
        if(Hp > maxHP)
        {
            Hp = maxHP;
        }
    }
    **/
}
