using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MobMovement
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private BetterGrid grid;
    public BetterGrid Grid => grid;

    private void Start()
    {
        grid = FindObjectOfType<BetterGrid>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            inventory.Drop();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            inventory.Use();
        }

        Vector2 direction = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A)) 
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        Move(direction);

        Entity.LookAt(transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
