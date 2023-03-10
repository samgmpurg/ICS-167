using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameStateManager: MonoBehaviour
{
    public Player pl1, pl2;
    public static int pl1MoveCount, pl2MoveCount, pl1DeathCount, pl2DeathCount;
    public static Character[] characterList;
    public static int whoseTurn;
    public Vector3[] unit_loc;
    public GameObject[] units;

    public GameObject pl1ob1; 
    public GameObject pl1ob2;
    public GameObject pl1ob3;
    public GameObject pl1ob4;
    public GameObject pl1ob5;
    public GameObject pl2ob1;
    public GameObject pl2ob2;
    public GameObject pl2ob3;
    public GameObject pl2ob4;
    public GameObject pl2ob5;

    private static GameStateManager _instance;

    void Start()
    {
        whoseTurn = 1;
        pl1MoveCount = 0;
        pl2MoveCount = 0;
        pl1DeathCount = 0;
        pl2DeathCount = 0;
        initializeStage();
    }
    void Update()
    {
        changeTurn();
        checkWin();
    }

    private void initializeStage()
    {
        units = new GameObject[10];
        unit_loc = new Vector3[10];

        for (int i = 0; i < unit_loc.Length; i++)
        {
            if (i < 5)
                unit_loc[i] = new Vector3((8 + i), 5.0f, 1.0f);
            else
                unit_loc[i] = new Vector3((14 - i), 18.0f, 1.0f);
            //Console.WriteLine($"({unit_loc[i].x}, {unit_loc[i].y})"); //Checking if vector is assigned properly
        }
        if (Menu.isSingle)
        {
            pl1 = Player.Create(true, false, unit_loc[0], unit_loc[1], unit_loc[2], unit_loc[3], unit_loc[4]);
            pl2 = Player.Create(false, true, unit_loc[5], unit_loc[6], unit_loc[7], unit_loc[8], unit_loc[9]);
        }
        else
        {
            pl1 = Player.Create(true, false, unit_loc[0], unit_loc[1], unit_loc[2], unit_loc[3], unit_loc[4]);
            pl2 = Player.Create(false, false, unit_loc[5], unit_loc[6], unit_loc[7], unit_loc[8], unit_loc[9]);
        }

        

        characterList = new Character[10];
        characterList[0] = gameObject.GetComponent<Character>();
        characterList[1] = gameObject.GetComponent<Character>();
        characterList[2] = gameObject.GetComponent<Character>();
        characterList[3] = gameObject.GetComponent<Character>();
        characterList[4] = gameObject.GetComponent<Character>();
        characterList[5] = gameObject.GetComponent<Character>();
        characterList[6] = gameObject.GetComponent<Character>();
        characterList[7] = gameObject.GetComponent<Character>();
        characterList[8] = gameObject.GetComponent<Character>();
        characterList[9] = gameObject.GetComponent<Character>();

        characterList[0] = pl1.team[0];
        characterList[1] = pl1.team[1];
        characterList[2] = pl1.team[2];
        characterList[3] = pl1.team[3];
        characterList[4] = pl1.team[4];
        characterList[5] = pl2.team[0];
        characterList[6] = pl2.team[1];
        characterList[7] = pl2.team[2];
        characterList[8] = pl2.team[3];
        characterList[9] = pl2.team[4];

        Instantiate(pl1, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(pl2, new Vector3(0, 0, 0), Quaternion.identity);
        DontDestroyOnLoad(pl1ob1);
        Instantiate(pl1ob1, pl1.team[0].currentLoc, Quaternion.identity); //Spawns everything in
        DontDestroyOnLoad(pl1ob2);
        Instantiate(pl1ob2, pl1.team[1].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl1ob3);
        Instantiate(pl1ob3, pl1.team[2].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl1ob4);
        Instantiate(pl1ob4, pl1.team[3].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl1ob5);
        Instantiate(pl1ob5, pl1.team[4].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl2ob1);
        Instantiate(pl2ob1, pl2.team[0].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl2ob2);
        Instantiate(pl2ob2, pl2.team[1].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl2ob3);
        Instantiate(pl2ob3, pl2.team[2].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl2ob4);
        Instantiate(pl2ob4, pl2.team[3].currentLoc, Quaternion.identity);
        DontDestroyOnLoad(pl2ob5);
        Instantiate(pl2ob5, pl2.team[4].currentLoc, Quaternion.identity);

        if (_instance == null)
        {
            _instance = this; //standard GameStateManger stuff
        }
        else
        {
            for (int i = 0; i < units.Length; i++)
            {
                Destroy(units[i]);
            }
            
            Destroy(pl1ob1);
            Destroy(pl1ob2); //destroys after the game in unloaded
            Destroy(pl1ob3);
            Destroy(pl1ob4);
            Destroy(pl1ob5);
            Destroy(pl2ob1);
            Destroy(pl2ob2);
            Destroy(pl2ob3);
            Destroy(pl2ob4);
            Destroy(pl2ob5);
        }//This is a very bad way to initialize stuff and WILL be changed in the fututre
    }


    private void changeTurn()
    {
        if (pl1MoveCount == 5)
        {
            whoseTurn = 2;
            pl1MoveCount = 0;
        }
        if(pl2MoveCount == 5)
        {
            whoseTurn = 1;
            pl2MoveCount = 0;
        }
    }

    private void checkWin()
    {
        if(pl1DeathCount == 5)
        {
            Console.WriteLine("Player2 win!");
        }
        if(pl2DeathCount == 5)
        {
            Console.WriteLine("Player1 win!");
        }
    }
    
}




/*public class GameStateManger : MonoBehaviour
{
    private Player pl1Team;
    private Player pl2Team;
    GameObject[] playerUnits;
    GameObject[] enemyUnits;
    public static int moveCounter;
    public static int deathCounter1, deathCounter2;
    //public GameObject[] units;
    private Vector3[] unit_loc;

    public static UnitInstance[] playerUnitList;
    public static Character[] characterList;


    public GameObject object1; //this is just a temp spawn in as I need to go to Office hours for assistance
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject enemy1; //enemy1
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private Slider playerHealth = null;
    [SerializeField] private Slider enemyHealth = null;
    [SerializeField] private Button attackBtn = null;
    [SerializeField] private Button healBtn = null;
    
    public GameObject cursor; //cursor
    
    private int playerHP, enemyHP = 100;

    private bool isPlayersTurn = true;


    private Vector2 cursorPos; //spot for cursor
    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot5;
    public static Vector3 spot6; //spot for enemy1
    public static Vector3 spot7; //spot for enemy2
    public static Vector3 spot8; //spot for enemy3
    public static Vector3 spot9; //spot for enemy4
    public static Vector3 spot10; //spot for enemy5
    

    private static GameStateManger _instance;
    // Start is called before the first frame update
    void Start()
    {
        InitalizeStage();
        //AddComponents();
    }

    void Update()
    {
        checkTurnChange();
        checkWin();
    }

    private void checkTurnChange()
    {
        if(moveCounter == 5)
        {
            enemy1.GetComponent<Character>().isActive = true;
            enemy2.GetComponent<Character>().isActive = true;
            enemy3.GetComponent<Character>().isActive = true;
            enemy4.GetComponent<Character>().isActive = true;
            enemy5.GetComponent<Character>().isActive = true;
        }
        if(moveCounter == 10)
        {
            object1.GetComponent<UnitInstance>().unmoveable = false;
            object2.GetComponent<UnitInstance>().unmoveable = false;
            object3.GetComponent<UnitInstance>().unmoveable = false;
            object4.GetComponent<UnitInstance>().unmoveable = false;
            object5.GetComponent<UnitInstance>().unmoveable = false;
            moveCounter = 0;
        }
        
    }
    private void checkWin()
    {
        if (object1.GetComponent<Circle_Unit>().unmoveable)
        {
            if (object2.GetComponent<Arrow_Unit>().unmoveable)
            {
                if (object3.GetComponent<Double_Circle_Unit>().unmoveable)
                {
                    if (object4.GetComponent<Diamond_Unit>().unmoveable)
                    {
                        if (object5.GetComponent<Square_Unit>().unmoveable)
                        {
                            enemy1.GetComponent<Human>().isActive = true;
                            enemy2.GetComponent<Elf>().isActive = true;
                            enemy3.GetComponent<Ogre>().isActive = true;
                            enemy4.GetComponent<Beast>().isActive = true;
                            enemy5.GetComponent<Fairy>().isActive = true;
                        }
                    }
                    else
                        return;
                }
                else
                    return;
            }
            else
                return;

        }
        else
            return;
    }

    private void InitalizeStage()
    {
        /*units = new GameObject[10];
        unit_loc = new Vector3[10];

        for (int i = 0; i < unit_loc.Length; i++)
        {
            if (i < 5)
                unit_loc[i] = new Vector3((8 + i), 5.0f, 1.0f);
            else
                unit_loc[i] = new Vector3((14 - i), 18.0f, 1.0f);
            //Console.WriteLine($"({unit_loc[i].x}, {unit_loc[i].y})"); //Checking if vector is assigned properly
        }
        if (Menu.isSingle)
        {
            pl1Team = Player.Create(true, false, unit_loc[0], unit_loc[1], unit_loc[2], unit_loc[3], unit_loc[4]);
            pl2Team = Player.Create(false, true, unit_loc[5], unit_loc[6], unit_loc[7], unit_loc[8], unit_loc[9]);
        }
        else
        {
            pl1Team = Player.Create(true, false, unit_loc[0], unit_loc[1], unit_loc[2], unit_loc[3], unit_loc[4]);
            pl2Team = Player.Create(false, false, unit_loc[5], unit_loc[6], unit_loc[7], unit_loc[8], unit_loc[9]);
        }
        
        moveCounter = 0;
        playerUnits = GameObject.FindGameObjectsWithTag("Player");
        enemyUnits = GameObject.FindGameObjectsWithTag("Enemy");

        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        spot1 = new Vector3(8.0f, 5.0f, 1.0f); //Each x and y value corosponses to a grid spot on the map
        spot2 = new Vector3(9.0f, 5.0f, 1.0f); //Can be potentially spawned out of the map if we're not careful
        spot3 = new Vector3(10.0f, 5.0f, 1.0f);
        spot4 = new Vector3(11.0f, 5.0f, 1.0f);
        spot5 = new Vector3(12.0f, 5.0f, 1.0f);
        spot6 = new Vector3(8.0f, 18.0f, 1.0f);
        spot7 = new Vector3(7.0f, 18.0f, 1.0f);
        spot8 = new Vector3(6.0f, 18.0f, 1.0f);
        spot9 = new Vector3(5.0f, 18.0f, 1.0f);
        spot10 = new Vector3(4.0f, 18.0f, 1.0f);
        

        if (_instance == null)
        {
            _instance = this; //standard GameStateManger stuff
        }
        else
        {
            /*for (int i = 0; i < units.Length; i++)
            {
                Destroy(units[i]);
            }
            

            Destroy(object1);
            Destroy(object2); //destroys after the game in unloaded
            Destroy(object3);
            Destroy(object4);
            Destroy(object5);
            Destroy(enemy1);
            Destroy(enemy2);
            Destroy(enemy3);
            Destroy(enemy4);
            Destroy(enemy5);
        }//This is a very bad way to initialize stuff and WILL be changed in the fututre


        /*for (int i = 0; i < 10; i++)
        {
            DontDestroyOnLoad(units[i]);
            Instantiate(units[i], unit_loc[i], Quaternion.identity);
        }

        DontDestroyOnLoad(object1);
        Instantiate(object1, spot1, Quaternion.identity); //Spawns everything in
        DontDestroyOnLoad(object2);
        Instantiate(object2, spot2, Quaternion.identity);
        DontDestroyOnLoad(object3);
        Instantiate(object3, spot3, Quaternion.identity);
        DontDestroyOnLoad(object4);
        Instantiate(object4, spot4, Quaternion.identity);
        DontDestroyOnLoad(object5);
        Instantiate(object5, spot5, Quaternion.identity);
        DontDestroyOnLoad(enemy1);
        Instantiate(enemy1, spot6, Quaternion.identity);
        DontDestroyOnLoad(enemy2);
        Instantiate(enemy2, spot7, Quaternion.identity);
        DontDestroyOnLoad(enemy3);
        Instantiate(enemy3, spot8, Quaternion.identity);
        DontDestroyOnLoad(enemy4);
        Instantiate(enemy4, spot9, Quaternion.identity);
        DontDestroyOnLoad(enemy5);
        Instantiate(enemy5, spot10, Quaternion.identity);

        

    }

    /*private void AddComponents()
    {
        playerUnitList[0] = gameObject.GetComponent<Circle_Unit>();
        //characterList[0].setAttributes(10, 1, "1-3", 3, false, spot1);
        playerUnitList[1] = gameObject.GetComponent<Arrow_Unit>();
        //characterList[1].setAttributes(7, 2, "2-4", 4, false, spot2);
        playerUnitList[2] = gameObject.GetComponent<Double_Circle_Unit>();
        //characterList[2].setAttributes(15, 5, "5-6", 1, true, spot3);
        playerUnitList[3] = gameObject.GetComponent<Diamond_Unit>();
        //characterList[3].setAttributes(10, 4, "4", 3, false, spot4);
        playerUnitList[4] = gameObject.GetComponent<Square_Unit>();
        //characterList[4].setAttributes(6, 2, "2-3", 5, false, spot5);
        characterList[5] = gameObject.GetComponent<Character>();
        characterList[5].setAttributes(10, 1, "1-3", 3, false, spot6);
        characterList[6] = gameObject.GetComponent<Character>();
        characterList[6].setAttributes(7, 2, "2-4", 4, false, spot7);
        characterList[7] = gameObject.GetComponent<Character>();
        characterList[7].setAttributes(15, 5, "5-6", 1, true, spot8);
        characterList[8] = gameObject.GetComponent<Character>();
        characterList[8].setAttributes(10, 4, "4", 3, false, spot9);
        characterList[9] = gameObject.GetComponent<Character>();
        characterList[9].setAttributes(6, 2, "2-3", 5, false, spot10);
    }

    //want to know who we want to attack and how much dmg they will take
    private void Attack(GameObject target, float damage)
    {
        if (target == enemy)
        {
            enemyHealth.value -= damage;  //enemies take dmg
        }
        else
        {
            playerHealth.value -= damage;  //allows us to take dmg
        }

        ChangeTurn(); //changes turn after attack
    }


    private void Heal(GameObject target, float amount)
    {
        if (target == enemy)
        {
            enemyHealth.value += amount;
        }
        else
        {
            playerHealth.value += amount; //now the player can heal
        }

        ChangeTurn(); //changes turn after heal
    }

    public void buttonAttack()
    {
        Attack(enemy, 10); //dmg to enemy
        
    }

    public void buttonHeal()
    {
        Heal(player, 5);  //healing
    }

    private void ChangeTurn()
    {
        isPlayersTurn = !isPlayersTurn;

        if (!isPlayersTurn)
        {
            attackBtn.interactable = false;
            healBtn.interactable = false;

            StartCoroutine(EnemyTurn());
        }
        else //players turn
        {
            attackBtn.interactable = true;
            healBtn.interactable = true;
        }
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(6);  //once is the enemy's turn the player waits three seconds

        int random = 0;
        random = UnityEngine.Random.Range(1, 3);
        if (random == 1)
        {
            Attack(player, 12); //player attacks for 12 dmg
        }
        else
        {
            Heal(enemy, 3);
        }
    }


    public void victory()
    {
        if (enemyHP <= 0)
        {
            Destroy(enemy);
        }
        else
        {
            if(enemyHP != 0)
            {
                ChangeTurn();
            }
        }
    }

    public void lose()
    {
        if(playerHP <= 0)
        {
            Destroy(player);
        }
        else
        {
            if(playerHP != 0)
            {
                ChangeTurn();
            }
        }
    }


}*/