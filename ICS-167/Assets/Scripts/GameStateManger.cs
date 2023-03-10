using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;


/*public enum State  //work in progress with the states
{
    Start, PlayerTurn, EnemyTurn, Won, Lost
}*/

public class GameStateManger : MonoBehaviour
{
    private Player pl1Team;
    private Player pl2Team;
    public static Character[] characterList;
    public GameObject[] units;
    private Vector3[] unit_loc;
    
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
    
    public int playerHP = 100;
    public int enemyHP = 100;

    //private bool isPlayersTurn = true;

    //private EnemyHpManager enemyHP;

    private Vector2 cursorPos; //spot for cursor
    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot5;
    private Vector3 spot6; //spot for enemy1
    private Vector3 spot7; //spot for enemy2
    private Vector3 spot8; //spot for enemy3
    private Vector3 spot9; //spot for enemy4
    private Vector3 spot10; //spot for enemy5
    

    private static GameStateManger _instance;
    // Start is called before the first frame update

    //private State state;

    //public State state;
   
    void Start()
    {

        InitalizeStage();
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
        */

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
            */

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
        }*/

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

    /*private void Update()
    {
        if(state == State.WaitingForPlayer)
        {
              
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = State.Busy;
                //knows the player is attacking
               
                //after the player is done with their turn return to wait
                 
            }
        }
}

/*public void Attack()
{

}

public void Damage()
{

} */

public bool isDead()
    {
        if(playerHP == 0)
        {
            Destroy(this.gameObject);
        }

        if(enemyHP == 0)
        {
            Destroy(this.gameObject);
        }

        return false;
    }

    public bool BattleOver()
    {
        if (isDead())
        {
            //player is dead, enemy wins
            return true;
        }

        if (isDead())
        {
            //enemy is dead, player wins
            return true;
        }

        return false;   
    }


   


}