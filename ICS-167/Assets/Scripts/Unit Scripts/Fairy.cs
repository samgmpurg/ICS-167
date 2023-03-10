using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Fairy : Character
{

    public Fairy(Vector3 currentLoc, bool isActive, bool isAI) : base(6, 2, "2-3", 5, false, currentLoc, isActive, isAI)
    {

    }

    public static Fairy Create(Vector3 currentLoc, bool isActive, bool isAI)
    {
        Fairy temp = new Fairy(currentLoc, isActive, isAI);
        return temp;
    }

    public override void DoAIWork()
    {
        if ((MAXHP - HP) < MAXHP / 2)
        {
            Vector3 nearestEnemyLoc = findNearestEnemyPos(GameStateManger.characterList);
            Vector3 newLoc = new Vector3(nearestEnemyLoc.x + MOV / 2, nearestEnemyLoc.y + MOV / 2);
        }
        else
            base.DoAIWork();
    }

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