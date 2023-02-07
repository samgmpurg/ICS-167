using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProperty : MonoBehaviour
{
    public static SpriteRenderer mapSprite { get; set; }
    public static Tile[,] tileGrid { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponent<SpriteRenderer>();
        int height = getMapUnitHeight();
        int width = getMapUnitWidth();
        tileGrid = new Tile[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                tileGrid[i, j] = new Tile(i * 40, j * 40, (i + 1) * 40, (j + 1) * 40);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getMapUnitWidth()
    {
        return (int)(mapSprite.sprite.rect.width) / 40;
    }

    public int getMapUnitHeight()
    {
        return (int)(mapSprite.sprite.rect.height) / 40;
    }
}

public class Tile
{
    public int xLeftPos, yBotPos, xRightPos, yTopPos;
    //private Tile_Type tileType { get; set; }
    private bool occupied { get; set; }

    public Tile(int xPos1, int yPos1, int xPos2, int yPos2)
    {
        this.xLeftPos = xPos1;
        this.yBotPos = yPos1;
        this.xRightPos = xPos2;
        this.yTopPos = yPos2;
        //tileType = Tile_Type.Synthetic;
        occupied = false;

    }
}
