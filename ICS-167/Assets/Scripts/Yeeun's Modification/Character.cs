using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected int HP { get; set; }
    [SerializeField]
    protected int ATK { get; set; }
    [SerializeField]
    protected string displayAtk { get; set; }
    [SerializeField]
    protected int MOV { get; set; }
    [SerializeField]
    protected bool initiate { get; set; }
    [SerializeField]
    private Vector3 currentLoc { get; set; }
    [SerializeField]
    private bool isActive { get; set; }

    public Character(int myHP, int myATK, string displayAtk, int myMOV, bool myInitiate)
    {
        this.HP = myHP;
        this.ATK = myATK;
        this.displayAtk = displayAtk;
        this.MOV = myMOV;
        this.initiate = myInitiate;
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

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(HP ==0)
        {
            Destroy(gameObject);
        }

        if(isActive)
        {
            DoAIWork();
        }
    }

}
