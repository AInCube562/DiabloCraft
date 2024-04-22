using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private BetterGrid grid;
    [SerializeField] private GameObject[] blocks;

    public void Initialize(BetterGrid mainGrid) 
    {
        grid = mainGrid;
        foreach (GameObject block in blocks) 
        {
            grid.SpawnBlock(1, block, new Vector2Int((int)block.transform.position.x, (int)block.transform.position.y), false);
        }
        Destroy(gameObject);
    }

    public virtual bool CheckCanSpawn() 
    {
        return false;
    }


}
