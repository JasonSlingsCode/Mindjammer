// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DarkMatterStar : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 13.2f; // 4 AU

        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.r = this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.r * .1f;
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.g = this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.g * .1f;
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.b = this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.b * .1f;

        Description =   "Also known as a dark star, a dark matter star is an extremely rare survivor from the early universe, a huge stellar body up to 2000 AU in diameter comprising an enormous " +
                        "cloud of hydrogen and helium at a temperature too low for emitted radiation to be visible to the naked eye. Dark stars exist in cold clouds of molecular hydrogen gas, " +
                        "and emit gamma rays, neutrinos, and anti-matter.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Dark Matter Star";
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
        TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = 4;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Antimatter");
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.Aspects.Add("Invisibly Cool Anti-matter Hazard");
        TheBaseStellarType.Aspects.Add("Relic From the Early Universe");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
