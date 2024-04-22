using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItemHandler : MonoBehaviour
{
    [SerializeField] private InventorySlot inventorySlot;

    public void SetItem(InventorySlot slot) 
    {
        inventorySlot = slot;
    }

    public void Use() 
    {
        if (inventorySlot == null) 
        {
            Debug.LogError("No UseItem");
            return;
        }
        inventorySlot.Item.Use(gameObject);
    }
}
