using UnityEngine;
//Early code to switch shaders for other weather implementation
public class ShaderSwitcher : MonoBehaviour
{
    public Material objectMaterial; // Reference to the material attached to your object
    public Shader snowShader; // Reference to the Snow Shader
    public Shader rainShader; // Reference to the Rain Shader

    private void Start()
    {
        // Set the initial shader to the snow shader
        SwitchToSnowShader();
    }

    public void SwitchToSnowShader()
    {
        objectMaterial.shader = snowShader;
        objectMaterial.EnableKeyword("_SNOW_ON");  // Enable any specific shader keywords if needed
        objectMaterial.DisableKeyword("_RAIN_ON"); // Disable any conflicting shader keywords
    }

    public void SwitchToRainShader()
    {
        objectMaterial.shader = rainShader;
        objectMaterial.EnableKeyword("_RAIN_ON");  // Enable any specific shader keywords if needed
        objectMaterial.DisableKeyword("_SNOW_ON"); // Disable any conflicting shader keywords
    }
}
