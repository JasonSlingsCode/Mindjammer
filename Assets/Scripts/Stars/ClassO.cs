// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassO : MonoBehaviour
{

    private Color ClassOColor = new Vector4(0.66f, 0.78f, 1f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars[0].Color = ClassOColor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }

    // Use this for initialization
    void Start()
    {
        Description =   "Very hot blue stars emitting mostly in the ultraviolet, O-class stars are relatively rare, burning up their hydrogen in only a few tens of millions of years. " +
                        "Among the most massive stars, they’re surrounded by dust disks out to thousands of AU, inhibiting planet formation close to the star.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class O";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = -4;
        
        TheBaseSpectralClass.Temperature = Random.Range(33000, 49501) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(16f, 24f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(6.6f, 9.9f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(30000f, 45000f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 200f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 300f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 750f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 1125f;
        
        TheBaseSpectralClass.PlanetaryBodies = -6;
        TheBaseSpectralClass.BiosphereModifier = -4;
        
        TheBaseSpectralClass.VegetationColor = "Autumnal";
        TheBaseSpectralClass.SkyColor = "Deep purple-blue";

        TheBaseSpectralClass.PlentifulResources.Add("Carbon");
        TheBaseSpectralClass.PlentifulResources.Add("Helium");
        TheBaseSpectralClass.PlentifulResources.Add("Hydrogen");
        TheBaseSpectralClass.PlentifulResources.Add("Nitrogen");
        TheBaseSpectralClass.PlentifulResources.Add("Oxygen");
        TheBaseSpectralClass.PlentifulResources.Add("Silicon");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Hot Blue Star");
        TheBaseSpectralClass.Aspects.Add("Blazing Ultraviolet");
        TheBaseSpectralClass.Aspects.Add("Blue Star Burning Brief yet Bright");

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
