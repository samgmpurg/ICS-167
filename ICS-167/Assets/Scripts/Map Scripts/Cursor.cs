using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 appliedPosition;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    public float smoothSpeed = 0.01f;
    public Sprite defaultSprite;
    public Sprite selectedSprite;
    public SpriteRenderer sr;
    public bool canMove { get; set; }
    public Tile[,] tileGrid { get; set; }
    public Vector3 chPos { get; set; }
    public bool isOnCharacter { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        canMove = true;
        int height = 14;
        int width = 14;
        tileGrid = new Tile[height, width];

        //Make tileGrid variable to be a 2d array of Tiles with height row and width column.
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //Each tile is 40x40 pixels. Therefore the location of each tiles(pivot at bottom left corner) would increase by 40.
                tileGrid[i, j] = Tile.CreateTile(i * 40, j * 40, (i + 1) * 40, (j + 1) * 40);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        updatePosition();

    }

    public void updatePosition()
    {
        //Real mouse position in the screen world.
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Applied position variable used to store the coordinates. Round down to nearest whole number.
        appliedPosition = new Vector3((int)Math.Floor(mousePos.x), (int)Math.Floor(mousePos.y));

        //As long as the mouse is not clicked, the cursor will follow the current mouse position.
        if (canMove)
        {
            this.transform.position = Vector3.SmoothDamp(transform.position, appliedPosition, ref velocity, smoothSpeed);
        }
        manageMouseClick();
    }

    public void manageMouseClick()
    {
        //chPos = GetComponent<Character>().getCharacterPosition();
        //isOnCharacter = chPos.x == appliedPosition.x && chPos.y == appliedPosition.y;

        //Left mouse clicked; locks the cursor on the selected location.
        if (canMove && Input.GetMouseButtonDown(0))
        {
            sr.sprite = selectedSprite;
            canMove = false;
        }
        //Right mouse clicked; unlocks the cursor from the selected location.
        if (!canMove && Input.GetMouseButtonDown(1))
        {
            sr.sprite = defaultSprite;
            canMove = true;
        }


    }
    public float getX()
    {
        return transform.position.x;
    }
    public float getY()
    {
        return transform.position.x;
    }
}

