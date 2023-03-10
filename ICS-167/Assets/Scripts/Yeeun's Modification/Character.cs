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
    private bool isMoving;  //if our player is moving or not
    public Vector3 originalPos;
    private Vector3 targetPos;
    private float timeToMove = 0.7f;
    public bool Cursorclicked = false;
    public int possiblemovement = 2;
    public int timesmoved = 0;
    public Vector3 unitmousePos;
    public Vector3 unitappliedPosition;
    public bool unmoveable;
    public SpriteRenderer sprite;

    private void Start()
    {

    }

    [Obsolete]
    private void Update()
    {
        if (HP == 0)
        {
            DestroyObject(gameObject);

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


    public void updateUnitPosition()  //updates the position of the characters based on the keys the playr is pressing
    {
        originalPos = transform.position;
        if(timesmoved==possiblemovement){
            unmoveable=true;
            graycharacter();
}
        if(Input.GetKey(KeyCode.W) && !isMoving && originalPos.y!=13)
        {
            timesmoved+=1;
            StartCoroutine(MovePlayer(Vector3.up));    
        }
        if (Input.GetKey(KeyCode.A) && !isMoving && originalPos.x!=0)
        {
            timesmoved+=1;
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving && originalPos.y!=0)
        {
            timesmoved+=1;
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving && originalPos.x!=13)
        {
            timesmoved+=1;
            StartCoroutine(MovePlayer(Vector3.right));
        }

    }

    private void graycharacter()
    {

    }
    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        //keeping track of the elapsed time
        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction;

        //makes sure we lerp from the original position to the target pos, in the exact time we move
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
        unmoveable = true;

        if(GameStateManager.whoseTurn == 1)
            GameStateManager.pl1MoveCount++;
        if (GameStateManager.whoseTurn == 2)
            GameStateManager.pl2MoveCount++;

    }


    public virtual int howMuchDamage()
    {
        return -1;

    }
    public virtual void attackEnemy(Character enemy)
    {
        enemy.HP -= howMuchDamage();
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

    

/*
    [Serializable]
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

    public void setAttributes(int myHP, int myATK, string displayAtk, int myMOV, bool myInitiate, Vector3 currentLoc)
    {
        this.MAXHP = myHP;
        this.HP = myHP;
        this.ATK = myATK;
        this.displayAtk = displayAtk;
        this.MOV = myMOV;
        this.initiate = myInitiate;
        this.currentLoc = currentLoc;
    }
    
    public virtual int howMuchDamage()
    {
        return -1;

    }
    public virtual void attackEnemy(UnitInstance player)
    {
        player.HP -= howMuchDamage();
    }

    public virtual void move(Vector3 loc)
    {
        currentLoc = loc;
        GameStateManger.moveCounter++;
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
        for( int i = 0; i < list.Length/2; i++)
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
        
        for( int i = 0; i < list.Length/2; i++)
        {
            if (Mathf.Abs((this.currentLoc.x + this.currentLoc.y) - (list[i].currentLoc.x + list[i].currentLoc.y)) <= this.MOV + this.ATKRange)
            {
                temp = list[i];
                break;
            }
        }
        return temp;
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
            GameStateManger.deathCounter2++;
        }

        if(isActive)
        {
            DoAIWork();
        }
    }

}*/
