using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterGrid : MonoBehaviour
{
    [SerializeField]private GridLayer[] layers = new GridLayer[2];
    [SerializeField]private Vector2Int size;
    [SerializeField]private Block air;
    [SerializeField] private Graph graph;

    public GridLayer[] Layers => layers;

    public void Initialize(Vector2Int gridSize) 
    {
        size = gridSize;
        graph = new Graph(size);
        foreach (GridLayer layer in layers) 
        {
            layer.Initialize(size, air);
        }
    }

    private bool IsAir(Vector2Int point)
    {
        return layers[1].GetBlockTransform(point).GetComponent<Block>().ID == air.ID;
    }

    public void UpdateGraph()
    {
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                Vector2Int point = new Vector2Int(x, y);
                if (IsAir(point))
                {
                    if(y < size.y - 1)
                    {
                        graph.SetConnection(point, 0, IsAir(new Vector2Int(point.x, point.y + 1)));
                    }

                    if (x < size.x - 1)
                    {
                        graph.SetConnection(point, 1, IsAir(new Vector2Int(point.x + 1, point.y)));
                    }

                    if (y > 0)
                    {
                        graph.SetConnection(point, 2, IsAir(new Vector2Int(point.x, point.y - 1)));
                    }

                    if (x > 0)
                    {
                        graph.SetConnection(point, 3, IsAir(new Vector2Int(point.x - 1, point.y)));
                    }
                }
                else { 
                    for(int i = 0; i < 4; i++)
                    {
                        graph.SetConnection(point, i, false);
                    }
                }
            }
        }
    }

    public void Render()
    {
        gameObject.SetActive(true);
        UpdateGraph();
    }

    public void UnRender()
    {
        gameObject.SetActive(false);
    }

    public void SpawnBlock(int layerID, GameObject block, Vector2Int blockPosition, bool updateGraph = true) 
    {
        layers[layerID].SpawnBlock(block, blockPosition);

        if (updateGraph)
        {
            UpdateGraph();
        }
    }
}
