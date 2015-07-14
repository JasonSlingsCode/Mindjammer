// Script by Jason Miller
// psyaxismundi@gmail.com
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PreMainSequence : MonoBehaviour
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
        Description = "Pre-main sequence stars are larger and less dense than main sequence stars, midway between a protostar and a main sequence star. They include T-Tauri and FU Orionis stars, " +
            "and have dense accretion disks. They’re heated by gravitational contraction rather than hydrogen burning.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Pre-Main Sequence Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = -4;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;

        TheBaseStellarType.HZoneDistance_ST_Mod = 1.25f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1.25f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = -4;
        TheBaseStellarType.Age_Max = -3;
        TheBaseStellarType.PlentifulResources.Add("Carbon");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.PlentifulResources.Add("Silicates");
        TheBaseStellarType.Aspects.Add("Dense Accretion Disk");
        TheBaseStellarType.Aspects.Add("Getting Hotter and Smaller");
        TheBaseStellarType.Aspects.Add("Rich in Hydrogen");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
