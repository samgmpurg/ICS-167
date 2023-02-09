using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitInstance : MonoBehaviour
{

    //public float moveSpeed = 1.0f;
    //private Cursor TestCursor;
    //int cursorX = 0;
    //int cursorY = 0;
    //int cursorZ = 0;
    //public Vector3 move;
    private bool isMoving;  //if our player is moving or not
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.7f;

    //void Update()
    //{

    //}
    public void updateUnitPosition()  //updates the position of the characters based on the keys the playr is pressing
    {
        //if (isMoveable)
        //{
        //    if (Input.GetKey("a"))
        //    {
        //        if (move.x > 0)
        //        {
        //            move.x = move.x - (moveSpeed);
        //            isMoveable = false;
        //        }
        //    }
        //    if (Input.GetKey("d"))
        //    {
        //        if (move.x < 13)
        //        {
        //            move.x = move.x - (moveSpeed);
        //            isMoveable = false;
        //        }
        //    }
        //    if (Input.GetKey("w"))
        //    {
        //        if (move.y < 13)
        //        {
        //            move.y = move.y + (moveSpeed);
        //            isMoveable = false;
        //        }
        //    }
        //    if (Input.GetKey("s"))
        //    {
        //        if (move.y > 0)
        //        {
        //            move.y = move.y - (moveSpeed);
        //            isMoveable = false;
        //        }
        //    }

        //transform.position = move;

        if(Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));    
        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        //keeping track of the elapsed time
        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction;

        //makes sure we lerp from the original position to the target pos, in the exact time we move
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove)); 
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
    
