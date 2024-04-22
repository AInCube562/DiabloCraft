using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    [SerializeField] private float lifeSeconds;
    private ToolType type;
    private float damage;

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(lifeSeconds);
        Destroy(gameObject);
    }

    public void Initialize(ToolType type, float damage)
    {
        this.type = type;
        this.damage = damage;
        StartCoroutine(Live());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Block>())
        {
            Block block = collision.GetComponent<Block>();

            if(block.GetComponent<Tree>() && type == ToolType.Axe)
            {
                block.TryBreak(damage * 1.5f);
                return;
            }

            block.TryBreak(damage);
        }
    }
}
