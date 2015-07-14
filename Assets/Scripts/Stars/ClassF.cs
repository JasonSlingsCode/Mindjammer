// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassF : MonoBehaviour
{

    private Color ClassFcolor = new Vector4(0.97f, 0.88f, 0.66f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassFcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    void Start()
    {
        Description = "White in colour, F-class stars have respectable lifespans and are good candidates for planets with evolved biospheres.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class F";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = -1;
        
        TheBaseSpectralClass.Temperature = Random.Range(6000, 7501) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(1f, 1.4f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(1.2f, 1.4f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(1.5f, 5f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 1.2f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 3.2f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 1.3f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 4.8f;
        
        TheBaseSpectralClass.PlanetaryBodies = 1;
        TheBaseSpectralClass.BiosphereModifier = -1;
        
        TheBaseSpectralClass.VegetationColor = "Blue, light green, white";
        TheBaseSpectralClass.SkyColor = "Deep blue";

        TheBaseSpectralClass.PlentifulResources.Add("Calcium");
        TheBaseSpectralClass.PlentifulResources.Add("Chromium");
        TheBaseSpectralClass.PlentifulResources.Add("Hydrogen");
        TheBaseSpectralClass.PlentifulResources.Add("Iron");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Warm Yellow-white Star");
        TheBaseSpectralClass.Aspects.Add("Blue Jungles With a Bright White Sun");

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
