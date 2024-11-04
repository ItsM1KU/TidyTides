using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public enum BattleStates { START, PLAYERTURN, ENEMYTURN, WIN, LOSE}
public class Battlesystem : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerBattleStation;
    [SerializeField] Transform enemyBattleStation;

    [SerializeField] private Button attackButton;
    [SerializeField] private Button healButton;

    [SerializeField] TMP_Text dialogText;

    private unit playerUnit;
    private unit enemyUnit;
    

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleStates state;
    // Start is called before the first frame update
    void Start()
    {

        state = BattleStates.START;

        StartCoroutine(setupBattle());
    }

    IEnumerator setupBattle()
    {
        GameObject playerGO =  Instantiate(playerPrefab, playerBattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);

        playerUnit = playerGO.GetComponent<unit>();
        enemyUnit = enemyGO.GetComponent<unit>();

        playerHUD.setupHUD(playerUnit);
        enemyHUD.setupHUD(enemyUnit);

        dialogText.text = "A wild " + enemyUnit.unitName + " approaches...";

        yield return new WaitForSeconds(5);

        state = BattleStates.ENEMYTURN;
        StartCoroutine(enemyTurn());
    }

    IEnumerator playerAttack()
    {
        bool isDead = enemyUnit.takeDamage(playerUnit.damage);
        enemyHUD.setHP(enemyUnit.CurrentHP);

        dialogText.text = playerUnit.unitName + " decides to throw some hands!!";
        yield return new WaitForSeconds(5);

        if(isDead)
        {
            state = BattleStates.WIN;
            EndBattle();
        }
        else
        {
            state = BattleStates.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }

    IEnumerator playerHeal()
    {
        playerUnit.heal(5);
        playerHUD.setHP(playerUnit.CurrentHP);

        dialogText.text = playerUnit.unitName + " backs out and decides to heal..";
        yield return new WaitForSeconds(5);

        state = BattleStates.ENEMYTURN;
        StartCoroutine(enemyTurn());
    }

    IEnumerator enemyTurn()
    {
        bool playerDead = false;
        if (enemyUnit.CurrentHP < 20)
        {
            int choice = Random.Range(0, 100);

            if(choice < 60)
            {
                enemyUnit.heal(10);
                enemyHUD.setHP(enemyUnit.CurrentHP);
                dialogText.text = enemyUnit.unitName + " chooses to heal themselves..";
            }
            else
            {
                playerDead = playerUnit.takeDamage(enemyUnit.damage);
                playerHUD.setHP(playerUnit.CurrentHP);
                dialogText.text = enemyUnit.unitName + " decides to attack...";
            }
        }
        else
        {
            playerDead = playerUnit.takeDamage(enemyUnit.damage);
            playerHUD.setHP(playerUnit.CurrentHP);
            dialogText.text = enemyUnit.unitName + " decides to attack...";
        }
        yield return new WaitForSeconds(5);

        if (playerDead)
        {
            state = BattleStates.LOSE;
            EndBattle();
        }
        else
        {
            state = BattleStates.PLAYERTURN;
            playerTurn();
        }

    }


    void playerTurn()
    {
        dialogText.text = "Choose an Action...";

        attackButton.interactable = true;
        healButton.interactable = true;
    }

    public void Attack()
    {
        if(state != BattleStates.PLAYERTURN)
        {
            return;
        }

        attackButton.interactable = false;
        healButton.interactable = false;    

        StartCoroutine(playerAttack());
    }

    public void Heal()
    {
        if(state != BattleStates.PLAYERTURN)
        {
            return;
        }

        attackButton.interactable = false;
        healButton.interactable = false;

        StartCoroutine(playerHeal());
    }

    void EndBattle()
    {
        if(state == BattleStates.WIN)
        {
            dialogText.text = "You win this battle to live another day!!";
            StartCoroutine(SceneChange());
        }

        if(state == BattleStates.LOSE)
        {
            dialogText.text = "You lose...";
            StartCoroutine(loseScene());
        }
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(5);

        SceneChanger();
    }

    IEnumerator loseScene()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("LandScene");
    }

    void SceneChanger()
    {
        EventSystem battleEventSystem = GameObject.FindObjectOfType<EventSystem>();
        if (battleEventSystem != null)
        {
            battleEventSystem.gameObject.SetActive(false); // Disable instead of destroying
        }

        AudioListener audioListener = FindObjectOfType<AudioListener>();
        if (audioListener != null)
        {
            audioListener.enabled = false; // Disable the listener
        }

        Scene oceanScene = SceneManager.GetSceneByName("OceanScene");
        if (oceanScene.IsValid())
        {
            SceneManager.SetActiveScene(oceanScene);

            foreach (GameObject obj in oceanScene.GetRootGameObjects())
            {
                obj.SetActive(true);
            }
            
            Timer timer = FindAnyObjectByType<Timer>();

            if(timer != null)
            {
                timer.AddTime(30f);
            }

            SceneManager.UnloadSceneAsync("BattleScene");
        }
    }

}
