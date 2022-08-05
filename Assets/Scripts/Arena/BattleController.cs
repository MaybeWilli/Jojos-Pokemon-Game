using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public GameObject playerStand;
    public GameObject enemyStand;
    private Stand stand1;
    private Stand stand2;
    public GameObject arena;
    public GameObject buttons;
    public Text actionText;
    public Text descripText;
    public Slider health1;
    public Slider health2;
    private string enemyName;
    private int selectedAttack;
    public Button useButton;
    public GameObject descriptions;
    public bool playerWon;
    public bool addToParty;
    private GameObject dialoguePanel;
    public GameObject actionButtons;
    public GameObject catchButtons;
    private PlayerController playerController;
    public int fitIndex;
    public int level2;
    private int enemyNum = 0;
    public Text levelText1;
    public Text levelText2;

    // Start is called before the first frame update
    void Start()
    {
        arena.SetActive(false);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle(GameObject s1, GameObject s2, int level1, int level2, string enemyName, GameObject dialoguePanel, string standName)
    {
        this.dialoguePanel = dialoguePanel;
        arena.SetActive(true);
        playerStand = Instantiate(s1, new Vector3(-5, 1, 0), Quaternion.identity);
        enemyStand = Instantiate(s2, new Vector3(6, 2.5f, 0), Quaternion.identity);
        
        this.enemyName = enemyName;
        this.level2 = level2;
        SetVariables(level1, level2, standName);
        actionText.gameObject.SetActive(false);
        addToParty = false;
    }

    public void SetVariables(int level1, int level2, string standName)
    {
        
        stand1 = playerStand.GetComponent<Stand>();
        stand1.standName = standName;
        stand2 = enemyStand.GetComponent<Stand>();

        stand1.isEnemy = false;
        stand2.isEnemy = true;
        stand2.trainerName = enemyName;
        stand1.trainerName = null;

        stand1.enemyStand = stand2;
        stand2.enemyStand = stand1;

        stand1.level = level1;
        stand2.level = level2;

        stand1.maxHealth = stand1.maxHealth+level1;
        stand2.maxHealth = stand2.maxHealth+level2;

        stand1.health = stand1.maxHealth;
        stand2.health = stand2.maxHealth;

        health1.value = stand1.health / stand1.maxHealth;
        health2.value = stand2.health / stand2.maxHealth;

        stand1.healthBar = health1;
        stand2.healthBar = health2;

        levelText1.text = "Lvl: "+level2.ToString();
        levelText2.text = "Lvl: "+level1.ToString();

        for (int i = 0; i < stand1.attackNames.Length; i++)
        {
            Debug.Log(buttons.transform.GetChild(1).name);
            if (stand1.levelRequirements[i] <= stand1.level)
            {
                buttons.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stand1.attackNames[i];
            }
            else
            {
                buttons.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Locked";
            }
        }//*/
        if (!(enemyName == "The wild"))
        {
            actionButtons.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "N/A";
        }
        else
        {
            actionButtons.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Catch";
        }
        selectedAttack = 0;
        descripText.text = stand1.attackExplainations[selectedAttack];
        descriptions.SetActive(false);
        buttons.SetActive(false);
        actionButtons.SetActive(true);
        catchButtons.SetActive(false);

    }

    public void ChooseAttack(Button button)
    {
        selectedAttack = button.gameObject.transform.GetSiblingIndex();
        if (stand1.level >= stand1.levelRequirements[selectedAttack])
        {
            descripText.text = stand1.attackExplainations[selectedAttack];
        }
        else
        {
            descripText.text = "You need to be level "+stand1.levelRequirements[selectedAttack].ToString()+" to use that!";
        }
        
        /*if (input == 0)
        {
            stand1.Move1();
            actionText.gameObject.SetActive(true);
            actionText.text = stand1.currentAttackName;
            buttons.SetActive(false);
        }
        else if (input == 1)
        {
            stand1.Move2();
            actionText.gameObject.SetActive(true);
            actionText.text = stand1.currentAttackName;
            buttons.SetActive(false);
        }
        else if (input == 2)
        {
            stand1.Move3();
        }
        else if (input == 3)
        {
            stand1.Move4();
        }*/
    }

    public void BackButton()
    {
        buttons.SetActive(false);
        descriptions.SetActive(false);
        actionButtons.SetActive(true);
        catchButtons.SetActive(false);
    }

    public void OpenAttack()
    {
        Debug.Log("Bruh why");
        actionButtons.SetActive(false);
        buttons.SetActive(true);
        descriptions.SetActive(true);
        descripText.text = stand1.attackExplainations[selectedAttack];
    }

    public void OpenCatch()
    {
        if (stand2.trainerName == "The wild" && (stand2.health / stand2.maxHealth <= 0.25f))
        {
            actionButtons.SetActive(false);
            catchButtons.SetActive(true);
        }
    }

    public void CatchButton()
    {
        int num = Random.Range(0, 3);
        if (num == 0) //successful
        {
            addToParty = true;
            stand1.index = 4;
            catchButtons.SetActive(false);
            actionText.gameObject.SetActive(true);
            bool canFit = false;
            for (int i = 0; i < playerController.stands.Length; i++)
            {
                if (playerController.stands[i] == null)
                {
                    fitIndex = i;
                    canFit = true;
                    break;
                }
            }
            if (canFit)
            {
                actionText.text = "The wild "+stand2.standName+" has been added to the party!";
                //playerController.stands[fitIndex] = new SavedStand(stand2.prefab, (int)stand2.level, stand2.standName);
            }
            else
            {
                actionText.text = "The wild "+stand2.standName+" didn't have room in the party, and parted amicably.";
                addToParty = false;
            }
            
        }
        else
        {
            stand1.landed = false;
            stand1.index = 1;
            catchButtons.SetActive(false);
            actionText.gameObject.SetActive(true);

            int num2 = Random.Range(0, 3);
            if (num2 == 0)
            {
                actionText.text = "It failed! Lmao noob ez!";
            }
            else if (num2 == 1)
            {
                actionText.text = "Hahaha, you missed!!";
            }
            else
            {
                actionText.text = "Imagine missing, haha!";
            }
        }
    }

    public void UseAttack()
    {
        if (stand1.level >= selectedAttack)
        {
            if (selectedAttack == 0)
            {
                stand1.Move1();
            }
            else if (selectedAttack == 1)
            {
                stand1.Move2();
            }
            else if (selectedAttack == 2)
            {
                stand1.Move3();
            }
            else if (selectedAttack == 3)
            {
                stand1.Move4();
            }
            actionText.gameObject.SetActive(true);
            actionText.text = stand1.currentAttackName;
            buttons.SetActive(false);
            descriptions.SetActive(false);
        }
        else
        {
            //do nothing
        }
    }

    public void ContinueButton()
    {
        stand1.index++;
        if (stand1.index == 1)
        {
            if (stand1.landed)
            {
                actionText.text = stand1.currentEffectName;
                if (selectedAttack == 0)
                {
                    stand1.Attack1();
                }
                else if (selectedAttack == 1)
                {
                    stand1.Attack2();
                }
                else if (selectedAttack == 2)
                {
                    stand1.Attack3();
                }
                else if (selectedAttack == 3)
                {
                    stand1.Attack4();
                }
            }
            else
            {
                int num = Random.Range(0, 3);
                if (num == 0)
                {
                    actionText.text = "It missed! You suck!";
                }
                else if (num == 1)
                {
                    actionText.text = "It failed! Lmao noob!";
                }
                else if (num == 2)
                {
                    actionText.text = "Bruh, ur aim trash, uninstall noob";
                }
            }
        }
        else if (stand1.index == 2)
        {
            if (stand2.health <= 0)
            {
                actionText.text = "The opponent has died!";
            }
            else
            {
            
                //actionText.gameObject.SetActive(false);
                //enemyNum = 0;
                int upperLimit = 0;
                for (int i = 0; i < stand2.levelRequirements.Length; i++)
                {
                    if (stand2.level >= stand2.levelRequirements[i])
                    {
                        upperLimit++;
                    }
                }
                enemyNum = Random.Range(0, upperLimit);
                /*if (stand2.level <= stand2.levelRequirements[1])
                {
                    enemyNum = Random.Range(0, 2);
                }
                else if (stand2.level <= stand2.levelRequirements[2])
                {
                    enemyNum = Random.Range(0, 3);
                }
                else if (stand2.level >= stand2.levelRequirements[3])
                {
                    enemyNum = Random.Range(0, 4);
                }*/
                if (enemyNum == 0)
                {
                    stand2.Move1();
                    actionText.text = stand2.currentAttackName;
                }
                else if (enemyNum == 1)
                {
                    stand2.Move2();
                    actionText.text = stand2.currentAttackName;
                }
                else if (enemyNum == 2)
                {
                    stand2.Move3();
                    actionText.text = stand2.currentAttackName;
                }
                else if (enemyNum == 3)
                {
                    stand2.Move4();
                    actionText.text = stand2.currentAttackName;
                }
            }
        }
        else if (stand1.index == 3)
        {
            if (stand2.health <= 0)
            {
                arena.SetActive(false);
                stand1.DestroySelf();
                stand2.DestroySelf();
                playerWon = true;
                dialoguePanel.SetActive(true);
            }
            if (stand1.health <= 0)
            {
                actionText.text = "Oh wow you're dead";
            }
            else
            {
                if (stand2.landed)
                {
                    actionText.text = stand2.currentEffectName;
                    if (enemyNum == 0)
                    {
                        stand2.Attack1();
                    }
                    else if (enemyNum == 1)
                    {
                        stand2.Attack2();
                    }
                    else if (enemyNum == 2)
                    {
                        stand2.Attack3();
                    }
                    else if (enemyNum == 3)
                    {
                        stand2.Attack4();
                    }
                }
                else
                {
                    int num = Random.Range(0, 3);
                    if (num == 0)
                    {
                        actionText.text = "It missed! They suck!";
                    }
                    else if (num == 1)
                    {
                        actionText.text = "It failed! Lmao what a noob!";
                    }
                    else if (num == 2)
                    {
                        actionText.text = "Bruh, their aim trash, uninstall noob";
                    }
                }
            }
        }
        else if (stand1.index == 4)
        {
            if (stand1.health <= 0)
            {
                arena.SetActive(false);
                stand1.DestroySelf();
                stand2.DestroySelf();
                playerWon = false;
                dialoguePanel.SetActive(true);
            }
            stand1.index = 0;
            actionText.gameObject.SetActive(false);
            //buttons.SetActive(true);
            //selectedAttack = 0;
            descripText.text = stand1.attackExplainations[selectedAttack];
            //descriptions.SetActive(true);
            actionButtons.SetActive(true);
        }
        else if (stand1.index == 5)
        {
            arena.SetActive(false);
            stand1.DestroySelf();
            stand2.DestroySelf();
            playerWon = true;
            dialoguePanel.SetActive(true);
        }
    }
}
