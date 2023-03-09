using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Character
{
    public Elf() : base(7, 2, "2-4", 4, false)
    {

    }

    /*public static Elf Create(Vector3 currentLoc)
    {
        Elf temp = Character.gameObj.AddComponent<Elf>();
        return temp;
    }*/

    public override int howMuchDamage()
    {
        return Random.Range(2, 5);
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
