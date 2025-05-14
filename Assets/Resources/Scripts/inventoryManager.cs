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
    Camera head;
    [SerializeField]
    float itemPlaceLength;

    string inventoryText;

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

                    // dags att fixa
                    RaycastHit hit;
                    if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, itemPlaceLength)) 
                    {
                        Instantiate(inventory[i], hit.point - (head.transform.position + head.transform.forward), head.transform.rotation);
                        print(hit.point - (head.transform.position + head.transform.forward));
                    }
                    else
                    {
                        Instantiate(inventory[i], head.transform.position + head.transform.forward * itemPlaceLength, head.transform.rotation);
                    }
                    print(hit.point);
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
