using UnityEngine;


//This was in place for other weather systems to switch bettween.
//It was setup to switch on space however further work was needed.
public class MaterialSwitcher : MonoBehaviour
{
    public Material[] materials; // Array of materials to switch between
    private Renderer objectRenderer;
    private int currentIndex = 0;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("Renderer component not found on the object.");
        }

        if (materials.Length == 0)
        {
            Debug.LogError("No materials assigned to the material array.");
        }

        // Set the initial material
        SwitchMaterial(currentIndex);
    }

    void Update()
    {
        // Example: Switch material on key press (you can change this to any input method)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchMaterial((currentIndex + 1) % materials.Length);
        }
    }

    void SwitchMaterial(int index)
    {
        if (index >= 0 && index < materials.Length)
        {
            objectRenderer.material = materials[index];
            currentIndex = index;
        }
        else
        {
            Debug.LogError("Invalid material index.");
        }
    }
}
