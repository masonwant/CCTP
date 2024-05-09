//using UnityEngine;

//public class WeatherController : MonoBehaviour
//{


//    [Header("Snow Settings")]
//    public bool toggleSnowSimulation = false;

//   // public GameObject snowParticles;
//    public float snowUpdateSpeed = 0.01f;
//    public float snowfallBuildUp = 0.01f;
//    public float maxSnowWeight = 50.0f;
//    public float durationofsnow = 10f;

//    public float snowMelt = 0.01f;
//    public float minSnowWeight = 0.0f;
//    [Space]
//    private SnowSimulator snowSimulator;
//   // public ParticleSystem snowParticleSystem;

//    void Start()
//    {
//      //  var mainModual = snowParticleSystem.main;
//      //  mainModual.duration = durationofsnow;
//      //  snowParticles = GameObject.FindGameObjectWithTag("SnowParticles");
//        snowSimulator = FindObjectOfType<SnowSimulator>();


//        ToggleSnowSimulation();
//    }

//    void Update()
//    {
//      //  snowParticleSystem = snowParticles.GetComponent<ParticleSystem>();

//        if (toggleSnowSimulation != snowSimulator.isSnowSimulationActive)
//        {
//            ToggleSnowSimulation();
//        }
//    }

//    private void ToggleSnowSimulation()
//    {
//        snowSimulator.isSnowSimulationActive = toggleSnowSimulation;
//        snowSimulator.SwitchOnSnowSimulation();
//    }
//}
