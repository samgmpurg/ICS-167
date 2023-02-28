using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond_Unit : UnitInstance
{
    //In here we can possibly put animation starts
    private Vector3 posa;
    // Start is called before the first frame update
    public bool cursorOnObj = false;
    // Start is called before the first frame update
    void Start()
    {
        posa = transform.position;
       // move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(cursortest.transform.position.x==posa.x && cursortest.transform.position.y==posa.y && cursortest.canMove==false){
            cursorOnObj=true;
        }
        if(cursortest.transform.position.x!=posa.x || cursortest.transform.position.y!=posa.y){
            cursorOnObj=false;
        }
        if(cursorOnObj){
            updateUnitPosition();
        }
    }
}