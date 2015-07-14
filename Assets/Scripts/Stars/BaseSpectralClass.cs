// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseSpectralClass : MonoBehaviour
{
    private BaseStar TheBaseStar;
    private BaseStellarType TheBaseStellarType;

    public List <string> Aspects;

    public string SpectralClassName;
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

    public string SpectralClassDescription;
    public string SpectralClassDescriptionText;

    public int Age_Min = -4;             // game rating
    public int Age_Max = 4;            // game rating
    public float Temperature;           // in celsius (Kelvin - 273 degrees).
    public float Mass;                  // in sols.
    public float Radius;                // in sols.
    public float Luminosity;            // in sols.
    public float HZoneDistance_SC_Min;  // in AU.
    public float HZoneDistance_SC_Max;  // in AU.
    public float HZonePeriod_SC_Min;    // in Earth standard years.
    public float HZonePeriod_SC_Max;    // in Earth standard years.

    public int PlanetaryBodies;         // game rating
    public int BiosphereModifier;       // game rating
    public int HabitabilityModifier;    // game rating

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
