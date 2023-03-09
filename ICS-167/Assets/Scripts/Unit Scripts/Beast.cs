using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : Character
{
    public Beast() : base(10, 4, "4",3, false)
    {

    }

    /*public static Beast Create(Vector3 currentLoc)
    {
        Beast temp = Character.gameObj.AddComponent<Beast>();
        return temp;
    }*/

    public override int howMuchDamage()
    {
        return 4;
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
