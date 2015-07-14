// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EruptiveVariable : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    private BaseSpectralClass TheBaseSpectralClass;
    
    public string Description;
    
    private List <string> PlentifulResources;
    private List <string> ScarceResources;
    
    private int PlanetNumberMod = -2;
    private int BiosphereMod = -4;
    private int HabitabilityMod = -4;
    
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


        Description =   "Eruptive variable stars are otherwise normal stars (select a spectral class) which periodically increase or decrease in brightness, often by thousands of times, accompanied by " +
                        "stellar flares. There are many different types, some of which are extremely hazardous; some erupt at regular intervals of a few hours; others may go centuries without activity.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Eruptive Variable Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = -2;
        TheBaseStellarType.BiosphereModifier = -4;
        TheBaseStellarType.HabitabilityModifier = -4;

        TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = -4;
        TheBaseStellarType.Age_Max = 4;

        TheBaseStellarType.Aspects.Add("Navigational Hazard");
        TheBaseStellarType.Aspects.Add("Ticking Stellar Flare Bomb");
        TheBaseStellarType.Aspects.Add("Blasted By Flare");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        int x = RollTheDice.RollFourDice();
        this.gameObject.GetComponent<SgtCustomStarfield>().TimeScale = Random.Range(0f, 100f) * x;
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].PulseSpeed = Mathf.PingPong(Time.fixedDeltaTime * Random.Range(0f, Mathf.PingPong(10f, -10f)), 1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].PulseRange = Random.Range(0.5f, 0.76f);
    }
}
