using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : ScriptableObject

{
    public int xLeftPos, yBotPos, xRightPos, yTopPos;
    protected bool occupied { get; set; }
    protected string property { get; set; }
    public GameObject gameObj;

    public Tile (int xPos1, int yPos1, int xPos2, int yPos2)
    {
        this.xLeftPos = xPos1;
        this.yBotPos = yPos1;
        this.xRightPos = xPos2;
        this.yTopPos = yPos2;
        occupied = false;
    }
    public void Init(int xPos1, int yPos1, int xPos2, int yPos2)
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
        gameObj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Tile CreateTile(int xPos1, int yPos1, int xPos2, int yPos2)
    {
        Tile temp = CreateInstance<Tile>();
        temp.Init(xPos1, yPos1, xPos2, yPos2);
        return temp;
    }
}
