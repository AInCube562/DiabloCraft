using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryUI ui;
    [SerializeField] private Item activeItem = ItemsList.AIR_ITEM;
    [SerializeField] private Drop drop;
    [SerializeField] private GameObject itemGameObject;
    [SerializeField] private int activeSlotId;

    [Header("Items")]
    [SerializeField] private InventorySlot[] items = new InventorySlot[10];

    private void Start()
    {
        for (int i = 0; i < items.Length; i++) 
        {
            if (items[i] == null) 
            {
                items[i] = new InventorySlot(ItemsList.items[0]);
            }
        }
    }

    public void UpdateUI(InventorySlot slot, int slotId)
    {
        ui.SetSlot(slot, slotId);
        ui.SetItemName(slot.Item.Name);
    }

    public void Drop()
    {
        if(activeItem.Id == 0)
        {
            return;
        }

        GameObject a = itemGameObject;
        a.GetComponent<ItemGameObject>().Initialize(activeItem.Id, activeSlotId);
        drop.SpawnItemObject(a, transform.position + transform.up, items[activeSlotId].Amount, transform.up);
        items[activeSlotId] = new InventorySlot(ItemsList.AIR_ITEM);
        UpdateUI(items[activeSlotId], activeSlotId);
        activeItem = ItemsList.AIR_ITEM;
    }

    public void SetActiveItem(int id)
    {
        activeItem = items[id].Item;
        activeItem.OnChoosen();
        activeSlotId = id;
        ui.SetSprites(id);
        ui.SetItemName(activeItem.Name);
        Debug.Log("Active Item choosen");
    }

    public void Use()
    {
        activeItem.Use(gameObject);
    }

    public void GetItem(Item currentItem, GameObject obj, int amount = 1) 
    {
        int index = 0;
        
        while((items[index].Item.Id != currentItem.Id && items[index].Item.Id != 0) || items[index].Amount == items[index].Item.MaxAmount)
        {
            index++;
            if(index == items.Length)
            {
                return;
            }
        }

        if (items[index].Item.Id == 0)
        {
            items[index] = new InventorySlot(currentItem);
        }

        Destroy(obj);

        items[index].PlusAmount(amount);
        UpdateUI(items[index], index);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ItemGameObject>()) 
        {
            ItemGameObject itemGameObject = other.gameObject.GetComponent<ItemGameObject>();
            GetItem(itemGameObject._Item, itemGameObject.gameObject, itemGameObject.amount);
        }
    }
}
