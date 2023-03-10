using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Beast : Character
{
    public Beast(Vector3 currentLoc, bool isActive, bool isAI) : base(10, 4, "4", 3, false, currentLoc, isActive, isAI)
    {

    }

    public static Beast Create(Vector3 currentLoc, bool isActive, bool isAI)
    {
        Beast temp = new Beast(currentLoc, isActive, isAI);
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