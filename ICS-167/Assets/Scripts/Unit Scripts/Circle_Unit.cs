using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Unit : UnitInstance
{
    //In here we can possibly put animation starts
    public Vector3 posa;
    // Start is called before the first frame update
    public bool cursorOnObj = false;
    // Start is called before the first frame update
    void Start()
    {
        possiblemovement = SOunit.defaultspeed;
        posa = transform.position;
        sprite = SOunit.UnitSprite.GetComponent<SpriteRenderer>();
       // move = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(unmoveable==false){
            unitmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Applied position variable used to store the coordinates. Round down to nearest whole number.
            unitappliedPosition = new Vector3((int)Math.Floor(unitmousePos.x), (int)Math.Floor(unitmousePos.y));
            if (Input.GetMouseButtonDown(0)){
                if(unitappliedPosition.x==posa.x && unitappliedPosition.y==posa.y){
                    cursorOnObj=true;
                }
            }
            if (Input.GetMouseButtonDown(1)){
                cursorOnObj=false;
            }
            if(cursorOnObj){
                updateUnitPosition();
            }
            posa=transform.position;
        }   
    }
}
