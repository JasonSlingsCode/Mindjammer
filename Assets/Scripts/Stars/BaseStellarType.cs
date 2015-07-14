// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseStellarType : MonoBehaviour
{
    private BaseStar TheBaseStar;
    private BaseSpectralClass TheBaseSpectralClass;

    public List <string> Aspects;

    public string StellarTypeName;
    /*
    public enum SpectralClasses
    {
        ClassO,
        ClassB,
        ClassA,
        ClassF,
        ClassG,
        ClassK,
        ClassM,
        ClassS,
        ClassC,
        ClassL,
        ClassT,
        ClassY
    };
    public SpectralClasses SpectralClass;
    */

    public string StellarTypeDescription;
    public string StellarTypeDescriptionText;
    
    public int Age_Min = 4;                                     // game rating
    public int Age_Max = -4;                                     // game rating
    public int AgeModifier;                                 // game rating

    public string PlanetarySystemType;                     // selected planetary system type
    private string[] PlanetarySystemTypes = new string[]    // list of planetary system types
    {
        "Accretion Disk",
        "None",
        "Planetary System",
        "Post Planetary System / Remnant"
    };

    private float HZoneDistance_ST_Min;                      // in AU.
    private float HZoneDistance_ST_Max;                      // in AU.
    public float HZoneDistance_ST_Mod = 1f;
    private float HZonePeriod_ST_Min;                        // in Earth standard years.
    private float HZonePeriod_ST_Max;                        // in Earth standard years.
    public float HZonePeriod_ST_Mod = 1f;

    public int PlanetaryBodies;                             // game rating
    public bool OnlyGasGiants;                              // planets are only gas giants
    public int BiosphereModifier;                           // game rating
    public int HabitabilityModifier;                        // game rating

    public string VegetationColor;
    public string SkyColor;
    public List <string> PlentifulResources;
    public List <string> ScarceResources;

    void Awake()
    {
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
        PlentifulResources = new List<string>();
        ScarceResources = new List<string>();
        Aspects = new List<string>();
    }
}
