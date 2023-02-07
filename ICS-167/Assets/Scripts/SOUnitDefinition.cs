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
    private string UnitName;
    [SerializeField]
    private Sprite UnitIcon;
    [SerializeField] //All of these are general information of Units as of - First playtest
    private UnitInstance prefab;
    [SerializeField]
    private UnitTypes type;
    
    
}
