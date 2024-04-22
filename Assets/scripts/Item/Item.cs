using System;
using UnityEngine;

[Serializable]
public class Item
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int maxAmount = 1;
    [SerializeField] private int id;

    public string Name => _name;
    public Sprite _Sprite => sprite;

    public int MaxAmount => maxAmount;

    public int Id => id;

    public virtual void Use(GameObject player) 
    { 
    
    }

    public virtual void OnChoosen()
    {

    }

    public void Initialize(string name, Sprite sprite, int maxAmount, int id) 
    {
        _name = name;
        this.sprite = sprite;
        this.maxAmount = maxAmount;
        this.id = id;
    }
}
