using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject inventoryPanel;
    public GameObject buttons;
    public Text descripText;
    private int selectedStand;
    public InputField input;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory()
    {
        if (playerController.shouldMove)
        {
            if (inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                //playerController.shouldMove = false;
                inventoryPanel.SetActive(true);
                selectedStand = 0;
                SetText();

                for (int i = 0; i < buttons.transform.childCount; i++)
                {
                    if (playerController.stands[i] != null)
                    {
                        buttons.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = playerController.stands[i].name;
                    }
                    else
                    {
                        buttons.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Empty";
                    }
                }


            }
        }
    }

    public void SelectStand(Button button)
    {
        selectedStand = button.gameObject.transform.GetSiblingIndex();
        input.text = "";
        SetText();
    }

    public void RenameStand()
    {
        if (playerController.stands[selectedStand] != null)
        {
            playerController.stands[selectedStand].name = input.text;
        }
    }

    public void ReleaseStand()
    {
        playerController.stands[selectedStand] = null;
        buttons.transform.GetChild(selectedStand).GetChild(0).GetComponent<Text>().text = "Empty";
        SetText();
    }

    private void SetText()
    {
        if (playerController.stands[selectedStand] != null)
        {
            descripText.text = "Lvl: "+playerController.stands[selectedStand].level.ToString()+"\n"+playerController.stands[selectedStand].prefab.GetComponent<Stand>().description;
        }
        else
        {
            descripText.text = "This slot is empty";
        }
        input.text = "";
    }
}
