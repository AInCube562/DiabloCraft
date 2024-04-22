using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemsList
{
    public static List<Item> items = new List<Item>();

    public static Sprite LoadSprite(string imageName, string spriteName)
    {

        Sprite[] all = Resources.LoadAll<Sprite>("Sprites/" + imageName);

        foreach(Sprite sprite in all)
        {
            if(sprite.name == spriteName)
            {
                return sprite;
            }
        }

        Debug.LogError("Sprite " + spriteName + " not found in " + imageName);
        return null;
    }

    private static void AddItem(Item item, string name, Sprite sprite, int maxAmount) 
    {
        item.Initialize(name, sprite, maxAmount, items.Count);
        items.Add(item);
    }

    public static void InitializeItems() 
    {
        AddItem(AIR_ITEM, "", Resources.Load<Sprite>("Sprites/air"), 1);
        AddItem(WOOD_ITEM, "wood", Resources.Load<Sprite>("Sprites/wood"), 100);
        AddItem(TEST_AXE, "axe", Resources.Load<Sprite>("Sprites/axe"), 1);
        AddItem(ROCK, "rock", LoadSprite("items", "items_0"), 100);
    }

    public static Item AIR_ITEM = new Item();

    public static Item WOOD_ITEM = new Item();

    public static Axe TEST_AXE = new Axe(1, 1, 1);

    public static Item ROCK = new Item();
}
