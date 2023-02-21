using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Unit : UnitInstance
{
    //In here we can possibly put animation starts

    // Start is called before the first frame update
    void Start()
    {
       move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        updateUnitPosition();
    }
}
