// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StellarBlackHole : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.1f;
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.r = Random.Range(0.0f,1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.g = Random.Range(0.0f,1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.b = Random.Range(0.0f,1f);

        Description =   "Formed by the collapse of very massive stars at the end of their lives, black holes continue to grow by absorbing mass and material. Although invisible, they are detected by " +
                        "their accretion disks and gravitational lensing effects." +
                        "\nBlack holes have enormous (theoretically infinite) gravities; objects may be caught in their fields and unable to escape. Objects approaching a black hole experience time " +
                        "dilation (page 375); those which stray too close appear to “freeze” to external viewers; it’s not known what happens to them subjectively, although some black holes may be dimensional anomalies (page 373).";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Stellar Black Hole";
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
        TheBaseStellarType.Age_Min = -4;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Carbons");
        TheBaseStellarType.PlentifulResources.Add("Dispersed Silicates");
        TheBaseStellarType.PlentifulResources.Add("Organics");
        TheBaseStellarType.PlentifulResources.Add("Zanthrium Ore");
        TheBaseStellarType.ScarceResources.Add("Water");
        TheBaseStellarType.Aspects.Add("Gravitational Anomaly");
        TheBaseStellarType.Aspects.Add("Membrane Anomaly");
        TheBaseStellarType.Aspects.Add("Time Dilation Anomaly");
        TheBaseStellarType.Aspects.Add("We Can't Pull Free!");
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
