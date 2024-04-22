using UnityEngine;


public class Graph
{
    private Graphpoint[,] points;

    public void SetConnection(Vector2Int point, int connectionId, bool value)
    {
        points[point.x, point.y].SetConnection(connectionId, value);
    }

    public Graph(Vector2Int size)
    {
        points = new Graphpoint[size.x, size.y];
        for(int x = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                points[x, y] = new Graphpoint(new Vector2Int(x, y));
            }
        }
    }
}
