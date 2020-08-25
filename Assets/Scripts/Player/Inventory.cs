using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventoryUI _ui;

    int _treasureCount = 0;

    private void Start()
    {
        _ui.SetInventoryText();
    }

    public void IncreaseTreasure(int amount)
    {
        _treasureCount += amount;
        _ui.SetInventoryText();
    }

    public int GetTreasure()
    {
        return _treasureCount;
    }
}
