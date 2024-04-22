using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGameObject : MonoBehaviour
{
    [SerializeField] private int itemID;
    [SerializeField][Min(0)] public int amount;
    private Item item;
    public Item _Item => item;

    private SpriteRenderer mainSprite;
    [SerializeField] private SpriteRenderer[] multipleSprites;

    public void Initialize(int id, int amount = 0)
    {
        itemID = id;
        this.amount = amount;
        item = ItemsList.items[itemID];
        mainSprite = GetComponent<SpriteRenderer>();
        mainSprite.sprite = item._Sprite;
    }

    private void Start()
    {
        Initialize(itemID, amount);

        for(int i = 0; i < multipleSprites.Length; i++)
        {
            Transform sprite = multipleSprites[i].transform;
            sprite.position = new Vector3(sprite.position.x, sprite.position.y, sprite.position.z + (i * 0.1f));
        }

        if (amount >= 2)
        {
            multipleSprites[0].sprite = item._Sprite;
        }

        if(amount > 2)
        {
            foreach(SpriteRenderer sprite in multipleSprites)
            {
                sprite.sprite = item._Sprite;
            }
        }
    }
}
