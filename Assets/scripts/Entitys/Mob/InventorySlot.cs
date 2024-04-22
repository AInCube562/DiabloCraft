using System.Collections;
using System;
using UnityEngine; 

[Serializable]
public class InventorySlot
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 0;

    public Item Item => item;
    public int Amount => amount;

    public InventorySlot(Item item) 
    {
        this.item = item;
    }

    public void PlusAmount(int a) 
    {
        if (item.MaxAmount < amount + a)
        {
            amount += item.MaxAmount - amount;
        }
        else 
        {
            amount += a;
        }               
    }
}
