using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // Terrain parameters
    public int terrainSize = 100;                   // Size of the terrain
    public float scale = 1f;                         // Scale of the Perlin noise
    public float terrainHeightMultiplier = 10f;      // Multiplier for terrain height
    public AnimationCurve heightCurve;               // Curve for customizing terrain height
    public int octaves = 4;                          // Number of Perlin noise octaves
    public float persistence = 0.5f;                 // Persistence for Perlin noise
    public float lacunarity = 2.0f;                  // Lacunarity for Perlin noise

    // Unity callbacks
    void Start()
    {
        GenerateTerrain(); // Generate terrain on start
    }

    // Re-generate terrain when inspector values are changed
    void OnValidate()
    {
        if (enabled)
        {
            GenerateTerrain();
        }
    }

    // Generate terrain
    void GenerateTerrain()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainData(terrain.terrainData);
    }

    // Generate terrain data
    TerrainData GenerateTerrainData(TerrainData terrainData)
    {
        // Set terrain parameters
        terrainData.heightmapResolution = terrainSize + 1;
        terrainData.size = new Vector3(terrainSize, terrainHeightMultiplier, terrainSize);

        // Generate heights
        terrainData.SetHeights(0, 0, GenerateHeights(terrainData.heightmapResolution));

        return terrainData;
    }

    // Generate terrain heights
    float[,] GenerateHeights(int resolution)
    {
        float[,] heights = new float[resolution, resolution];

        for (int x = 0; x < resolution; x++)
        {
            for (int z = 0; z < resolution; z++)
            {
                float xCoord = (float)x / resolution * scale;
                float zCoord = (float)z / resolution * scale;

                float height = CalculateTerrainHeight(xCoord, zCoord);
                heights[x, z] = height;
            }
        }

        return heights;
    }

    // Calculate terrain height at given coordinates
    float CalculateTerrainHeight(float x, float z)
    {
        float height = 0;

        for (int i = 0; i < octaves; i++)
        {
            float xCoord = x * scale * Mathf.Pow(lacunarity, i);
            float zCoord = z * scale * Mathf.Pow(lacunarity, i);

            height += heightCurve.Evaluate(Mathf.PerlinNoise(xCoord, zCoord)) * Mathf.Pow(persistence, i);
        }

        return height;
    }
}

