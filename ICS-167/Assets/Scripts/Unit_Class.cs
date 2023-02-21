using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitInstance : MonoBehaviour
{
    public float moveSpeed = 1f;
    //private Cursor TestCursor;
    //int cursorX = 0;
    //int cursorY = 0;
    //int cursorZ = 0;
    public Vector3 move;
    public bool isMoveable = true;
    void Update()
    {
    }
    public void updateUnitPosition()
    {
        if(isMoveable){
            if(Input.GetKey("a")){
                if(move.x>0){
                    move.x=move.x-(moveSpeed);
                    isMoveable=false;
                }
            }
            if(Input.GetKey("d")){
                if(move.x<13){
                    move.x=move.x+(moveSpeed);
                    isMoveable=false;
                }
            }
            if(Input.GetKey("w")){
                if(move.y<13){
                    move.y=move.y+(moveSpeed);
                    isMoveable=false;
                }
            }
            if(Input.GetKey("s")){
                if(move.y>0){
                    move.y=move.y-(moveSpeed);
                    isMoveable=false;
                }
            }
            transform.position = move;
        }
    }
}