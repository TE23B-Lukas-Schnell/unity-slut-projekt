using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class inventoryManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> inventory = new List<GameObject>();

   
    bool showInventory = false;

    [SerializeField]
    TMP_Text inventoryHud;
     string inventoryText;

    void Start()
    {

    }

    void Update()
    {
        if (inventory.Count > 0)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                inventoryText += inventory[i].ToString();
            }
        }
    }

    void OnOpenInventory()
    {
        showInventory = !showInventory;
    }

}
