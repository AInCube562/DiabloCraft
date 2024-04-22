using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Sprite choosenSprite;
    [SerializeField] private Sprite notChoosenSprite;
    [SerializeField] private SlotUI[] slots = new SlotUI[10];
    [SerializeField] private TMP_Text itemName;
    private Animator itemNameAnimator;

    public void SetItemName(string text)
    {
        itemNameAnimator.Play("Fade");
        itemName.text = text;
    }

    private void Start()
    {
        itemNameAnimator = itemName.GetComponent<Animator>();

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].Initialize(inventory, i);
        }
    }
     
    public void SetSprites(int id)
    {
        foreach(SlotUI slot in slots)
        {
            slot.GetComponent<Image>().sprite = notChoosenSprite;
            slot.transform.localScale = slot.GetStartScale();
        }

        slots[id].GetComponent<Image>().sprite = choosenSprite;
        slots[id].transform.localScale *= 1.2f;
    }

    public void SetSlot(InventorySlot slot, int slotId) 
    {
        slots[slotId].SetUi(slot.Item._Sprite, slot.Amount.ToString());
    }
}
