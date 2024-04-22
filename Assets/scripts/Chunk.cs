using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Vector2Int worldPosition;
    private Biome biome;
    [Range(0, 1)] private float high;


    [SerializeField] private Vector2Int chunkSize;
    [SerializeField] private BetterGrid grid;
    

    private bool isGenerated = false;

    public void Initialize(Vector2Int chunkPosition, Biome chunkBiome, float chunkHigh)
    {
        worldPosition = chunkPosition;
        transform.position = new Vector2(worldPosition.x * chunkSize.x, worldPosition.y * chunkSize.y);
        biome = chunkBiome;
        high = chunkHigh;
        UnRender();
    }

    

    public void Render()
    {
        if (!isGenerated)
        {
            Generate();
        }

        grid.Render();
    }

    public void UnRender()
    {
        grid.UnRender();
    }

    public void Generate()
    {
        if (isGenerated)
        {
            return;
        }

        Debug.Log(biome);
        grid = Instantiate(grid, transform);
        grid.Initialize(chunkSize);
        gameObject.SetActive(true);
        for (int x = 0; x < chunkSize.x; x++) 
        {
            for (int y = 0; y < chunkSize.y; y++) 
            {
                Block block = biome.GetTile(high).GetBlock();
                grid.SpawnBlock(block.Layer, block.gameObject, new Vector2Int(x, y), false);
            }
        }
        GenerateStructures();
        isGenerated = true;
    }

    public void GenerateStructures() 
    {
        for(int x = 0; x < chunkSize.x - 1; x++)
        {
            for (int y = 0; y < chunkSize.y - 1; y++)
            {
                foreach(GameObject i in biome.StructuresPrefabs)
                {
                    if (i.GetComponent<Structure>().CheckCanSpawn())
                    {
                        Transform blockTransform = grid.Layers[1].GetBlockTransform(new Vector2Int(x, y));
                        GameObject structure = Instantiate(i, new Vector2(x, y), blockTransform.rotation);
                        structure.GetComponent<Structure>().Initialize(grid);

                    }

                }
            }
        }
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
}
