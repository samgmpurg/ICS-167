using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ogre : Character
{
    
    public Ogre() : base(15, 5, "5-6", 1, true)
    {

    }

    /*public static Ogre Create(Vector3 currentLoc)
    {
        Ogre temp = Character.gameObj.AddComponent<Ogre>();
        return temp;
    }*/

    public override int howMuchDamage()
    {
        return UnityEngine.Random.Range(5,7);
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
