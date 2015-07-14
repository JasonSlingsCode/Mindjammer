// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassS : MonoBehaviour
{

    private Color ClassScolor = new Vector4(1f, 0.40f, 0.29f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassScolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    // Use this for initialization
    void Start()
    {
        Description = "Also known as zirconium stars, S-class stars are giant stars midway between M-class and C-class stars; many are pulsating variables (page 364) with long periods. " +
            "They’re otherwise similar to M-class stars.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class S";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 4;
        
        TheBaseSpectralClass.Temperature = Random.Range(2000, 3501) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.8f, 8f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.01f, 0.1f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.1f, 0.5f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0.19f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0.23f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0.16f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0.26f;
        
        TheBaseSpectralClass.PlanetaryBodies = -4;
        TheBaseSpectralClass.BiosphereModifier = 0;
        
        TheBaseSpectralClass.VegetationColor = "Deep red, purple-black";
        TheBaseSpectralClass.SkyColor = "Sooty orange";

        TheBaseSpectralClass.PlentifulResources.Add("Carbon");
        TheBaseSpectralClass.PlentifulResources.Add("Lithium");
        TheBaseSpectralClass.PlentifulResources.Add("Technetium");
        TheBaseSpectralClass.PlentifulResources.Add("Zirconium Monoxide");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Cool Carbon-Rich Red Giant Star");
        TheBaseSpectralClass.Aspects.Add("Carbon-Rich Giant Star");
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
