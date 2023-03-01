using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManger : MonoBehaviour
{
    public GameObject object1; //this is just a temp spawn in as I need to go to Office hours for assistance
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private Slider playerHealth = null;
    [SerializeField] private Slider enemyHealth = null;
    [SerializeField] private Button attackBtn = null;
    [SerializeField] private Button healBtn = null;

    private int playerHP, enemyHP = 100;

    private bool isPlayersTurn = true;


    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot5;
    private Vector3 spot6;


    private static GameStateManger _instance;
    // Start is called before the first frame update
    void Start()
    {
        spot1 = new Vector3(0.0f, 0.0f, 1.0f); //Each x and y value corosponses to a grid spot on the map
        spot2 = new Vector3(1.0f, 1.0f, 1.0f); //Can be potentially spawned out of the map if we're not careful
        spot3 = new Vector3(5.0f, 1.0f, 1.0f);
        spot4 = new Vector3(5.0f, 2.0f, 1.0f);
        spot5 = new Vector3(7.0f, 6.0f, 1.0f);
        spot6 = new Vector3(6.0f, 10.0f, 1.0f);
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
            Destroy(object6);
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
        DontDestroyOnLoad(object6);
        Instantiate(object6, spot6, Quaternion.identity);
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
        random = Random.Range(1, 3);
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


}