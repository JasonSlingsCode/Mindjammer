// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClassM : MonoBehaviour
{

    private Color ClassMColor = new Vector4(1f, 0.40f, 0.29f, 1f);
    public string Description;
    private Text ThisTooltip;
    private BaseStar TheBaseStar;
    private BaseSpectralClass TheBaseSpectralClass;

    private List <string> PlentifulResources;
    private List <string> ScarceResources;

    void Awake()
    {
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = ClassMColor;
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
    }
    // Use this for initialization
    void Start()
    {
        Description = "The most common main sequence star, M-class stars are dim red, and also known as red dwarfs. They’re extremely long-lived (longer than the current lifespan of the universe), " +
            "with a high likelihood of evolved biospheres.";

        TheBaseSpectralClass.SpectralClassDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;

        // set variables by spectral class
        TheBaseSpectralClass.SpectralClassName = "Class M";
        TheBaseSpectralClass.SpectralClassDescription = Description;

        // class-specific variables
        TheBaseSpectralClass.Age_Min = -4;
        TheBaseSpectralClass.Age_Max = 4;

        TheBaseSpectralClass.Temperature = Random.Range(2000, 3701) - 273;
        TheBaseSpectralClass.Mass = Mathf.Round(Random.Range(0.1f, 0.5f) * 100) / 100;
        TheBaseSpectralClass.Radius = Mathf.Round(Random.Range(0.01f, 0.7f) * 100) / 100;
        TheBaseSpectralClass.Luminosity = Mathf.Round(Random.Range(0.01f, 0.1f) * 100) / 100;

        TheBaseSpectralClass.HZoneDistance_SC_Min = 0.19f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0.23f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0.16f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0.26f;

        TheBaseSpectralClass.PlanetaryBodies = 4;
        TheBaseSpectralClass.BiosphereModifier = 2;

        TheBaseSpectralClass.VegetationColor = "Dark purplish to black, deep red";
        TheBaseSpectralClass.SkyColor = "Yellowish-orange to white";

        TheBaseSpectralClass.PlentifulResources.Add("Oxides");
        TheBaseSpectralClass.ScarceResources.Add("Everything else");

        TheBaseSpectralClass.Aspects.Add("Cool Red Star");
        TheBaseSpectralClass.Aspects.Add("Ancient Highly-Evolved Star System");

        // add variables to class TheBaseStar for calculation
        TheBaseStar.SpectralClass = TheBaseSpectralClass.SpectralClassName;
        TheBaseStar.SpectralClassDescription = Description;
        TheBaseStar.TemperatureInCelsius = TheBaseSpectralClass.Temperature;
        TheBaseStar.MassInSols = TheBaseSpectralClass.Mass;
        TheBaseStar.RadiusInSols = TheBaseSpectralClass.Radius;
        TheBaseStar.LuminosityInSols = TheBaseSpectralClass.Luminosity;
        TheBaseStar.VegetationColor = TheBaseSpectralClass.VegetationColor;
        TheBaseStar.SkyColor = TheBaseSpectralClass.SkyColor;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
