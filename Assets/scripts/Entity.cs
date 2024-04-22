using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))][RequireComponent(typeof(SpriteRenderer))]
public class Entity : MonoBehaviour
{
    [SerializeField] private protected Sprite sprite;
    [SerializeField][Min(0)] private protected float health;
    [SerializeField] private protected bool canTakeDamage = true;

    public static void LookAt(Transform obj, Vector2 point)
    {
        Vector2 b;
        float angle;
        double tan;

        b.x = obj.position.x;
        b.y = point.y;

        tan = (point.x - b.x) / (b.y - obj.position.y);

        double l = Math.Atan(tan);
        angle = Convert.ToSingle(l * (180 / Math.PI));

        if (b.y < obj.position.y)
        {
            angle += 180;
        }
        obj.rotation = Quaternion.Euler(0, 0, -angle);
    }

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0 && canTakeDamage) 
        {
            Die();
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }

}
