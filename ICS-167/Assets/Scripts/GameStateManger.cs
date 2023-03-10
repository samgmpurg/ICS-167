using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public enum State
{
    Start, PlayerTurn, EnemyTurn, Won, Lost
}

public class GameStateManger : MonoBehaviour
{
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
    public GameObject object7; //cursor
    
    public int playerHP = 100;
    public int enemyHP = 100;

    //private bool isPlayersTurn = true;

    //private EnemyHpManager enemyHP;

    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot5;
    private Vector3 spot6; //spot for enemy1
    private Vector2 spot7; //spot for cursor

    private Vector3 spot8; //spot for enemy2
    private Vector3 spot9; //spot for enemy3
    private Vector3 spot10; //spot for enemy4
    private Vector3 spot11; //spot for enemy5


    private static GameStateManger _instance;
    // Start is called before the first frame update

    //private State state;

    public State state;
   
    void Start()
    {
        spot7 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spot1 = new Vector3(0.0f, 0.0f, 1.0f); //Each x and y value corosponses to a grid spot on the map
        spot2 = new Vector3(1.0f, 1.0f, 1.0f); //Can be potentially spawned out of the map if we're not careful
        spot3 = new Vector3(5.0f, 1.0f, 1.0f);
        spot4 = new Vector3(5.0f, 2.0f, 1.0f);
        spot5 = new Vector3(7.0f, 6.0f, 1.0f);
        spot6 = new Vector3(6.0f, 10.0f, 1.0f);
        spot8 = new Vector3(10.0f, 14.0f, 1.0f);
        spot9 = new Vector3(8.0f,12.0f, 1.0f);
        spot10 = new Vector3(4.0f, 12.0f, 1.0f);
        spot11 = new Vector3(3.0f, 11.0f, 1.0f);

       state = State.Start;

        if (_instance == null)
        {
            _instance = this; //standard GameStateManger stuff
        }
        else
        {
            Destroy(object1);
            Destroy(object2); //destroys after the game in unloaded
            Destroy(object3);
            Destroy(object4);
            Destroy(object5);
            Destroy(enemy1);
            Destroy(object7);
            Destroy(enemy2);
            Destroy(enemy3);
            Destroy(enemy4);
            Destroy(enemy5);
        }//This is a very bad way to initialize stuff and WILL be changed in the fututre
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
        DontDestroyOnLoad(object7);
        Instantiate(object7,spot7, Quaternion.identity);
        DontDestroyOnLoad(enemy2);
        Instantiate(enemy2, spot8, Quaternion.identity);
        DontDestroyOnLoad(enemy3);
        Instantiate(enemy3, spot9, Quaternion.identity);
        DontDestroyOnLoad(enemy4);
        Instantiate(enemy4, spot10, Quaternion.identity);
        DontDestroyOnLoad(enemy5);
        Instantiate(enemy5, spot11, Quaternion.identity);
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