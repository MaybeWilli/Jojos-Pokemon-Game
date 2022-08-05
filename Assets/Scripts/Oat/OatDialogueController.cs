using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OatDialogueController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject panel;
    public Text text;
    public string[] words;
    [TextArea]
    public string[] optionText;
    public string[] options;
    private int index = 0;
    public Text chooseText;
    public GameObject choosePanel;
    public GameObject chooses;
    private string chosenStand;
    private PlayerController playerController;
    private string playerName;
    private string rivalName;
    public InputField input;
    public string[] stands;
    private int enemyIndex;
    public GameObject rival;
    private RivalController rivalController;
    public Text buttonText;
    public GameObject arena;
    public GameObject[] standPrefabs;
    private bool battleStarted = false;
    private int playerIndex;

    void OnEnable()
    {
        if (battleStarted)
        {
            buttonText.text = "Continue";
            bool won = arena.GetComponent<BattleController>().playerWon;
            if (won)
            {
                text.text = "Prof Oat: Wow u won! How cool.";
                playerController.stands[0].level++;
            }
            else
            {
                text.text = "Prof Oat: U lose, lmao gg ez";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        input.gameObject.SetActive(false);
        chooses.SetActive(false);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rivalController = rival.GetComponent<RivalController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        if (playerController.started)
        {
            panel.SetActive(true);
            playerController.shouldMove = false;
            int num = Random.Range(0, 3);
            if (num == 0)
            {
                text.text = "Go catch some other poke-jojos!";
            }
            else if (num==1)
            {
                text.text = "Get outta here, lazy fortnite child!";
            }
            else if (num==2)
            {
                text.text = "Shoo!";
            }
        }
        else
        {
            panel.SetActive(true);
            text.text = words[index];
            playerController.shouldMove = false;
        }

    }

    public void Continue()
    {
        if (playerController.started)
        {
            panel.SetActive(false);
            playerController.shouldMove = true;
        }
        index++;
        if (index < words.Length)
        {
            text.text = words[index];
        }
        else
        {
            if (index == words.Length)
            {
                input.gameObject.SetActive(true);
                text.text = "Wait, what was your name again?";
            }
            else if (index == words.Length+1)
            {
                playerName = input.text;
                input.gameObject.SetActive(false);
                text.text = "Oh right, it was "+playerName+"!";
            }
            else if (index == words.Length+2)
            {
                rival.SetActive(true);
                rivalController.StartMoving();
                text.text = "And your rival...";
            }
            else if (index == words.Length+3)
            {
                input.text = "";
                input.gameObject.SetActive(true);
                text.text = "What was his name again?";
            }
            else if (index == words.Length+4)
            {
                rivalName = input.text;
                input.gameObject.SetActive(false);
                text.text = "Oh right, it was "+rivalName+"!";
            }
            else if (index == words.Length+5)
            {
                text.text = "Anyways, you gotta choose your poke-jojos now!";
            }
            else if (index == words.Length+6)
            {
                text.text = "";
                chooses.SetActive(true);
                Option1();
            }
            else if (index == words.Length+7)
            {
                chooses.SetActive(false);
                text.text = chosenStand+"? An exellent choice!";
            }
            else if (index == words.Length+8)
            {
                chooses.SetActive(false);
                text.text = "Your rival "+rivalName+" gets "+stands[enemyIndex]+"!";
            }
            else if (index == words.Length+9)
            {
                //text.SetActive(true);
                chooses.SetActive(false);
                text.text = "You aquired a "+chosenStand+"!";
            }
            else if (index == words.Length+10)
            {
                text.text = rivalName+": Wait, lets have a fight! And other generic rival dialogue.";
                buttonText.text = "Battle";
                playerController.stands[0] = new SavedStand(standPrefabs[playerIndex], 1, chosenStand);
                
            }
            else if (index == words.Length+11)
            {
                //panel.SetActive(false);
                battleStarted = true;
                string standName = standPrefabs[playerIndex].GetComponent<Stand>().standName;
                arena.GetComponent<BattleController>().StartBattle(standPrefabs[playerIndex], standPrefabs[enemyIndex], 1, 1, rivalName+"'s", gameObject, standName);
                gameObject.SetActive(false);
            }
            
            else if (index == words.Length+12)
            {
                text.text = "Anyways, you should now go catch poke-jojos! (kicks you away)!";
                buttonText.text = "Close";
            }
            else if (index == words.Length+13)
            {
                panel.SetActive(false);
                playerController.started = true;
                playerController.shouldMove = true;
            }
            /*else if (index == words.Length+11)
            {
                panel.SetActive(false);
                playerController.shouldMove = true;
                playerController.started = true;
            }*/
        }
    }

    public void Option1()
    {
        chosenStand = stands[0];
        chooseText.text = optionText[0];
        playerIndex = 0;
        enemyIndex = 1;
    }

    public void Option2()
    {
        chosenStand = stands[1];
        chooseText.text = optionText[1];
        enemyIndex = 2;
        playerIndex = 1;
    }

    public void Option3()
    {
        chosenStand = stands[2];
        chooseText.text = optionText[2];
        enemyIndex = 0;
        playerIndex = 2;
    }
}
