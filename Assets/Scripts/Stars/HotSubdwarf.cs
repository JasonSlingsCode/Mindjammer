// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HotSubdwarf : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    private BaseSpectralClass TheBaseSpectralClass;
    
    public string Description;
    
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
        Description =   "One of the two subdwarf types making up luminosity class VI stars, hot subdwarfs have spectral classes O and B, and are a late stage in certain red giant lifespans which " +
                        "have lost their outer hydrogen layers. Often occurring in binary systems, B-class subdwarfs are more luminous than white dwarfs, and comprise a significant proportion of " +
                        "older star populations. Some are variable stars. They are roughly 0.5 solar masses, with a luminosity of 10 to 100.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Hot Subdwarf Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = -4;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;

        TheBaseSpectralClass.HZoneDistance_SC_Min = 3.0f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 13.0f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 7.0f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 66.0f;
        TheBaseStellarType.HZoneDistance_ST_Mod = 1.0f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1.0f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = 2;
        TheBaseSpectralClass.Age_Min = 2;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.ScarceResources.Add("Hydrogen");
        TheBaseStellarType.Aspects.Add("Common Faint Blue Stars");
        TheBaseStellarType.Aspects.Add("No Planets");
        TheBaseStellarType.Aspects.Add("Stellar Flare Hazard");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
