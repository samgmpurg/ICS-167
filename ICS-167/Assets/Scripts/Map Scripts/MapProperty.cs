using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProperty : MonoBehaviour
{
    //Map art/sprite
    public static SpriteRenderer mapSprite { get; set; }
    
    //Invisible Tile 2d array to assign different types of tiles throughout the map
    public static Tile[] tileGrid { get; set; }

    private GameObject tileObject;

    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponent<SpriteRenderer>();
        int height = getMapUnitHeight();
        int width = getMapUnitWidth();

        //Make tileGrid variable to be a 2d array of Tiles with height row and width column.
        //tileGrid = new Tile[height, width];
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //Each tile is 40x40 pixels. Therefore the location of each tiles(pivot at bottom left corner) would increase by 40.
                //tileGrid[i, j] = new Tile(i * 40, j * 40, (i + 1) * 40, (j + 1) * 40);
                //tileGrid[i * 20 + j] = Tile.CreateTile(i * 40, j * 40, (i + 1) * 40, (j + 1) * 40);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public int getMapUnitWidth()
    {
        //Return unit width.
        //Ex: there are 14 units along the x axis - return 14.
        return (int)(mapSprite.sprite.rect.width) / 40;
    }

    public int getMapUnitHeight()
    {
        //Return unit height.
        //Ex: there are 30 units along the y axis - return 30.
        return (int)(mapSprite.sprite.rect.height) / 40;
    }
}


