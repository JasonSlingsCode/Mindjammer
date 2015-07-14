// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassB : MonoBehaviour
{

    private Color ClassBColor = new Vector4(0.88f, 0.93f, 1f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassBColor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    void Start()
    {
        Description = "Deep blue-white stars, B-class stars burn fast and bright, with short lifespans of less than a billion years. They have dust disks hundreds of AU in radius, " +
            "beyond which massive and hot terrestrial planets (page 337) may form — although there’s very little time for biospheres to evolve." +
            "\nB-class stars are more metal-enriched than sunlike stars, and are excellent sources of heavier elements.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class B";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = -4;
        
        TheBaseSpectralClass.Temperature = Random.Range(10000, 33001) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(2f, 16f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(1.8f, 6.6f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(25f, 30000f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 6f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 200f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 10f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 750f;
        
        TheBaseSpectralClass.PlanetaryBodies = -4;
        TheBaseSpectralClass.BiosphereModifier = -3;
        
        TheBaseSpectralClass.VegetationColor = "Autumnal";
        TheBaseSpectralClass.SkyColor = "Purple-blue";

        TheBaseSpectralClass.PlentifulResources.Add("Helium");
        TheBaseSpectralClass.PlentifulResources.Add("Hydrogen");
        TheBaseSpectralClass.PlentifulResources.Add("Magnesium");
        TheBaseSpectralClass.PlentifulResources.Add("Silicon");
        TheBaseSpectralClass.PlentifulResources.Add("Other Metals");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Hot Blue-white Star");
        TheBaseSpectralClass.Aspects.Add("Far Orbit Terraforming Candidates");
        TheBaseSpectralClass.Aspects.Add("Hot Massive Supersun");

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
