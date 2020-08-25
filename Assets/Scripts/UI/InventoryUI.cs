using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory _inventory;
    [SerializeField] Text _inventoryText;

    public void Start()
    {
        SetInventoryText();
    }

    public void SetInventoryText()
    {
        if (_inventory != null && _inventoryText != null)
        {
            _inventoryText.text = "Treasure: " + _inventory.GetTreasure();
        }
    }
}
