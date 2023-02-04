using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;  //references to our units
    public GameObject enemyPrefab;

    public Transform playerTransform; //Location in the battle station where we want our units to spawn
    public Transform enemyTransform;

    UnitStats playerUnit;
    UnitStats enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        //to spawn the units on top of said locations of the map
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation); //this would spawn the units in their corresponded areas 
        //it also gets a reference to what we are spawning
        playerUnit = playerGo.GetComponent<UnitStats>(); //refrencing the Unit whenever we info that is store there
        
        //allows us to get information about our units
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<UnitStats>();

        playerHUD.SetHUD(playerUnit); //so that the stats of the charactes can be shown
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); //gives a little 2 sec break before it asks for the players actions

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()  //tell the player that he can choose an action
    {
        dialogueText.text = "Choose an Action: ";
    }

    IEnumerator PlayerAttack()
    {
        //damages the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.Hp);


        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            //end battle
            state = BattleState.WON;  //for when we kill all units
            EndBattle();
        }
        else
        {
            //enemies turn
            state = BattleState.ENERMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()  //can put any logic u want for the enemy
    {
        dialogueText.text = enemyUnit.unitName + "Attacks"; //shows in the dialogue that the enemy is attacking

        yield return new WaitForSeconds(1f);  //waits a second before damaging the player

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage); //check if player has died

        playerHUD.SetHP(playerUnit.Hp);

        yield return new WaitForSeconds(1f);

        if (isDead)  //determinates if player is dead
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You Won!!";
        }
        else if( state == BattleState.LOST)
        {
            dialogueText.text = "You lost!";
        }
    }

    /**IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.Hp);

        dialogueText.text = "You have been Healed!";

        yield return new WaitForSeconds(2f); //wait two seconds and then change to enemy's turn

        state = BattleState.ENERMYTURN;
        StartCoroutine(EnemyTurn());
    } **/
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());  //so that we can pause during our attack
    }

   /**  public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());  //so that we can pause during our attack
    } **/
}

