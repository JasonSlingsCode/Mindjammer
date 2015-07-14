// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AsymptoticGiant : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 3.3f; // 1 AU
        this.gameObject.GetComponent<SgtCustomStarfield>().AllowPulse = true;

        Description =   "A low- to medium-mass G- to M-class star (0.6 to 10 solar masses), becoming an S- or C-class star late in its life. Having been through its red giant phase once, it swells " +
                        "again to 1 AU radius, shedding its mass in “thermal pulses”. Each takes a few hundred years to build, culminating in a massive “helium shell flash”, increasing its luminosity " +
                        "thousands of times before fading over a few years." +
                        "\nAsymptotic giants are surrounded by shells of ejected stellar material up to 30 LY radius, iron and silicon dust and heavier elements like carbon or oxygen. They’re a source " +
                        "of astrophysical masers (page 373), and often the site of Commonality research expeditions.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Asymptotic Giant";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = -4;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;

        TheBaseSpectralClass.HZoneDistance_SC_Min = 9.5f;
        TheBaseSpectralClass.HZoneDistance_SC_Max = 34.0f;
        TheBaseSpectralClass.HZonePeriod_SC_Min = 50f;
        TheBaseSpectralClass.HZonePeriod_SC_Max = 70f;
        TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = 3;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Carbon");
        TheBaseStellarType.PlentifulResources.Add("Iron");
        TheBaseStellarType.PlentifulResources.Add("Oxygen");
        TheBaseStellarType.PlentifulResources.Add("Silicon");
        TheBaseStellarType.Aspects.Add("Astrophysical Maser");
        TheBaseStellarType.Aspects.Add("Thermal Pulse");
        TheBaseStellarType.Aspects.Add("Blasted By Flash");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
