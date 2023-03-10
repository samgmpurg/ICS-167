using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human : Character
{
    public Human(Vector3 currentLoc, bool isActive, bool isAI) : base(10, 1, "1-3", 3, false, currentLoc, isActive, isAI)
    {

    }

    public static Human Create(Vector3 currentLoc, bool isActive, bool isAI)
    {
        Human temp = new Human(currentLoc, isActive, isAI);
        return temp;
    }

    public override void DoAIWork()
    {
        if ((MAXHP - HP) < MAXHP / 2)
        {
            Vector3 nearestEnemyLoc = findNearestEnemyPos(GameStateManager.characterList);
            Vector3 newLoc = new Vector3(nearestEnemyLoc.x + MOV / 2, nearestEnemyLoc.y + MOV / 2);
        }
        else
            base.DoAIWork();
    }
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
