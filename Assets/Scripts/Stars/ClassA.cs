// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassA : MonoBehaviour
{

    private Color ClassAColor = new Vector4(0.99f, 0.96f, 0.87f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassAColor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    void Start()
    {
        Description = "White or bluish-white, A-class stars are less rare than O- and B-class stars. They’re young stars, several hundred million years, often with accretion disks and proto-planets " +
            "or planets. They may be too young for evolved biospheres, although some worlds make good terraforming candidates.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class M";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = -3;
        
        TheBaseSpectralClass.Temperature = Random.Range(7500, 10001) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(1.4f, 2f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(1.4f, 1.8f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(5f, 25f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 3.2f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 6f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 4.8f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 10f;
        
        TheBaseSpectralClass.PlanetaryBodies = -2;
        TheBaseSpectralClass.BiosphereModifier = -2;
        
        TheBaseSpectralClass.VegetationColor = "Bright autumnal to bluish-white";
        TheBaseSpectralClass.SkyColor = "Deep blue";
        
        TheBaseSpectralClass.PlentifulResources.Add("Calcium");
        TheBaseSpectralClass.PlentifulResources.Add("Hydrogen");
        TheBaseSpectralClass.PlentifulResources.Add("Iron");
        TheBaseSpectralClass.PlentifulResources.Add("Magnesium");
        TheBaseSpectralClass.PlentifulResources.Add("Silicon");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Hot White Star");
        TheBaseSpectralClass.Aspects.Add("Young White Star With Active Accretion Disk");

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
