using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    //public Text levelText; in case we need this
    public Slider hpSlider;

    public void SetHUD(UnitStats unit) //that way we have access to all the info needed
    {
        nameText.text = unit.unitName;
        //levelText.text = "Lvl " + unit.unitLv;
        hpSlider.maxValue = unit.maxHP; 
        hpSlider.value = unit.Hp;

    }

    public void SetHP(int hp)  //only updates the HP whenever a player gets damaged or heals
    {
        hpSlider.value = hp;
    }
}
