using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Biome[] biomes;
    [SerializeField] private GameObject chunkPrefab;
    private GameObject[,] chunks;
    private Chunk mainChunk;

    [SerializeField] private Vector2Int worldSize;
    [SerializeField] [Range(1.03f, 100)] private float zoom;
    [SerializeField] [Range(1, 9999)] private int seed;

    [SerializeField] private float constantsZoom = 4;


    private Vector2Int GetSeed() 
    {
        string a = seed.ToString();

        while (a.Length < 4) 
        {
            a = '0' + a;
        }

        int x = Convert.ToInt32(a[0].ToString() + a[1].ToString());
        int y = Convert.ToInt32(a[2].ToString() + a[3].ToString());

        return new Vector2Int(x, y);
    }

    private float GetTemperatureGradient(float x, float y) 
    {
        return Mathf.PerlinNoise((x) / constantsZoom, (y) / constantsZoom);
    }

    private float GetHumidityGradient(float x, float y)
    {
        return Mathf.PerlinNoise((x) / constantsZoom * 1.4f, (y) / constantsZoom * 1.4f);
    }

    void Awake()
    {

        seed = UnityEngine.Random.Range(1, 9999);

        UnityEngine.Random.InitState(seed);

        chunks = new GameObject[worldSize.x, worldSize.y];

        for (int x = 0; x < worldSize.x; x++)
        {
            for (int y = 0; y < worldSize.y; y++)
            {
                Vector2Int seedPosition = GetSeed();
                int globalX = x + seedPosition.x;
                int globalY = y + seedPosition.y;

                float gradient = Mathf.PerlinNoise((globalX) / zoom, (globalY) / zoom);

                Biome currentBiome = biomes[0];

                foreach (Biome a in biomes) 
                {
                    if (a.CheckCompatibility(GetHumidityGradient(globalX, globalY), GetTemperatureGradient(globalX, globalY))) 
                    {
                        currentBiome = a;
                        break;
                    }                    
                }

                Vector2Int chunkPosition = new Vector2Int(x, y - 1);

                chunks[x, y] = Instantiate(chunkPrefab, transform);
                chunks[x, y].GetComponent<Chunk>().Initialize(chunkPosition, currentBiome, gradient);
            }
        }
    }
}
