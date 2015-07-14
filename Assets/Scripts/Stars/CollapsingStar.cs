// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CollapsingStar : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().AllowPulse = true;
        this.gameObject.GetComponent<SgtCustomStarfield>().TimeScale = 500f;

        Description =   "A star collapsing under its own gravity at the end of its life, blowing off its outer envelope over tens of thousands of years to form a planetary nebula (page 363), ending " +
                        "in a white dwarf. Massive collapsing stars may become black holes (page 364). They may be very hot, with varying luminosities and odd atmospheres of little hydrogen, but " +
                        "with helium, carbon, and oxygen. Some may have reignited helium fusion.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Collapsing Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = -4;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;
        
        TheBaseSpectralClass.HZoneDistance_SC_Min = 0f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 0f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 0f;
        TheBaseStellarType.HZoneDistance_ST_Mod = 0.75f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 0.75f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = -2;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Carbons");
        TheBaseStellarType.PlentifulResources.Add("Dispersed Silicates");
        TheBaseStellarType.PlentifulResources.Add("Organics");
        TheBaseStellarType.PlentifulResources.Add("Zanthrium Ore");
        TheBaseStellarType.ScarceResources.Add("Water");
        TheBaseStellarType.Aspects.Add("Gravitational Anomalies");
        TheBaseStellarType.Aspects.Add("Stellar Flare Hazards");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
