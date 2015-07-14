// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassG : MonoBehaviour
{

    private Color ClassGcolor = new Vector4(1f, 0.96f, 0.52f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassGcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    void Start()
    {
        Description = "Yellowish-white in colour, G-type stars remain in the main sequence for some 10 billion years, making them excellent candidates for evolved biospheres. " +
            "The most famous G-class star is Sol, Old Earth’s sun.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class G";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 1;
        
        TheBaseSpectralClass.Temperature = Random.Range(5200, 6001) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.8f, 1f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.9f, 1.2f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.6f, 1.5f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0.6f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 1.2f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0.5f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 1.3f;
        
        TheBaseSpectralClass.PlanetaryBodies = 2;
        TheBaseSpectralClass.BiosphereModifier = 0;
        
        TheBaseSpectralClass.VegetationColor = "Green, red, yellow";
        TheBaseSpectralClass.SkyColor = "Blue";

        TheBaseSpectralClass.PlentifulResources.Add("Calcium");
        TheBaseSpectralClass.PlentifulResources.Add("Other Metals");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Warm Yellow Star");
        TheBaseSpectralClass.Aspects.Add("Sunlight Feels Like Home");

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
