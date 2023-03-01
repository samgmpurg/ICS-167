using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour

{
    public int xLeftPos, yBotPos, xRightPos, yTopPos;
    protected bool occupied { get; set; }
    protected string property { get; set; }

    public Tile(int xPos1, int yPos1, int xPos2, int yPos2)
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
