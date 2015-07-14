// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassY : MonoBehaviour
{

    private Color ClassYcolor = new Vector4(0.95f, 0.17f, 0.48f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassYcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();

    }
    
    // Use this for initialization
    void Start()
    {
        Description = "Dark purple in colour, Y-class brown dwarfs have no methane, and are likewise too low mass to prevent the Pulse Dragon Phenomenon. They are so cool they may even have " +
            "water clouds in their atmospheres. They may be very depleted in metals.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class Y";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 4;
        
        TheBaseSpectralClass.Temperature = Random.Range(1, 700) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.005f, 0.02f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.1f, 0.2f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.000001f, 0.00001f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0f;
        
        TheBaseSpectralClass.PlanetaryBodies = 14; // only moons
        TheBaseSpectralClass.BiosphereModifier = -4;
        
        TheBaseSpectralClass.VegetationColor = "Black";
        TheBaseSpectralClass.SkyColor = "Purplish-red";

        TheBaseSpectralClass.PlentifulResources.Add("Helium");
        TheBaseSpectralClass.PlentifulResources.Add("Hydrogen");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Cool Dark Brown Star");
        TheBaseSpectralClass.Aspects.Add("X-Ray Flares");

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
