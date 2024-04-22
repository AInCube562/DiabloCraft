using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item
{
    private protected float damage;
    private protected float speed;
    private protected float power;
    private protected GameObject attackObject;

    public Axe(float damage, float speed, float power)
    {
        this.damage = damage;
        this.speed = speed;
        this.power = power;
    }

    public override void Use(GameObject player)
    {
        base.Use(player);
        var a = Object.Instantiate(attackObject, (player.transform.position + player.transform.up), player.transform.rotation);
        a.GetComponent<AttackObject>().Initialize(ToolType.Axe, power);
    }

    public override void OnChoosen()
    {
        base.OnChoosen();
        attackObject = Resources.Load<GameObject>("Prefabs/attackGameObject");
    }
}
