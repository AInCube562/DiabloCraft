using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLayer : MonoBehaviour
{
    private Block[,] blocks;
    private Vector2Int size;
    private Block air;

    public Transform GetBlockTransform(Vector2Int blockID) 
    {
        return blocks[blockID.x, blockID.y].transform;
    }

    public void Initialize(Vector2Int layerSize, Block airBlock) 
    {
        size = layerSize;
        air = airBlock;

        blocks = new Block[size.x, size.y];
        for (int x = 0; x < size.x; x++) 
        {
            for (int y = 0; y < size.y; y++) 
            {                
                SpawnBlock(air.gameObject, new Vector2Int(x, y));
            }
        }
    }

    public void SpawnBlock(GameObject block, Vector2Int position) 
    {
        blocks[position.x, position.y] = block.GetComponent<Block>();
        GameObject a = Instantiate(block, transform);
        a.transform.position = new Vector3(position.x, position.y, transform.position.z) + transform.position;
    }

}
