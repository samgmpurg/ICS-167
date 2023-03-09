using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{
    public Human() : base(10, 1, "1-3", 3, false)
    {

    }

    /*public static Human Create(Vector3 currentLoc)
    {
        Human temp = gameObj.AddComponent<Human>();
        return temp;
    }*/

    public override int howMuchDamage()
    {
        return Random.Range(1,4);
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
