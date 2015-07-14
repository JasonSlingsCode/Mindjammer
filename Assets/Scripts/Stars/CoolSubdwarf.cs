// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoolSubdwarf : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    
    public string Description;

    private List <string> PlentifulResources;
    private List <string> ScarceResources;
    
    private int PlanetNumberMod = -2;
    private int BiosphereMod = 0;
    private int HabitabilityMod = 0;
    
    private Text ThisTooltip;

    void Awake()
    {
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseStellarType = this.gameObject.GetComponent<BaseStellarType>();

        PlentifulResources = new List<string>();
        ScarceResources = new List<string>();
    }
    // Use this for initialization
    void Start()
    {
        Description =   "One of the two subdwarf types making up luminosity class VI stars, cool subdwarfs have spectral classes G to M, and fuse hydrogen in their cores like main sequence stars. " +
                        "They’re less luminous than main sequence stars, as they lack elements heavier than helium; they also emit more ultraviolet. They’re more common in the halo of stars above " +
                        "and below the galactic plane.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;

        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Cool Subdwarf Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;

        TheBaseStellarType.PlanetaryBodies = -2;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;
        TheBaseStellarType.OnlyGasGiants = true;

        TheBaseStellarType.HZoneDistance_ST_Mod = 0.75f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 0.75f;

        // send variables to TheBaseStellarType
        TheBaseStellarType.Age_Min = -4;
        TheBaseStellarType.Age_Max = 4;
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.Aspects.Add("Dim Star Poor in Resources");
        TheBaseStellarType.Aspects.Add("Gas Giant Planets Only");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
