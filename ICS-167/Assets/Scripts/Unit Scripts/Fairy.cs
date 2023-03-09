using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : Character
{
    public Fairy() : base(6, 2, "2-3", 5, false)
    {

    }

    /*public static Fairy Create(Vector3 currentLoc)
    {
        Fairy temp = Character.gameObj.AddComponent<Fairy>();
        return temp;
    }*/


    public override int howMuchDamage()
    {
        return Random.Range(2, 4);
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
