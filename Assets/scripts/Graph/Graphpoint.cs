using UnityEngine;

public class Graphpoint
{
    private Vector2Int position;
    private bool[] connections = new bool[4];

    public Vector2Int Position => position;

    public Graphpoint(Vector2Int position)
    {
        this.position = position;
    }

    public void SetConnection(int connectionId, bool value)
    {
        connections[connectionId] = value;
    }
    
    public bool IsConnected(int connectionId)
    {
        return connections[connectionId];
    }
}
