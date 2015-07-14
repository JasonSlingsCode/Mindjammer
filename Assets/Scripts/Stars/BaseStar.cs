// Script by Jason Miller
// psyaxismundi@gmail.com
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseStar : MonoBehaviour
{
    // Base Stats

    private BaseStellarType TheBaseStellarType;
    private BaseSpectralClass TheBaseSpectralClass;
    private RollDice RollTheDice;
    [Header("Aspects")]
    public List<string> Aspects;
    [Header("Overview")]
    public string SpectralClass;
    public string SpectralClassDescription;
    public string StellarBodyType;
    public string StellarBodyTypeDescription;
    [Header("Age")]
    public string Age;
    public int AgeValue;
    private int StellarTypeAgeMin;
    private int StellarTypeAgeMax;
    private string[] Ages = new string[]
    {
        "Extremely Young",
        "Very Young",
        "Young",
        "Maturing",
        "Mature",
        "Aging",
        "Old",
        "Very Old",
        "Ancient"
    };
    [Header("Attributes")]
    public float TemperatureInCelsius;
    public float MassInSols;
    public float RadiusInSols;
    public float LuminosityInSols;
    [Header("Habitable Zone")]
    public float HabitableZoneDistance;
    public float HabitableZonePeriod;
    [Header("Planets")]
    public string PlanetarySystemType;
    private int PlanetaryBodiesValue;
    private string[] PlanetarySystemTypes = new string[]
    {
        "Accretion Disk",
        "None",
        "Planetary System",
        "Post Planetary System / Remnant"
    };
    public int MaxNumberOfPlanets;
    public int BiosphereModifier;
    public int HabitabilityModifier;
    public bool OnlyGasGiants = false;
    public string VegetationColor;
    public string SkyColor;
    public GameObject PlanetarySystemPrefab;
    [Header("Resources")]
    public List <string> PlentifulResources;
    public List <string> ScarceResources;

    // calculation variables


    /*
    public string MultipleStarSystems;
    public string StellarBodyDetermination;
    public int StellarBodyAge;
    */

    void Awake()
    {
        TheBaseStellarType = this.gameObject.GetComponent<BaseStellarType>();
        TheBaseSpectralClass = this.gameObject.GetComponent<BaseSpectralClass>();
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        Aspects = new List<string>();
        PlentifulResources = new List<string>();
        ScarceResources = new List<string>();
    }

    public int FindAge()
    {
        StellarTypeAgeMin = Mathf.Min(TheBaseStellarType.Age_Min, TheBaseSpectralClass.Age_Min);
        StellarTypeAgeMax = Mathf.Max(TheBaseStellarType.Age_Max, TheBaseSpectralClass.Age_Max);
        AgeValue = RollTheDice.RollFourDice();
        AgeValue = AgeValue + TheBaseStellarType.AgeModifier;
        if (AgeValue <= StellarTypeAgeMin)
            AgeValue = StellarTypeAgeMin;
        if (AgeValue >= StellarTypeAgeMax)
            AgeValue = StellarTypeAgeMax;
        switch (AgeValue)
        {
            case -4:
                Age = Ages [AgeValue + 4];
                break;
            case -3:
                Age = Ages [AgeValue + 4];
                break;
            case -2:
                Age = Ages [AgeValue + 4];
                break;
            case -1:
                Age = Ages [AgeValue + 4];
                break;
            case 0:
                Age = Ages [AgeValue + 4];
                break;
            case 1:
                Age = Ages [AgeValue + 4];
                break;
            case 2:
                Age = Ages [AgeValue + 4];
                break;
            case 3:
                Age = Ages [AgeValue + 4];
                break;
            case 4:
                Age = Ages [AgeValue + 4];
                break;
            default:
                break;
        }
        return AgeValue;
    }

    public float FindHabitableZoneDistance()
    {
        HabitableZoneDistance = Random.Range(TheBaseSpectralClass.HZoneDistance_SC_Min, TheBaseSpectralClass.HZoneDistance_SC_Max);
        HabitableZoneDistance = HabitableZoneDistance * TheBaseStellarType.HZoneDistance_ST_Mod;
        HabitableZoneDistance = Mathf.Round((HabitableZoneDistance) * 100) / 100;
        return HabitableZoneDistance;
    }

    public float FindHabitableZonePeriod()
    {
        HabitableZonePeriod = Random.Range(TheBaseSpectralClass.HZonePeriod_SC_Min, TheBaseSpectralClass.HZonePeriod_SC_Max);
        HabitableZonePeriod = HabitableZonePeriod * TheBaseStellarType.HZonePeriod_ST_Mod;
        HabitableZonePeriod = Mathf.Round((HabitableZonePeriod) * 100) / 100;
        return HabitableZonePeriod;
    }

    public string FindPlanetarySystemType()
    {
        int Roll = RollTheDice.RollFourDice() + AgeValue;
        if (Roll <= -2)
        {
            PlanetarySystemType = PlanetarySystemTypes [0];
        }
        if (Roll == -1)
        {
            PlanetarySystemType = PlanetarySystemTypes [1];
        }
        if (Roll >= 0)
        {
            PlanetarySystemType = PlanetarySystemTypes [2];
            FindNumberOfPlanets();
        }
        return PlanetarySystemType;
    }

    void FindNumberOfPlanets()
    {
        if (TheBaseStellarType.OnlyGasGiants == true)
            OnlyGasGiants = true;
        PlanetaryBodiesValue = TheBaseStellarType.PlanetaryBodies + TheBaseSpectralClass.PlanetaryBodies;
        int Roll = RollTheDice.RollFourDice() + PlanetaryBodiesValue;
        if (Roll <= -4)
        {
            PlanetarySystemType = PlanetarySystemTypes [1];
            MaxNumberOfPlanets = 0;
        }
        if (Roll > -4)
        {
            MaxNumberOfPlanets = Roll + 4;
        }
    }

    public int FindBiosphereModifier()
    {
        BiosphereModifier = TheBaseSpectralClass.BiosphereModifier + TheBaseStellarType.BiosphereModifier;
        return BiosphereModifier;
    }

    public int FindHabitabilityModifier()
    {
        HabitabilityModifier = TheBaseSpectralClass.HabitabilityModifier + TheBaseStellarType.HabitabilityModifier;
        return HabitabilityModifier;
    }

    public List<string> AddAspects()
    {
        Aspects.AddRange(TheBaseStellarType.Aspects);
        Aspects.AddRange(TheBaseSpectralClass.Aspects);
        Aspects.Sort();
        return Aspects;
    }

    public List<string> AddPlentifulResources()
    {
        PlentifulResources.AddRange(TheBaseStellarType.PlentifulResources);
        PlentifulResources.AddRange(TheBaseSpectralClass.PlentifulResources);
        return PlentifulResources;
    }

    public List<string> AddScarceResources()
    {
        ScarceResources.AddRange(TheBaseStellarType.ScarceResources);
        ScarceResources.AddRange(TheBaseSpectralClass.ScarceResources);
        return ScarceResources;
    }

    public int AddPlanetarySystems()
    {
        AddTheSystems();
        return MaxNumberOfPlanets;
    }

    void AddTheSystems()
    {
        for (int i = 0; i < MaxNumberOfPlanets; i++)
        {
            GameObject ThePlanetarySystem = Instantiate(PlanetarySystemPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            ThePlanetarySystem.transform.parent = this.gameObject.transform;
            ThePlanetarySystem.AddComponent<BasePlanetarySystem>();
            ThePlanetarySystem.name = "Planetary System " + (i + 1).ToString();
        }
    }
}
