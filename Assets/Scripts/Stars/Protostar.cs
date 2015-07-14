using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Protostar : MonoBehaviour
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
        Description =   "A massive pre-stellar object formed by contraction of gases in a giant molecular cloud (page 362), and a short-lasting early stage in stellar formation, ending in a pre-main " +
                        "sequence star (page 363). Beginning from about 1% of its final mass, it heats up as it increases in size, bathed in microwaves and infrared, until fusion begins and the stellar " +
                        "wind begins to blow. Some protostars are also eruptive variables (page 361).";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "Protostar";
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
        TheBaseStellarType.Age_Max = -4;
        TheBaseStellarType.PlentifulResources.Add("Carbon Oxides");
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.PlentifulResources.Add("Metals");
        TheBaseStellarType.PlentifulResources.Add("Silicate Dust");
        TheBaseStellarType.Aspects.Add("Microwave Radiation Hazard");
        TheBaseStellarType.Aspects.Add("The T-Tauri Wind Is About to Blow...");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
