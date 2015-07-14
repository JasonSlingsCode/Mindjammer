// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Giant : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 3.3f; // 1 AU
        Description = "Also called luminosity class III stars, giant stars are a stage in a star’s life which main sequence stars of sufficient mass eventually go through. " +
            "They’re larger (up to several hundred solar diameters) and more luminous (from 10 to several thousand solar luminosities) than main sequence stars (page 362) " +
            "of the same spectral class. If they have a planetary system, any inner system worlds will have been destroyed." +
            "\nGiant stars include bright giants, also known as luminosity class II stars, which straddle the boundary between giant and supergiant stars. They can be of any " +
            "spectral class from O to M. Stars larger and more luminous than giant stars are called supergiants (page 365).";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;

        TheBaseStar.RadiusInSols = TheBaseSpectralClass.Radius * Random.Range(400, 501);
        TheBaseStar.LuminosityInSols = TheBaseSpectralClass.Luminosity * Random.Range(100, 5001);

        if (GiantSubtitle == "Red")
        {
            TheBaseStellarType.StellarTypeName = "Red Giant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes K, M, S, and C, the cooler red giants are from 20-100 solar diameters, with moderate mass (0.3 - 8.0), decent luminosity " +
                "(100 to several hundred), and relatively long stable lives. They’re the most common giant stars.";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;

            TheBaseStellarType.PlanetaryBodies = 0;
            TheBaseStellarType.BiosphereModifier = 2;
            TheBaseStellarType.HabitabilityModifier = 2;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 9.5f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 34.0f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 50f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 70f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = 2;
            TheBaseStellarType.Age_Max = 4;

            TheBaseStellarType.Aspects.Add("Huge Red Giant With Blasted Inner Worlds");
            TheBaseStellarType.Aspects.Add("Strange Life Evolved Anew in the Outer Solar System");
        }
        if (GiantSubtitle == "Yellow")
        {
            TheBaseStellarType.StellarTypeName = "Yellow Giant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes G, F, and some A, yellow giants are less common than red, and are variable and often unstable stars, some with periods less " +
                "than a day.";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;

            TheBaseStellarType.PlanetaryBodies = 1;
            TheBaseStellarType.BiosphereModifier = -1;
            TheBaseStellarType.HabitabilityModifier = -1;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 9.5f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 34.0f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 50f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 70f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = 1;
            TheBaseStellarType.Age_Max = 4;

            TheBaseStellarType.Aspects.Add("Massive Rapidly Variable Yellow Star");
        }
        if (GiantSubtitle == "Blue")
        {
            TheBaseStellarType.StellarTypeName = "Blue Giant Star";
            GiantSubtitleDescription = "\n\nWith spectral classes O, B, and some A, these are very hot bright giant stars (5 to 10 solar diameters, 10,000K, and from 10 to 100,000 solar " +
                "luminosities), varying a great deal in mass (from 2 to 50+ solar masses).";
            Description = Description + GiantSubtitleDescription;
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;

            TheBaseStellarType.PlanetaryBodies = -2;
            TheBaseStellarType.BiosphereModifier = -4;
            TheBaseStellarType.HabitabilityModifier = -2;
            
            TheBaseSpectralClass.HZoneDistance_SC_Min = 3f;
            TheBaseSpectralClass.HZoneDistance_SC_Max = 433f;
            TheBaseSpectralClass.HZonePeriod_SC_Min = 3.5f;
            TheBaseSpectralClass.HZonePeriod_SC_Max = 1300f;
            TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
            TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
            
            // send variables to TheBaseStellarType
            TheBaseStellarType.Age_Min = -3;
            TheBaseStellarType.Age_Max = -2;

            TheBaseStellarType.Aspects.Add("No Time for Life to Evolve");
            TheBaseStellarType.Aspects.Add("Very Large Rapidly Burning Bright Young Star");
        }

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = GiantSubtitle;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
