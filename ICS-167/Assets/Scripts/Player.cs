using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerIndex{get; private set; }

    // public int teamnum; //players team 
    // public int x; //positions
    // public int y; //positions

    // public Queue<int> movementQueue;
    // public Queue<int> combatQueue;

    //public float movementSpeed = 5f;

    ////unit stats
    //public string unitName;
    //public int moveSpeed = 2;
    //public int attackRange = 1;
    //public int attackDamage = 1;
    //public int healthPoints = 10;

    //public MapProperty mapProperty;

    ////location for pos update
    //public Transform startpoint;
    //public Transform endpoint;
    //public float moveSpeedT; //movement speed

    ////total distance 
    //private float movingLength;
    ////a boolean that for the units movement
    //public bool unitInMovement;

    //////Enum for unit states
    //public enum movementStates
    //{
    //    Unselected,
    //    Selected,
    //    Moved,
    //    Wait
    //}

    //public movementStates unitMoveState;

    //public List<Node> path = null;

    ////Path for moving unit's transform
    //public List<Node> pathForMovement = null;
    //public bool completedMovement = false;

    //private void Awake()
    //{
    //    movementQueue = new Queue<int>();
    //    //combatQueue = new Queue<int>();

    //    x = (int)transform.position.x;
    //    y = (int)transform.position.y;

    //    unitMoveState = movementStates.Unselected;
    //}

    //public void MoveNextTile()
    //{
    //    if(path.Count == 0)
    //    {
    //        return;
    //    }
 
    //}

    //public void moveAgain()
    //{
    //    path = null;
    //    setMovementState(0);
    //    completedMovement = false;
    //
    public void Initalize(int index){
        PlayerIndex = index;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
