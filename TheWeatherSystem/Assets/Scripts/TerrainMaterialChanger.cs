using UnityEngine;

public class TerrainMaterialChanger : MonoBehaviour
{
    public Material[] materials; // Drag and drop the materials to this array in the Unity Editor

    private int currentMaterialIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeTerrainMaterial();
        }
    }

    void ChangeTerrainMaterial()
    {
        // Check if there is a terrain in the scene
        Terrain terrain = Terrain.activeTerrain;

        if (terrain != null)
        {
            // Change the terrain material to the next one in the array
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
            terrain.materialTemplate = materials[currentMaterialIndex];
        }
        else
        {
            Debug.LogWarning("No active terrain found in the scene.");
        }
    }
}
