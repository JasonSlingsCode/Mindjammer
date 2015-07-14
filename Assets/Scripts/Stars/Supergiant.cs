// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Supergiant : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    private BaseSpectralClass TheBaseSpectralClass;
    
    public string Description;
    public string GiantSubtitle;
    public string GiantSubtitleDescription;
    
    private List <string> PlentifulResources;
    private List <string> ScarceResources;
    
    private int PlanetNumberMod = -4;
    private int BiosphereMod = 0;
    private int HabitabilityMod = 0;
    
    private Text ThisTooltip;
    
    void Awake()
    {
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseStellarType = this.gameObject.GetComponent<BaseStellarType>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
        
        PlentifulResources = new List<string>();
        ScarceResources = new List<string>();
    }

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 4.0f; // 1.2 AU
        Description =   "Supergiants are rare, short-lived, and very bright luminosity class I stars, a stage in a star’s lifespan after the main sequence and giant star (page 361) stages. They can " +
                        "be any spectral class, and are among the most massive and luminous stars, with masses of at least 8-10 solar masses, luminosities from 10,000 to more than a million, and radii " +
                        "from 30-500 and even up to 1500 in the case of red supergiants like Antares. Blue O-class supergiants are very young stars, while red M-class supergiants are very old. They " +
                        "fuse heavier elements in their cores, and often undergo mass loss; some may even be variable stars. Supergiants eventually explode as supernovae. The largest supergiants are " +
                        "known as hypergiants, and are especially unstable.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;

        TheBaseStar.MassInSols = TheBaseSpectralClass.Mass * Random.Range(2, 9);
        TheBaseStar.RadiusInSols = TheBaseSpectralClass.Radius * Random.Range(500, 551);
        TheBaseStar.LuminosityInSols = TheBaseSpectralClass.Luminosity * Random.Range(3000, 50001);

        if (GiantSubtitle == "Red")
        {
            TheBaseStellarType.StellarTypeName = "Red Supergiant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes K, M, S, and C, the cooler red giants are from 20-100 solar diameters, with moderate mass (0.3 - 8.0), decent luminosity " +
                "(100 to several hundred), and relatively long stable lives. They’re the most common giant stars.";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;
            
            TheBaseStellarType.PlanetaryBodies = -4;
            TheBaseStellarType.BiosphereModifier = 2;
            TheBaseStellarType.HabitabilityModifier = 2;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 9.5f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 34.0f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 50f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 70f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1.25f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1.25f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = 3;
            TheBaseStellarType.Age_Max = 4;
            
            TheBaseStellarType.Aspects.Add("Immense Red Supergiant With Blasted Outer Worlds");
            TheBaseStellarType.Aspects.Add("Strange Life Evolved Anew in the Outer Solar System");
        }
        if (GiantSubtitle == "Yellow")
        {
            TheBaseStellarType.StellarTypeName = "Yellow Supergiant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes G, F, and some A, yellow giants are less common than red, and are variable and often unstable stars, some with periods less " +
                "than a day.";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;
            
            TheBaseStellarType.PlanetaryBodies = -4;
            TheBaseStellarType.BiosphereModifier = -1;
            TheBaseStellarType.HabitabilityModifier = -1;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 9.5f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 34.0f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 50f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 70f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1.25f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1.25f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = 2;
            TheBaseStellarType.Age_Max = 4;
            
            TheBaseStellarType.Aspects.Add("Massive Rapidly Variable Yellow Star");
        }
        if (GiantSubtitle == "Blue")
        {
            TheBaseStellarType.StellarTypeName = "Blue Supergiant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes O, B, and some A, these are very hot bright giant stars (5 to 10 solar diameters, 10,000K, and from 10 to 100,000 solar " +
                "luminosities), varying a great deal in mass (from 2 to 50+ solar masses).";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;
            
            TheBaseStellarType.PlanetaryBodies = -4;
            TheBaseStellarType.BiosphereModifier = -4;
            TheBaseStellarType.HabitabilityModifier = -2;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 3f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 433f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 3.5f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 1300f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1.25f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1.25f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = -2;
            TheBaseStellarType.Age_Max = -1;
            
            TheBaseStellarType.Aspects.Add("About to Go Supernova");
            TheBaseStellarType.Aspects.Add("Huge Star As Big As the Solar System");
        }

        TheBaseStellarType.Aspects.Add("No Time for Life to Evolve");
        TheBaseStellarType.Aspects.Add("Gigantic Rapidly Burning Bright Young Star");
        TheBaseStellarType.Aspects.Add("Radiation Hazard");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = GiantSubtitle;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
