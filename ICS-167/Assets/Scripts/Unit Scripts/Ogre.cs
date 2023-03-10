using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Ogre : Character
{
    
    public Ogre(Vector3 currentLoc, bool isActive, bool isAI) : base(15, 5, "5-6", 1, false, currentLoc, isActive, isAI)
    {

    }

    public static Ogre Create(Vector3 currentLoc, bool isActive, bool isAI)
    {
        Ogre temp = new Ogre(currentLoc, isActive, isAI);
        return temp;
    }

    public override void DoAIWork()
    {
        if ((MAXHP - HP) >= MAXHP / 2) //if HP is over 50%
        {
            Vector3 nearestEnemyLoc = findNearestEnemyPos(GameStateManager.characterList);
            Character nearestEnemy = checkEnemyInRange(GameStateManager.characterList);
            if(nearestEnemy.currentLoc == nearestEnemyLoc)
            {
                if ( isAttackable(nearestEnemyLoc) )
                {
                    attackEnemy(nearestEnemy);
                }
            }
        }
        else
        {

        }
            base.DoAIWork();
    }
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
