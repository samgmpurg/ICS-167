using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpManager : MonoBehaviour
{
    public Slider hpSlider;  //where we can store the slider to use
    public GameObject enemy1;  //to the unity(s) we want to apply these values

    private void Start()
    {
        hpSlider.value = 100;  //setting the value to 100
    }

    private void Update()
    {
        hpSlider.value = enemy1.GetComponent<GameStateManger>().enemyHP;

    }

}
