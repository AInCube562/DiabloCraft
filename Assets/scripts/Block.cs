using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))][RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private int blockId;
    [SerializeField][Min(0)] private float strength;
    [SerializeField] private bool canBreaked = true;
    [SerializeField] private Drop drop;
    [SerializeField][Min(0)] private int layer;

    public int ID => blockId;

    private SpriteRenderer spriteRenderer;

    private void Render()
    {
        spriteRenderer.enabled = true;
    }

    private void UnRender()
    {
        spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlocksRenderer>())
        {
            Render();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BlocksRenderer>())
        {
            UnRender();
        }
    }

    public int Layer => layer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UnRender();
    }

    private void OnMouseDown()
    {
        TryBreak(1);    
    }

    public void TryBreak(float toolPower) 
    {
        if (canBreaked) 
        {
            strength -= toolPower;
            if (strength <= 0) 
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        drop.SpawnItemObject(transform.position);
        Destroy(gameObject);
    }
}
