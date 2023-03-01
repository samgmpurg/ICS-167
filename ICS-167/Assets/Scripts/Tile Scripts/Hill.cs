using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hill : Tile
{
    //Hill tile class. Buff tile; give +1 more damage to enemy units. 
    public Hill(int xPos1, int yPos1, int xPos2, int yPos2) : base(xPos1, yPos1, xPos2, yPos2)
    {
        this.xLeftPos = xPos1;
        this.yBotPos = yPos1;
        this.xRightPos = xPos2;
        this.yTopPos = yPos2;
        occupied = false;
        property = "Hill";


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
