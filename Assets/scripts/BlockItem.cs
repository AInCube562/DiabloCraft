using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : Item
{
    [SerializeField] private int blockId = 0;
    [SerializeField]private GameObject block;

    public override void Use(GameObject player)
    {
        BetterGrid grid = player.GetComponent<PlayerMovement>().Grid;
        grid.SpawnBlock(1, block, new Vector2Int(0, 0));
    }
}
