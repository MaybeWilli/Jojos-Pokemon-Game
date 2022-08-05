using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool shouldMove = true;
    public float speed;
    public float distanceFromEdge;
    private GameObject bg;
    private BgScrollController bgScrollController;
    public bool started = false;
    public SavedStand[] stands = new SavedStand[4];
    public GameObject arena;
    public GameObject[] possibleStands;
    public GameObject[] bossStands;
    private int enemyIndex;
    private float averageLevel;
    public GameObject battlePanel;
    public Text battleText;
    private bool isBattle = false;
    private bool canBattle = true;
    private float battleTimer;
    public GameObject inventory;
    private BattleController battleController;
    public GameObject options;
    private int selectedStand;
    private string currentFight;
    private GameObject villain;
    private int villainNum = 3;
    public GameObject closeButton;

    void OnEnable()
    {
        if (isBattle)
        {
            bool shouldDeactivate = true;
            if (currentFight == "Grass")
            {
                if (battleController.addToParty)
                {
                    stands[battleController.fitIndex] = new SavedStand(possibleStands[enemyIndex], battleController.level2, possibleStands[enemyIndex].GetComponent<Stand>().standName);
                }

                if (battleController.playerWon)
                {
                    stands[selectedStand].level++;
                }
            }
            else if (currentFight == "Dio" || currentFight == "Yoshikage" || currentFight == "Diavolo")
            {
                if (battleController.playerWon)
                {
                    villain.GetComponent<VillainController>().DestroySelf();
                    villainNum -= 1;
                    if (villainNum == 0)
                    {
                        shouldDeactivate = false;
                        battlePanel.SetActive(true);
                        options.SetActive(false);
                        closeButton.SetActive(true);
                        battleText.gameObject.SetActive(true);
                        battleText.text = "Congrats, you have defeated the Whatever League! Now you're the greatest poke-jojo trainer, or whatever.";
                    }
                }
                
            }

            canBattle = false;
            battleTimer = 0;
            isBattle = false;
            if (shouldDeactivate)
            {
                shouldMove = true;
                battlePanel.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.FindGameObjectWithTag("Ground");
        bgScrollController = bg.GetComponent<BgScrollController>();
        battlePanel.SetActive(false);
        battleController = arena.GetComponent<BattleController>();
        options.SetActive(false);
        closeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            MovePlayer();
        }

        if (!canBattle)
        {
            battleTimer += Time.deltaTime;
            if (battleTimer >= 2f)
            {
                battleTimer = 0;
                canBattle = true;
            }
        }
    }

    void MovePlayer()
    {
        Vector2 input = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y > distanceFromEdge)
            {
                bgScrollController.Scroll(new Vector2(0, speed * Time.deltaTime));
            }
            else
            {
                input.y += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y < -distanceFromEdge)
            {
                bgScrollController.Scroll(new Vector2(0, -speed * Time.deltaTime));
            }
            else
            {
                input.y -= speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x < -distanceFromEdge)
            {
                bgScrollController.Scroll(new Vector2(-speed * Time.deltaTime, 0));
            }
            else
            {
                input.x -= speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x > distanceFromEdge)
            {
                bgScrollController.Scroll(new Vector2(speed * Time.deltaTime, 0));
            }
            else
            {
                input.x += speed * Time.deltaTime;
            }
        }
        transform.position += new Vector3(input.x, input.y, 0);

        if (Input.GetKeyDown(KeyCode.R)) //For Debugging Only (remove later)
        {
            for (int i = 0; i < stands.Length; i++)
            {
                if (stands[i] != null)
                {
                    stands[i].level = stands[i].level + 1;
                }
            }
        }
        
    }

    public void Close()
    {
        battlePanel.SetActive(false);
        shouldMove = true;
    }

    public void Battle()
    {
        if (stands[selectedStand] != null)
        {
            if (currentFight == "Grass")
            {
                arena.GetComponent<BattleController>().StartBattle(stands[selectedStand].prefab, possibleStands[enemyIndex], stands[selectedStand].level, (int)Mathf.Round(averageLevel), "The wild", gameObject, stands[selectedStand].name);
            }
            else if (currentFight == "Yoshikage")
            {
                arena.GetComponent<BattleController>().StartBattle(stands[selectedStand].prefab, bossStands[1], stands[selectedStand].level, 15, "Yoshikage Kira's", gameObject, stands[selectedStand].name);
            }
            else if (currentFight == "Dio")
            {
                arena.GetComponent<BattleController>().StartBattle(stands[selectedStand].prefab, bossStands[0], stands[selectedStand].level, 10, "Dio Brando's", gameObject, stands[selectedStand].name);
            }
            else if (currentFight == "Diavolo")
            {
                arena.GetComponent<BattleController>().StartBattle(stands[selectedStand].prefab, bossStands[2], stands[selectedStand].level, 25, "Diavolo the 7569th's", gameObject, stands[selectedStand].name);
            }
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Prof Oak"))
        {
            other.GetComponent<OatDialogueController>().StartDialogue();
        }
        else if (other.CompareTag("Grass"))
        {
            if (started && canBattle)
            {
                currentFight = "Grass";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                enemyIndex = Random.Range(0, 4);
                averageLevel = 0;
                int availableStands = 0;
                for (int i = 0; i < stands.Length; i++)
                {
                    if (stands[i] != null)
                    {
                        averageLevel += stands[i].level;
                        availableStands++;
                    }
                }
                averageLevel = averageLevel/availableStands;
                battleText.text = "A wild "+possibleStands[enemyIndex].GetComponent<Stand>().standName+" appeared!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
            }

        }
        else if (other.CompareTag("Grass2"))
        {
            if (started && canBattle)
            {
                currentFight = "Grass";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                enemyIndex = Random.Range(4, 7);
                averageLevel = 0;
                int availableStands = 0;
                for (int i = 0; i < stands.Length; i++)
                {
                    if (stands[i] != null)
                    {
                        averageLevel += stands[i].level;
                        availableStands++;
                    }
                }
                averageLevel = averageLevel/availableStands;
                battleText.text = "A wild "+possibleStands[enemyIndex].GetComponent<Stand>().standName+" appeared!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
            }

        }
        else if (other.CompareTag("Grass3"))
        {
            if (started && canBattle)
            {
                currentFight = "Grass";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                enemyIndex = Random.Range(7, 9);
                averageLevel = 0;
                int availableStands = 0;
                for (int i = 0; i < stands.Length; i++)
                {
                    if (stands[i] != null)
                    {
                        averageLevel += stands[i].level;
                        availableStands++;
                    }
                }
                averageLevel = averageLevel/availableStands;
                battleText.text = "A wild "+possibleStands[enemyIndex].GetComponent<Stand>().standName+" appeared!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
            }

        }
        else if (other.CompareTag("Yoshikage"))
        {
            if (started && canBattle)
            {
                currentFight = "Yoshikage";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                battleText.text = "Yoshikage Kira challenges you to a battle!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
                villain = other.gameObject;
            }
        }
        else if (other.CompareTag("Dio"))
        {
            if (started && canBattle)
            {
                currentFight = "Dio";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                battleText.text = "Dio Brando challenges you to a battle!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
                villain = other.gameObject;
            }
        }
        else if (other.CompareTag("Diavolo"))
        {
            if (started && canBattle)
            {
                currentFight = "Diavolo";
                canBattle = false;
                battlePanel.SetActive(true);
                isBattle = true;
                shouldMove = false;
                battleText.text = "Diavolo the 7569th challenges you to a battle!";
                for (int i = 0; i < options.transform.childCount; i++)
                {
                    if (stands[i] != null)
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = stands[i].name;
                    }
                    else
                    {
                        options.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }
                options.SetActive(true);
                villain = other.gameObject;
            }
        }
    }

    public void SelectStand(Button button)
    {
        selectedStand = button.gameObject.transform.GetSiblingIndex();
    }
}
