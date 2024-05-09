using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


namespace WeatherToolkit
{

    public class SnowToolkitScript : EditorWindow
    {
        [SerializeField] private VisualTreeAsset SnowToolkit;

        private Toggle _ToggleSnow;
        private Slider _SnowBuildUp;
        private Slider _SnowUpdateSpeed;
        private Slider _SnowMelt;
        private MinMaxSlider _SnowWeight;
        public SnowSimulator snowSimulator;

        [MenuItem("Tools/Snow Editor")]


        public static void ShowEditor()
        {
            var window = GetWindow<SnowToolkitScript>();
            window.titleContent = new GUIContent("Snow Editor");

        }

        private void CreateGUI()
        {
            SnowToolkit.CloneTree(rootVisualElement);
            UiFields();

        }

        private void UiFields()
        {
            _ToggleSnow = rootVisualElement.Q<Toggle>("ToggleSnow");
            _ToggleSnow.RegisterValueChangedCallback(evt => ToggleSnowSimulation(evt.newValue));

            _SnowBuildUp = rootVisualElement.Q<Slider>("SnowBuildUp");
            _SnowBuildUp.RegisterValueChangedCallback(evt => SnowBuildUp(evt.newValue));


            _SnowUpdateSpeed = rootVisualElement.Q<Slider>("SnowUpdateSpeed");
            _SnowUpdateSpeed.RegisterValueChangedCallback(evt => SnowUpdateSpeed(evt.newValue));

            _SnowMelt = rootVisualElement.Q<Slider>("SnowMelt");
            _SnowMelt.RegisterValueChangedCallback(evt => SnowMelt(evt.newValue));

            _SnowWeight = rootVisualElement.Q<MinMaxSlider>("SnowWeight");
            _SnowWeight.RegisterValueChangedCallback(evt => SnowWeightScale(evt.newValue));

        }

        private void ToggleSnowSimulation(bool isSnowActive)
        {
            if (snowSimulator != null)
            {
                snowSimulator.isSnowSimulationActive = isSnowActive;
            }
        }

        private void SnowBuildUp(float value)
        {
            snowSimulator.snowfallBuildUp = value;
        }

        private void SnowUpdateSpeed(float value)
        {
            snowSimulator.snowUpdateSpeed = value;
        }

        private void SnowMelt(float value)
        {
            snowSimulator.snowMelt = value;
        }

        private void SnowWeightScale(Vector2 value)
        {
            snowSimulator.minSnowWeight = value.x;
            snowSimulator.maxSnowWeight = value.y;
        }

        private void OnGUI()
        {
            snowSimulator = FindObjectOfType<SnowSimulator>();

        }

        private void Update()
        {

        }



    }

}