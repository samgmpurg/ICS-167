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
    public float smoothSpeed = 0.125f;
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

        updatePosition();

    }

    public void updatePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        appliedPosition = new Vector3((float)Math.Floor(mousePos.x), (float)Math.Floor(mousePos.y));
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
        if (canMove && Input.GetMouseButtonDown(0))
        {
            sr.sprite = selectedSprite;
            canMove = false;
        }
        if (!canMove && Input.GetMouseButtonDown(1))
        {
            sr.sprite = defaultSprite;
            canMove = true;
        }


    }
}

