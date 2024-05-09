using UnityEngine;

//An attempt at getting snow collision

/*public class SnowBuildup : MonoBehaviour
{
    public Terrain terrain;
    public float snowBuildupRate = 0.001f;  // Adjust the rate based on your preference
    public float maxSnowHeight = 1.0f;      // Maximum height for snow buildup

    void Update()
    {
        // Simulate continuous snow buildup over time
        ApplySnowBuildup();
    }

    void ApplySnowBuildup()
    {
        TerrainData terrainData = terrain.terrainData;

        // Loop through each terrain point and increase the height
        int width = terrainData.heightmapResolution;
        int height = terrainData.heightmapResolution;

        float[,] heights = terrainData.GetHeights(0, 0, width, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] += snowBuildupRate * Time.deltaTime;

                // Clamp the height to the maximum snow height
                heights[i, j] = Mathf.Clamp(heights[i, j], 0f, maxSnowHeight);
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }
}*/
