// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HIIRegion : MonoBehaviour
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
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.r = Random.Range(0.1f,1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.g = Random.Range(0.1f,1f);
        this.gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Color.b = Random.Range(0.1f,1f);

        Description =   "An interstellar cloud of partially ionised gas up to several hundred light years in diameter in which star formation has recently occurred, often the location of O- and B- class " +
                        "stars (page 365). They have a characteristic red colour, and are mostly composed of hydrogen, about 10% helium, and trace heavier elements. The Orion Nebula, home of the Venu, is the most " +
                        "famous. With high temperatures, intense magnetic fields, and energetic electric fields, they pose navigational hazards. Stars within H II Regions are surrounded by spheres " +
                        "of ionised gas.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = "H II Region";
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
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.Aspects.Add("High Temperatures and Intense Magnetic Fields");
        TheBaseStellarType.Aspects.Add("Navigational Hazard");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
