using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle shaderToggle; // Reference to the Shader Toggle
    public ShaderSwitcher shaderSwitcher;

    private void Start()
    {
        // Add a listener for toggle changes
        shaderToggle.onValueChanged.AddListener(ToggleShader);

        // Set the initial shader to the snow shader
        ToggleShader(shaderToggle.isOn);
    }

    private void ToggleShader(bool isOn)
    {
        if (isOn)
        {
            shaderSwitcher.SwitchToRainShader();
        }
        else
        {
            shaderSwitcher.SwitchToSnowShader();
        }
    }
}
