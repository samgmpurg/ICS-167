using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : Tile
{
    //Sand tile class. Requires 2 MOV points.
    //Orcs only have 1 MOV point. Therefore Orcs cannot pass through this tile.
    public Sand(int xPos1, int yPos1, int xPos2, int yPos2) : base(xPos1, yPos1, xPos2, yPos2)
    {
        this.xLeftPos = xPos1;
        this.yBotPos = yPos1;
        this.xRightPos = xPos2;
        this.yTopPos = yPos2;
        occupied = false;
        property = "Sand";

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
