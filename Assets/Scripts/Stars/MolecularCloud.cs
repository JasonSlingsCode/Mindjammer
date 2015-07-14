// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MolecularCloud : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;
    private BaseSpectralClass TheBaseSpectralClass;
    
    public string Description;
    public string MolecularCloudSubtitle;
    public string MolecularCloudSubtitleDescription;
    
    private List <string> PlentifulResources;
    private List <string> ScarceResources;

    public string[] MolecularCloudTypes = new string[]
    {
        "Stellar Nursery",
        "Bok Globule",
        "Giant Molecular Cloud"
    };

    public string[] MolecularCloudTypeDescriptions = new string[]
    {
        "Stellar nurseries are dense regions of the interstellar medium, filled with hydrogen, carbon, and hydrocarbons, including amino acids and the building blocks of life. " +
        "Slower-than-light expeditions to molecular clouds have successfully filtered and processed this material for makepoint conversion." +
        "\nExotic life forms have been reported in stellar nurseries, although the Pulse Dragon Phenomenon has meant they have been difficult to study. They’re also navigational " +
        "nightmares — so thick sensors can’t penetrate, with cloud matter playing havoc with hull materials and ruining sensors, comms, and shielding.",

        "Bok Globules are dark dense clouds of molecular hydrogen, carbon oxides, helium, and silicate dust and gas found in H II Regions (page 361), in which stellar formation sometimes " +
        "takes place. Roughly a light year across, they mass up to 50 solar masses, and are among the coldest objects in the universe.",

        "Giant Molecular Clouds are vast molecular clouds of relatively high density, with over a million solar masses stretched up to 600 light years in diameter. They contain structures " +
        "of filaments, sheets, lumps, and cores, some of which are so dense they block light — the so-called “dark nebulas”. They’re the location of magnetised turbulence and star formation, " +
        "and astrophysical masers (see page 373)."
    };
    
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

        Description =   "Molecular clouds, also known as stellar nurseries, are dense regions of the interstellar medium, filled with hydrogen, carbon, and hydrocarbons, including amino acids and " +
                        "the building blocks of life. Slower-than-light expeditions to molecular clouds have successfully filtered and processed this material for makepoint conversion." +
                        "\nExotic life forms have been reported in molecular clouds, although the Pulse Dragon Phenomenon has meant they have been difficult to study. They’re also navigational " +
                        "nightmares — so thick sensors can’t penetrate, with cloud matter playing havoc with hull materials and ruining sensors, comms, and shielding.";

        TheBaseStellarType.StellarTypeDescriptionText = Description;
        ThisTooltip = this.gameObject.GetComponentInChildren<Text>();
        ThisTooltip.text = this.gameObject.name;
        
        // set variables by stellar type
        TheBaseStellarType.StellarTypeName = MolecularCloudSubtitle;
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
        TheBaseStellarType.PlentifulResources.Add("Carbon Oxides");
        TheBaseStellarType.PlentifulResources.Add("Helium");
        TheBaseStellarType.PlentifulResources.Add("Hydrogen");
        TheBaseStellarType.PlentifulResources.Add("Metals");
        TheBaseStellarType.PlentifulResources.Add("Silicate Dust");
        TheBaseStellarType.Aspects.Add("Gravity Trap");
        TheBaseStellarType.Aspects.Add("X-Ray Pulses");

        // send variables to class TheBaseStar for calculation
        TheBaseStar.StellarBodyType = TheBaseStellarType.StellarTypeName;
        TheBaseStar.StellarBodyTypeDescription = Description;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

