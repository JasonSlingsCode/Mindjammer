// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainSequenceStar : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    
    public string Description;
    
    private List <string> PlentifulResources;
    private List <string> ScarceResources;
    
    private int PlanetNumberMod = 0;
    private int BiosphereMod = 0;
    private int HabitabilityMod = 0;
    
    private Text ThisTooltip;
    
    void Awake()
    {
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseStellarType = this.gameObject.GetComponent<BaseStellarType>();
    }
    // Use this for initialization
    void Start()
    {
        Description =   "A star that’s fusing hydrogen atoms in its core to form helium; 90% of all stars " +
                        "are main sequence stars, varying from about 0.1 solar masses to up to 200. Also " + 
                        "known as luminosity class V stars, they range in size and temperature from bright " +
                        "and hot blue-white O- and B-class stars, through warm yellow G-class stars like " +
                        "Old Earth’s sun, to cool reddish M-class stars, the most common. Spectral " +
                        "classification determines the star’s age, the likelihood of it having planets, and " +
                        "so on. Planetary systems around main sequence stars are the most favourable for life " +
                        "as we know it. Other stages in a star’s life include white dwarf, giant, subgiant, " +
                        "and supergiant." +
                        "\nWhen you create a main sequence star, determine its spectral class (page 356); stellar " +
                        "object parameters can be found in “Star Spectral Classes” (page 365).";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Main Sequence Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = 0;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;
        TheBaseStellarType.Age_Min = 4;
        TheBaseStellarType.Age_Max = -4;

        TheBaseStellarType.HZoneDistance_ST_Mod = 1f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1f;
        
        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
