using System;
using UnityEngine.Tilemaps;
using UnityEngine;

[Serializable]
 public class Tile 
{
    [SerializeField] private string name;
    [SerializeField] private GameObject block;

    [SerializeField] [Range(0, 1)] private float min;
    [SerializeField] [Range(0, 1)] private float max;

    public float GetMin() 
    {
        return min;
    }

    public float GetMax() 
    {
        return max;
    }

    public Block GetBlock() 
    {
        return block.GetComponent<Block>();
    }
}

[Serializable] [CreateAssetMenu(fileName = "Biome", menuName = "Generation/Biome", order = 0)]
public class Biome : ScriptableObject
{
    [Header("Tile")]
    [SerializeField] private Tile[] tiles = new Tile[1];
    [SerializeField] private Tile standartTile;

    [Header("Humidity")]
    [SerializeField] [Range(0, 1)] private float humidityMin;
    [SerializeField] [Range(0, 1)] private float humidityMax;

    [Header("Temperature")]
    [SerializeField] [Range(0, 1)] private float temperatureMin;
    [SerializeField] [Range(0, 1)] private float temperatureMax;

    [SerializeField] private GameObject[] structuresPrefabs;
    public GameObject[] StructuresPrefabs => structuresPrefabs;

    public bool CheckCompatibility(float humidity, float temperature) 
    {
        return ((humidityMin < humidity) && (humidity <= humidityMax)) && ((temperatureMin < temperature) && (temperature <= temperatureMax)); 
    }

    public Tile GetTile(float gradient)
    {
        standartTile = tiles[0];

        foreach(Tile a in tiles) 
        {           
            if (a.GetMin() < gradient)
            {
                if (a.GetMax() > gradient)
                {
                    return a;
                }
            }      
        }

        return standartTile;
    }
}
