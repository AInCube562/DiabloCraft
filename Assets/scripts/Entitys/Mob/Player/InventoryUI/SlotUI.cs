using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Inventory inventory;
    [SerializeField] private int id;
    private Vector3 startScale;

    public void Choose()
    {
        inventory.SetActiveItem(id);
    }

    public Vector3 GetStartScale()
    {
        return startScale;
    }

    public void Initialize(Inventory inventory, int id)
    {
        this.inventory = inventory;
        this.id = id;
        startScale = transform.localScale;
    }

    public void SetUi(Sprite sprite, string text) 
    {
        this.image.sprite = sprite;
        this.text.text = text;
    }
}
