// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassC : MonoBehaviour
{

    private Color ClassCcolor = new Vector4(0.86f, 0f, 0f, 1f);
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassCcolor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    
    void Start()
    {
        Description = "C-class stars are almost all red giants near the end of their lives, with high levels of carbon in their atmospheres; they otherwise equate to K-class stars. " +
            "A rare few are main sequence stars. Many are pulsating variables (page 364).";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class C";
        TheBaseSpectralClass.SpectralClassDescription = Description;
        
        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 4;
        
        TheBaseSpectralClass.Temperature = Random.Range(1900, 5001) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.1f, 1f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.1f, 1.2f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.1f, 1.5f) * 100) / 100;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0.19f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 1.2f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0.16f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 1.3f;
        
        TheBaseSpectralClass.PlanetaryBodies = 0; // only carbon planets
        TheBaseSpectralClass.BiosphereModifier = 0;
        
        TheBaseSpectralClass.VegetationColor = "Dark purplish to black";
        TheBaseSpectralClass.SkyColor = "Sooty orange-red";

        TheBaseSpectralClass.PlentifulResources.Add("Carbon");
        TheBaseSpectralClass.PlentifulResources.Add("Carbon Compounds");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Giant Ruby-red Carbon Star");
        TheBaseSpectralClass.Aspects.Add("Clouds of Carbon");
        TheBaseSpectralClass.Aspects.Add("Huge Ancient Sooty Star");

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
