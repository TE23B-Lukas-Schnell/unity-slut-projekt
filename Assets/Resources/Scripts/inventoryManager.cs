using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> inventory = new List<GameObject>();

    bool showInventory = false;

    [SerializeField]
    TMP_Text inventoryHud;
    [SerializeField]
    Vector3 itemSpawnOffset;
    string inventoryText;

    void Start()
    {

    }

    void Update()
    {
        if (!showInventory)
        {
            inventoryHud.text = "";
        }
        else
        {   //shows invenotory
            inventoryText = "";
            for (int i = 0; i < inventory.Count; i++)
            {
                string itemText = inventory[i].ToString();

                if (itemText.Contains("(UnityEngine.GameObject)"))
                {
                    itemText = itemText.Replace("(UnityEngine.GameObject)", "");
                }
                inventoryText += (i + 1).ToString() + ": " + itemText + "\n";
            }
            inventoryHud.text = inventoryText;
        }

        //instantiate inventory item
        for (int i = 0; i < inventory.Count; i++)
        {
            if (i <= 9)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    Instantiate(inventory[i], transform.position + itemSpawnOffset, Quaternion.identity);
                    inventory.Remove(inventory[i]);
                    break;
                }
            }
        }
    }

    void OnOpenInventory()
    {
        showInventory = !showInventory;
    }

}
