using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
//This code is not working due to terrain not updating live within the UI Toolkit without a on/off toggle.
namespace WeatherToolkit
{

    public class TerrainToolkitScript : EditorWindow
    {
        [SerializeField] private VisualTreeAsset TerrainEditor;
        public TerrainGenerator terrainGenerator;
        // public TerrainToolkit TerrainToolkitScript;
        private SliderInt _TerrainScale;
        private FloatField _Scale;



        [MenuItem("Tools/Terrain Editor")]
        public static void ShowEditor()
        {
            var window = GetWindow<TerrainToolkitScript>();
            window.titleContent = new GUIContent("Terrain Editor");
        }

        private void CreateGUI()
        {
            TerrainEditor.CloneTree(rootVisualElement);
            UiFields();

        }

        private void UiFields()
        {
            _Scale = rootVisualElement.Q<FloatField>("Scale");
            _Scale.RegisterValueChangedCallback(evt => Scale(evt.newValue));

            _TerrainScale = rootVisualElement.Q<SliderInt>("TerrainScale");
            _TerrainScale.RegisterValueChangedCallback(evt => TerrainScale(evt.newValue));




        }

        private void TerrainScale(int value)
        {

            terrainGenerator.terrainSize = value;
            /*            int intValue = Mathf.RoundToInt(value);

                        terrainGenerator.terrainSize = intValue;*/
        }


        private void Scale(float value)
        {

            terrainGenerator.scale = value;
            /*            int intValue = Mathf.RoundToInt(value);

                        terrainGenerator.terrainSize = intValue;*/
        }

        private void OnGUI()
        {
            terrainGenerator = FindObjectOfType<TerrainGenerator>();

        }
    }
}