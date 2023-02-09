using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyRoad : Tile
{
    //Rocky road tile class. Debuff tile; get +1 damage from enemy attacks.
    public RockyRoad(int xPos1, int yPos1, int xPos2, int yPos2) : base(xPos1, yPos1, xPos2, yPos2)
    {
        this.xLeftPos = xPos1;
        this.yBotPos = yPos1;
        this.xRightPos = xPos2;
        this.yTopPos = yPos2;
        occupied = false;

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
