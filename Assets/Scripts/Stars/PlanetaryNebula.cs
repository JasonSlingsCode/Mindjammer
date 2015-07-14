// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetaryNebula : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color = new Vector4(0.61f, 0.09f, 0.31f, 1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 3.3f; // 1 AU
        Description =   "An expanding glowing shell of hot ionised gas given off by collapsing stars, lasting a few tens of thousands of years. Roughly one light year across, temperatures close " +
                        "to the exposed core can reach 1 million degrees. The exposed core emits strong ultraviolet radiation. Ejected layers are rich in heavy elements and the products of " +
                        "nucleosynthesis (calcium, carbon, nitrogen, oxygen, etc).";

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
            TheBaseStellarType.Age_Min = -2;
            TheBaseStellarType.Age_Max = 4;
            TheBaseStellarType.PlentifulResources.Add("Calcium");
            TheBaseStellarType.PlentifulResources.Add("Carbon");
            TheBaseStellarType.PlentifulResources.Add("Heavy Elements");
            TheBaseStellarType.PlentifulResources.Add("Nitrogen");
        TheBaseStellarType.PlentifulResources.Add("Oxygen");
            TheBaseStellarType.Aspects.Add("Rich Nucleosynthesis Resource");
            TheBaseStellarType.Aspects.Add("UV Radiation Hazard");

            // send variables to class TheBaseStar for calculation
            TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
            TheBaseStar.StellarBodyTypeDescription = Description;
        }
        
        // Update is called once per frame
        void Update()
        {
            
        }
    }
