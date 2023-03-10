using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected int HP { get; set; }
    [SerializeField]
    protected int MAXHP { get; set; }
    [SerializeField]
    protected int ATK { get; set; }
    [SerializeField]
    protected int ATKRange { get; set; }
    [SerializeField]
    protected string displayAtk { get; set; }
    [SerializeField]
    protected int MOV { get; set; }
    [SerializeField]
    protected bool initiate { get; set; }
    [SerializeField]
    public Vector3 currentLoc { get; set; }
    [SerializeField]
    public bool isActive { get; set; }
    [SerializeField]
    public bool isAI { get; set; }

    private void Start()
    {

    }

    [Obsolete]
    void Update()
    {
        if (HP == 0)
        {
            Destroy(gameObject);
        }

        if (isActive)
        {
            DoAIWork();
        }
    }


    public Character(int myHP, int myATK, string displayAtk, int myMOV, bool myInitiate, Vector3 currentLoc, bool isActive, bool isAI)
    {
        this.MAXHP = myHP;
        this.HP = myHP;
        this.ATK = myATK;
        this.displayAtk = displayAtk;
        this.MOV = myMOV;
        this.initiate = myInitiate;
        this.currentLoc = currentLoc;
        this.isActive = isActive;
        this.isAI = isAI;
    }

    public Character SetAttributes(int myHP, int myATK, string displayAtk, int myMOV, bool myInitiate, Vector3 currentLoc, bool isActive, bool isAI)
    {
        Character temp = new Character(myHP, myATK, displayAtk, myMOV, myInitiate, currentLoc, isActive, isAI);
        return temp;
    }
    public virtual int howMuchDamage()
    {
        return -1;

    }
    public virtual void attackEnemy(Character enemy)
    {
        enemy.HP -= howMuchDamage();
    }

    public virtual void move(Vector3 loc)
    {
        currentLoc = loc;
    }

    public virtual void DoAIWork()
    {
        isActive = false;
    }

    protected bool isAttackable(Vector3 enemyLoc)
    {
        return Mathf.Abs((this.currentLoc.x + this.currentLoc.y) - (enemyLoc.x + enemyLoc.y)) == 1;

    }
    protected Vector3 findNearestEnemyPos(Character[] list)
    {
        Vector3 nearest = new Vector3(20, 20, 20);
        int difference, newDifference;
        for (int i = 0; i < list.Length / 2; i++)
        {
            difference = (int)Mathf.Abs((this.currentLoc.x + this.currentLoc.y) - (nearest.x + nearest.y));
            newDifference = (int)Mathf.Abs((this.currentLoc.x + this.currentLoc.y) - (list[i].currentLoc.x + list[i].currentLoc.y));
            if (newDifference <= difference)
                nearest = list[i].currentLoc;
        }
        return nearest;
    }
    protected Character checkEnemyInRange(Character[] list)
    {
        Character temp = null;

        for (int i = 0; i < list.Length / 2; i++)
        {
            if (Mathf.Abs((this.currentLoc.x + this.currentLoc.y) - (list[i].currentLoc.x + list[i].currentLoc.y)) <= this.MOV + this.ATKRange)
            {
                temp = list[i];
                break;
            }
        }
        return temp;
    }
    
}

