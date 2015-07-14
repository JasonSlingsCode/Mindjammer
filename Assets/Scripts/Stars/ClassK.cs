// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassK : MonoBehaviour
{

    private Color ClassKcolor = new Vector4(1f, 0.76f, 0.42f, 1f);
    public string Description;
    private Text ThisTooltip;
    private BaseStar TheBaseStar;
    private BaseSpectralClass TheBaseSpectralClass;

    private float HZoneOrbitalDistance;
    private float HZoneOrbitalPeriod;

    private string[] PlentifulResources;
    private string[] ScarceResources;
    
    void Awake()
    {
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassKcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    // Use this for initialization
    void Start()
    {
        Description = "Orange stars slightly cooler than Old Earth’s sun, they are more common than G-class stars. They have longer lifespans, and are very favourable environments for " +
            "planets with evolved biospheres.";
        
        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class K";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 2;
        
        TheBaseSpectralClass.Temperature = Random.Range(3700, 5201) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.5f, 0.8f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.7f, 1f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.1f, 0.6f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0.23f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0.60f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0.16f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0.50f;
        
        TheBaseSpectralClass.PlanetaryBodies = 3;
        TheBaseSpectralClass.BiosphereModifier = 1;
        
        TheBaseSpectralClass.VegetationColor = "Red, yellow, violet, green";
        TheBaseSpectralClass.SkyColor = "Very pale blue";

        TheBaseSpectralClass.PlentifulResources.Add("Manganese");
        TheBaseSpectralClass.PlentifulResources.Add("Silicon");
        TheBaseSpectralClass.PlentifulResources.Add("Titanium Oxide");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Warm Orange Star");
        TheBaseSpectralClass.Aspects.Add("Ancient Evolved Biospheres");
        TheBaseSpectralClass.Aspects.Add("Somehow Feels Like Evening");

        // add variables to class TheBaseStar for calculation
        TheBaseStar.SpectralClass = TheBaseSpectralClass.SpectralClassName;
        TheBaseStar.SpectralClassDescription = Description;
        TheBaseStar.TemperatureInCelsius = TheBaseSpectralClass.Temperature;
        TheBaseStar.MassInSols = TheBaseSpectralClass.Mass;
        TheBaseStar.RadiusInSols = TheBaseSpectralClass.Radius;
        TheBaseStar.LuminosityInSols = TheBaseSpectralClass.Luminosity;
        TheBaseStar.HabitableZonePeriod = HZoneOrbitalPeriod;
        TheBaseStar.HabitableZoneDistance = HZoneOrbitalDistance;
        TheBaseStar.VegetationColor = TheBaseSpectralClass.VegetationColor;
        TheBaseStar.SkyColor = TheBaseSpectralClass.SkyColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
