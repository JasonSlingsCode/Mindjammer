// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Subgiant : MonoBehaviour
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
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        TheBaseStellarType = this.gameObject.GetComponent<BaseStellarType>();
        
        PlentifulResources = new List<string>();
        ScarceResources = new List<string>();
    }

    // Use this for initialization
    void Start()
    {
        Description =   "Also known as a luminosity class IV star, subgiants are a stage in a star’s life which main sequence stars evolve into. Midway between main sequence stars and giant stars, " +
                        "hydrogen fusion in their cores is ceasing, causing their cores to contract and their outer shells to expand, eventually to become a giant star, although their spectral class " +
                        "hasn’t yet shifted. Subgiant stars are rich in resources, especially metals, and their planetary systems are often favourable to terrestrial-type life.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Subgiant Star";
        TheBaseStellarType.StellarTypeDescription = Description;
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
        
        TheBaseStellarType.PlanetaryBodies = 0;
        TheBaseStellarType.BiosphereModifier = 0;
        TheBaseStellarType.HabitabilityModifier = 0;

        TheBaseStellarType.Age_Min = 4;
        TheBaseStellarType.Age_Max = -4;
        TheBaseStellarType.AgeModifier++;
        TheBaseStellarType.HZoneDistance_ST_Mod = 1.25f;
        TheBaseStellarType.HZonePeriod_ST_Mod = 1.25f;
        
        // send variables to TheBaseStellarType
        TheBaseStellarType.Aspects.Add("Increasing in Size and Brightness");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
