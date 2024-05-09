using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SnowSimulator : MonoBehaviour
{
    // Snow simulation parameters
    public Material material;
    private float snowWeight = 0.0f;
    public bool isSnowSimulationActive = false;
    public float snowUpdateSpeed = 0.01f;
    public float snowfallBuildUp = 0.001f;
    public float maxSnowWeight = 50.0f;
    public float durationOfSnow = 10f;
    public Vector2 snowWeightScale;
    public float snowMelt = 0.001f;
    public float minSnowWeight = 0.0f;

    // Coroutines for snow simulation
    private Coroutine snowCoroutine;
    private Coroutine snowMeltCoroutine;

    // Particle system for snow simulation
    private ParticleSystem ps;

    // Heightmap textures
    public Texture2D heightmap1; // First heightmap texture
    public Texture2D heightmap2; // Second heightmap texture
    private bool useHeightmap1 = true;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        SwitchOnSnowSimulation();
        SwitchHeightmap();
    }

    private void Update()
    {
        SwitchOnSnowSimulation();
    }

    // Toggle snow simulation on/off
    public void SwitchOnSnowSimulation()
    {
        if (isSnowSimulationActive)
        {
            if (snowCoroutine == null)
            {
                ps.Play();
                useHeightmap1 = true;
                SwitchHeightmap();
                snowCoroutine = StartCoroutine(StartCoroutineIncreaseSnowWeight());
            }
            StopSnowMeltCoroutine();
        }
        else
        {
            if (snowMeltCoroutine == null)
            {
                ps.Stop();
                useHeightmap1 = false;
                SwitchHeightmap();
                snowMeltCoroutine = StartCoroutine(StartCoroutineDecreaseSnowWeight());
            }
            StopSnowCoroutine();
        }
    }

    // Stop snow increase coroutine
    private void StopSnowCoroutine()
    {
        if (snowCoroutine != null)
        {
            StopCoroutine(snowCoroutine);
            snowCoroutine = null;
        }
    }

    // Stop snow melt coroutine
    private void StopSnowMeltCoroutine()
    {
        if (snowMeltCoroutine != null)
        {
            StopCoroutine(snowMeltCoroutine);
            snowMeltCoroutine = null;
        }
    }

    // Coroutine for increasing snow weight
    private IEnumerator StartCoroutineIncreaseSnowWeight()
    {
        while (snowWeight < maxSnowWeight)
        {
            yield return new WaitForSeconds(snowUpdateSpeed);
            snowWeight = Mathf.Min(snowWeight + snowfallBuildUp, maxSnowWeight);
            UpdateSnowWeight();
        }
    }

    // Coroutine for decreasing snow weight
    private IEnumerator StartCoroutineDecreaseSnowWeight()
    {
        while (snowWeight > minSnowWeight)
        {
            yield return new WaitForSeconds(snowUpdateSpeed);
            snowWeight = Mathf.Max(snowWeight - snowMelt, minSnowWeight);
            UpdateSnowWeight();
        }
    }

    // Update snow weight in material
    private void UpdateSnowWeight()
    {
        material.SetFloat("_SnowWeight", snowWeight);
    }

    // Ensure final snow weight is applied before quitting
    private void OnApplicationQuit()
    {
        snowWeight = 0.0f;
        UpdateSnowWeight();
    }

    // Switch between heightmap textures
    private void SwitchHeightmap()
    {
        if (material.HasProperty("_HeightMap"))
        {
            Texture2D currentHeightmap = useHeightmap1 ? heightmap1 : heightmap2;
            material.SetTexture("_HeightMap", currentHeightmap);
        }
        else
        {
            Debug.LogError("Shader property '_Heightmap' not found in the material!");
        }
    }
}
