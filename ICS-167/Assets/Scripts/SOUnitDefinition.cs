using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ICS-167/UnitDefinition")]
public class SOUnitDefinition : ScriptableObject
{
    public enum UnitTypes{ //Test unit Types that will be changed later
        Circle,
        Diamond,
        Square,
        Arrow, 
        DoubleCircle
    }
    [SerializeField]
    private Sprite UnitIcon;
    [SerializeField]
    public SpriteRenderer UnitSprite;
    [SerializeField] //All of these are general information of Units as of - First playtest
    private UnitInstance prefab;
    [SerializeField]
    private UnitTypes type;
    [SerializeField]
    public float defaulthealth=5;
    [SerializeField]
    public int defaultspeed=2;
    [SerializeField]
    public float defaultdamage=1;
    [SerializeField]
    public float Cursorx=1;
    [SerializeField]
    public float Cursory=1;
    /*
    public UnitDefinition Spawn(Player owner, Vector2 position){ //Need to implement a Player script
        UnitDefinition instance = GameObject.Instantiate(prefab,position,Quaternion.identity);
        instance.Initalize(UnitName,type,owner);
        return instance;
    }
    */
}

