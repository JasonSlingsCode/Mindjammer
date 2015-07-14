// Script by Jason Miller
// psyaxismundi@gmail.com
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasePlanetarySystem : MonoBehaviour
{
    private RollDice RollTheDice;
    private int TheSliderSetting;
    private BaseStar TheBaseStar;
    [Header("Aspects")]
    public List<string>
        Aspects;
    [Header("Planetary Type")]
    public string
        PlanetaryType;
    public int PlanetaryTypeValue;
    private string[] InnerPlanetaryTypes = new string[]
    {
        "Accretion Disk",
        "Accretion Disk",
        "Protoplanet",
        "Protoplanet",
        "Gas Giant",
        "Inferno",
        "Terrestrial Planet",
        "Desert World",
        "Terrestrial Planet",
        "Inferno",
        "Terrestrial Planet",
        "Garden World, Marginal",
        "Desert World",
        "Terrestrial Planet",
        "Gas Giant",
        "Chthonian Planet",
        "Carbon Planet"
    };
    private string[] HabitablePlanetaryTypes = new string[]
    {
        "Accretion Disk",
        "Accretion Disk",
        "Protoplanet",
        "Protoplanet",
        "Desert World",
        "Ocean World",
        "Terrestrial Planet",
        "Garden World, Marginal",
        "Terrestrial Planet",
        "Garden World, Standard",
        "Terrestrial Planet",
        "Garden World, Superior",
        "Super Earth",
        "Gas Giant",
        "Garden World, Inferior",
        "Garden World, Marginal",
        "Post-Garden World"
    };
    private string[] OuterPlanetaryTypes = new string[]
    {
        "Accretion Disk",
        "Accretion Disk",
        "Proto-Gas Giant",
        "Proto-Gas Giant",
        "Iceball",
        "Gas Giant",
        "Ice Giant",
        "Dwarf Planet",
        "Gas Giant",
        "Gas Giant",
        "Ice Giant",
        "Asteroid Belt",
        "Garden World, Marginal",
        "Rogue Planet",
        "Helium Planet",
        "Carbon Planet",
        "Carbon Planet"
    };
    private bool PlanetaryTypeDetermined = false;
    public string PlanetaryDescription;
    [Header("Planetary Age")]
    public string
        Age;
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
    public int AgeValue;
    [Header("Orbit")]
    public string
        Orbit;
    public float OrbitDistanceFromPrimary;
    public int OrbitValue;
    private string[] Orbits = new string[]
    {
        "Highly Eccentric",
        "Extreme Inner",
        "Inner",
        "Inner Habitable Zone",
        "Habitable Zone",
        "Outer Habitable Zone",
        "Outer",
        "Outer",
        "Extreme Outer"
    };
    [Header("Size")]
    public string
        Size;
    public int SizeValue;
    public float DiameterInKilometers;
    private float EarthDiameters;
    private string[] Sizes = new string[]
    {
        "Planetesimal",
        "Planetoid",
        "Small",
        "Small Standard",
        "Standard",
        "Large Standard",
        "Large",
        "Very Large",
        "Giant"
    };
    [Header("Density")]
    public string
        Density;
    public int DensityValue;
    private int DensityModifier;
    public float EarthDensities;
    private string[] Densities = new string[]
    {
        "Extremely Low",
        "Very Low",
        "Low",
        "Low Standard",
        "Standard",
        "High Standard",
        "Dense",
        "Very Dense",
        "Extremely Dense",
        "Exotic"
    };
    [HideInInspector]
    public int
        DensityMin;
    [HideInInspector]
    public int
        DensityMax;
    [Header("Surface Gravity")]
    public string
        SurfaceGravity;
    public int SurfaceGravityValue;
    private int GravityModifier;
    public float EarthGravities;
    private string[] Gravities = new string[]
    {
        "Microgravity",
        "Very Low",
        "Low",
        "Low Standard",
        "Standard",
        "High Standard",
        "High",
        "Very High",
        "Extremely High",
        "Exotic"
    };
    [HideInInspector]
    public int
        GravityMin;
    [HideInInspector]
    public int
        GravityMax;
    [Header("Year Length (in Standard Earth Days)")]
    public float
        YearLength;
    [Header("Day Length (in Standard Earth Days)")]
    public string
        DayLength;
    public int DayLengthValue;
    public float LengthInDays;
    private int DayLengthModifier;
    [HideInInspector]
    public int
        DayLengthMin;
    [HideInInspector]
    public int
        DayLengthMax;
    private string[] DayLengths = new string[]
    {
        "Tidal Lock",
        "Extremely Slow",
        "Very Slow",
        "Slow",
        "Reduced",
        "Standard",
        "Increased",
        "Rapid",
        "Very Rapid",
        "Extremely Rapid",
        "Extremely Rapid",
        "Extremely Rapid",
        "Extremely Rapid",
        "Extremely Rapid"
    };
    [Header("Atmospheric Pressure")]
    public string
        AtmosphericPressure;
    public int AtmosphericPressureValue;
    private int AtmosphericPressureModifier;
    [HideInInspector]
    public int
        AtmosphericPressureMin;
    [HideInInspector]
    public int
        AtmosphericPressureMax;
    private string[] Pressures = new string[]
    {
        "Trace",
        "Very Low",
        "Low",
        "Standard",
        "High",
        "Very High",
        "Hazardous",
        "Insidious"
    };
    [Header("Surface Temperature")]
    public string
        SurfaceTemperature;
    public int SurfaceTemperatureValue;
    private int TemperatureModifier;
    [HideInInspector]
    public int
        SurfaceTempMin;
    [HideInInspector]
    public int
        SurfaceTempMax;
    public float TemperatureInCelsius;
    private string[] Temperatures = new string[]
    {
        "Frozen",
        "Frigid",
        "Cold",
        "Cool",
        "Standard",
        "Warm",
        "Hot",
        "Furnace",
        "Inferno",
        "Inferno",
        "Inferno",
        "Chthonian"
    };
    [Header("Atmospheric Constitiuents & Surface Liquid Type")]
    public string
        AqueousPlanetType;
    private string[] AqueousPlanetTypes = new string[]
    {
        "Aqueous",
        "Non-Aqueous"
    };
    public string AtmosphericBreathability;
    private string[] Breathabilities = new string[]
    {
        "Unbreathable",
        "Breathable",
        "Tainted"
    };
    public string SurfaceLiquidExtent;
    public int SurfaceLiquidExtentValue;
    public float SurfaceLiquidPercentage;
    private int SurfaceLiquidModifier;
    private string[] LiquidExtents = new string[]
    {
        "None",
        "Trace",
        "Very Low",
        "Low",
        "Average",
        "High",
        "Very High",
        "Almost Total",
        "Oceanworld"
    };
    [HideInInspector]
    public int
        SurfaceLiquidMin;
    [HideInInspector]
    public int
        SurfaceLiquidMax;
    [Header("Seasonality")]
    public string
        Seasonality;
    public int SeasonalityValue;
    private int SeasonalityModifier;
    private string[] Seasonalities = new string[]
    {
        "No Seasonality",
        "Little Seasonality",
        "Very Low",
        "Low",
        "Low Standard",
        "Standard",
        "High Standard",
        "High",
        "Very High",
        "Extreme Seasonality",
        "Twin Climates"
    };
    [HideInInspector]
    public int
        SeasonalityMin;
    [HideInInspector]
    public int
        SeasonalityMax;
    [Header("Satellites")]
    public int
        Satellites;
    public List<string>
        SatelliteTypes;
    private int SatelliteModifier;
    private int MaxMoons;
    private int TheSatelliteType;
    [Header("Habitability")]
    public string
        Biosphere;
    public int BiosphereValue;
    [HideInInspector]
    public int
        BiosphereModifier;
    [HideInInspector]
    public int BiodiversityModifier;
    [HideInInspector]
    public int HabitabilityModifier;
    public string Habitability;
    public int HabitabilityValue;
    [HideInInspector]
    public int HabitabilityMin;
    [HideInInspector]
    public int HabitabilityMax;
    private string[] Habitabilities = new string[]
    {
        "Deadly",
        "Lethal",
        "Hostile",
        "Inimical",
        "Marginal",
        "Challenging",
        "Adequate",
        "Agreeable",
        "Benign"
    };
    [Header("Civilization Type")]
    public string
        CivilizationType;
    public int CivilizationTypeValue;
    private int CivTypeByPlanetTypeModifier;
    private string[] CivilizationTypes = new string[]
    {
        "Agri World",
        "Alien Civilization",
        "Balkanized World",
        "Closed World",
        "Commonality Civilization",
        "Commonality Hub",
        "Core World",
        "Core Worlds Hub",
        "Corporacy World",
        "Culture World",
        "Depot",
        "Failing World",
        "High Population World",
        "Holdout World",
        "Industrial World",
        "Interstellar Civilization",
        "Interstellar Hub",
        "Instrumentality Hub",
        "Prison Planet",
        "Quarantined World",
        "Regressed World",
        "Seed Colony",
        "Synthetic Colony",
        "United World"
    };

    void Awake()
    {
        Aspects = new List<string>();
        SatelliteTypes = new List<string>();
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = GetComponentInParent<BaseStar>();
        BiosphereModifier = TheBaseStar.BiosphereModifier;
        TheSliderSetting = Mathf.FloorToInt(GameObject.Find("Slider").GetComponent<SliderController>().TheValue);
    }
    // Use this for initialization
    void Start()
    {
        FindOrbit();
        FindPlanetaryType();
        // FindCivilizationType() gets called from within FindPlanetaryType()
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void FindOrbit()
    {
        OrbitValue = RollTheDice.RollFourDice();
        switch (OrbitValue)
        {
            case -4:                // Highly Eccentric
                Orbit = Orbits [0];
                for (int i = 1; i <= 2; i++)
                {
                    int HE_Orbit = RollTheDice.RollFourDice();
                    if (HE_Orbit == -4)
                        HE_Orbit = -3;
                    switch (HE_Orbit)
                    {
                        case -3:                // Extreme Inner
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.1f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.03f) * 100) / 100;
                            TemperatureModifier += 7;
                            break;
                        case -2:                // Inner
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.4f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.25f) * 100) / 100;
                            TemperatureModifier += 2;
                            break;
                        case -1:                // Inner Habitable Zone
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.7f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.6f) * 100) / 100;
                            TemperatureModifier++;
                            break;
                        case 0:                // Habitable Zone
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 1f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 1f) * 100) / 100;
                            TemperatureModifier++;
                            break;
                        case 1:                // Outer Habitable Zone
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 1.5f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 1.8f) * 100) / 100;
                            TemperatureModifier--;
                            break;
                        case 2:                // Outer
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 5f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 11f) * 100) / 100;
                            TemperatureModifier -= 2;
                            break;
                        case 3:                // Outer
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 10f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 31f) * 100) / 100;
                            TemperatureModifier -= 6;
                            break;
                        case 4:                // Extreme Outer
                            OrbitDistanceFromPrimary += Mathf.Round((TheBaseStar.HabitableZoneDistance * 40f) * 100) / 100;
                            YearLength += Mathf.Round((TheBaseStar.HabitableZonePeriod * 253f) * 100) / 100;
                            TemperatureModifier -= 8;
                            break;
                        default:
                            break;
                    }
                }
                YearLength = Mathf.Round((YearLength / 2) * 100) / 100;
                YearLength = YearLength * 364;
                BiosphereModifier--;
                break;
            case -3:                // Extreme Inner
                Orbit = Orbits [1];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.1f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.03f) * 100) / 100;
                YearLength = YearLength * 364;
                DensityModifier++;
                TemperatureModifier += 7;
                BiosphereModifier -= 3;
                break;
            case -2:                // Inner
                Orbit = Orbits [2];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.4f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.25f) * 100) / 100;
                YearLength = YearLength * 364;
                DensityModifier++;
                TemperatureModifier += 2;
                BiosphereModifier--;
                break;
            case -1:                // Inner Habitable Zone
                Orbit = Orbits [3];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 0.7f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 0.6f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier++;
                BiosphereModifier += 2;
                break;
            case 0:                // Habitable Zone
                Orbit = Orbits [4];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 1f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 1f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier++;
                BiosphereModifier += 3;
                break;
            case 1:                // Outer Habitable Zone
                Orbit = Orbits [5];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 1.5f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 1.8f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier--;
                BiosphereModifier += 2;
                break;
            case 2:                // Outer
                Orbit = Orbits [6];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 5f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 11f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier -= 2;
                BiosphereModifier--;
                break;
            case 3:                // Outer
                Orbit = Orbits [7];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 10f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 31f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier -= 6;
                BiosphereModifier -= 2;
                break;
            case 4:                // Extreme Outer
                Orbit = Orbits [8];
                OrbitDistanceFromPrimary = Mathf.Round((TheBaseStar.HabitableZoneDistance * 40f) * 100) / 100;
                YearLength = Mathf.Round((TheBaseStar.HabitableZonePeriod * 253f) * 100) / 100;
                YearLength = YearLength * 364;
                TemperatureModifier -= 8;
                BiosphereModifier -= 3;
                break;
            default:
                break;
        }
        FindYearLengthSeasonalityMod();
    }

    void FindYearLengthSeasonalityMod()
    {
        float x = YearLength / 364;
        if (x < 0.5f)
        {
            SeasonalityModifier -= 4;
        }
        if (x >= 0.5f && x < 0.8f)
        {
            SeasonalityModifier -= 2;
        }
        if (x >= 0.8f && x < 1f)
        {
            SeasonalityModifier --;
        }
        if (x >= 1f && x < 1.2f)
        {
            SeasonalityModifier -= 0;
        }
        if (x >= 1.2f && x < 5f)
        {
            SeasonalityModifier ++;
        }
        if (x >= 5f && x < 50f)
        {
            SeasonalityModifier += 2;
        }
        if (x >= 50f && x < 100f)
        {
            SeasonalityModifier += 4;
        }
        if (x > 100f)
        {
            SeasonalityModifier += 8;
        }
    }

    void FindPlanetaryType() // not including Eccentric Orbits
    {
        PlanetaryTypeValue = RollTheDice.RollFourDice() + TheBaseStar.AgeValue;
        if (Orbit == Orbits [1] || Orbit == Orbits [2])                             // if the planetary body lies in an INNER zone
        {
            switch (PlanetaryTypeValue)
            {
                case -8:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -7:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -6:    // Protoplanet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Protoplanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -5:    // Protoplanet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Protoplanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -4:    // Gas Giant
                    PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case -3:    // Inferno
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Inferno>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -2:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -1:    // Desert World
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<DesertWorld>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 0:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = false;
                    }
                    break;
                case 1:    // Inferno
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Inferno>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 2:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 3:    // Garden World, Marginal
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        CivTypeByPlanetTypeModifier = -2;
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldMarginal>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 4:    // Desert World
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<DesertWorld>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 5:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 6:    // Gas Giant
                    PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 7:    // Chthonian Planet
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<ChthonianPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 8:    // Carbon Planet
                    if (TheBaseStar.SpectralClass == "Class S" ||
                        TheBaseStar.SpectralClass == "Class C")
                    {
                        PlanetaryType = InnerPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<CarbonPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                default:
                    break;
            }
            if (PlanetaryTypeDetermined == false)
            {
                Invoke("FindPlanetaryType", 0.01f);
            }
        }
        if (Orbit == Orbits [3] || Orbit == Orbits [4] || Orbit == Orbits [5])      // if the planetary body lies in a HABITABLE zone
        {
            switch (PlanetaryTypeValue)
            {
                case -8:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -7:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -6:    // Protoplanet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Protoplanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -5:    // Protoplanet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<Protoplanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -4:    // Desert World
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<DesertWorld>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -3:    // Ocean World
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<OceanWorld>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -2:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -1:    // Garden World, Marginal
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        CivTypeByPlanetTypeModifier = -2;
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldMarginal>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 0:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 1:    // Garden World, Standard
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G")
                    {
                        CivTypeByPlanetTypeModifier = 2;
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldStandard>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 2:    // Terrestrial Planet
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<TerrestrialPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 3:    // Garden World, Superior
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G")
                    {
                        CivTypeByPlanetTypeModifier = 4;
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldSuperior>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 4:    // Super Earth
                    PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<SuperEarth>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 5:    // Gas Giant
                    PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 6:    // Garden World, Inferior
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        CivTypeByPlanetTypeModifier = 0;
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldInferior>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 7:    // Garden World, Marginal
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        CivTypeByPlanetTypeModifier = -2;
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldMarginal>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 8:    // Post-Garden World
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        PlanetaryType = HabitablePlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<PostGardenWorld>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                default:
                    break;
            }
            if (PlanetaryTypeDetermined == false)
            {
                Invoke("FindPlanetaryType", 0.01f);
            }
        }
        if (Orbit == Orbits [6] || Orbit == Orbits [7] || Orbit == Orbits [8])     // if the planetary body lies in a OUTER zone
        {
            switch (PlanetaryTypeValue)
            {
                case -8:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -7:    // Accretion Disk
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Protostar" ||
                        TheBaseStar.StellarBodyType == "Black Star" ||
                        TheBaseStar.StellarBodyType == "Electroweak Star" ||
                        TheBaseStar.StellarBodyType == "Stellar Black Hole" ||
                        TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<AccretionDisk>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -6:    // Proto-Gas Giant
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<ProtoGasGiant>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -5:    // Proto-Gas Giant
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.Age == "Very Young" ||
                        TheBaseStar.StellarBodyType == "Protostar")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<ProtoGasGiant>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case -4:    // Iceball
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<Iceball>();
                    PlanetaryTypeDetermined = true;
                    break;
                case -3:    // Gas Giant
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case -2:    // Ice Giant
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<IceGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case -1:    // Dwarf Planet
                    if (TheBaseStar.StellarBodyType == "Pre-Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Hot Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Cool Subdwarf Star" ||
                        TheBaseStar.StellarBodyType == "Substellar Object" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" ||
                        TheBaseStar.StellarBodyType == "Subgiant Star" ||
                        TheBaseStar.StellarBodyType == "Red Giant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Giant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Giant Star" ||
                        TheBaseStar.StellarBodyType == "Red Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Blue Supergiant Star" ||
                        TheBaseStar.StellarBodyType == "Yellow Supergiant Star")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<DwarfPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 0:    // Gas Giant
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 1:    // Gas Giant
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<GasGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 2:    // Ice Giant
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<IceGiant>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 3:    // Asteroid Belt
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<AsteroidBelt>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 4:    // Garden World, Marginal
                    if (TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class F" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class G" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class K" ||
                        TheBaseStar.StellarBodyType == "Main Sequence Star" &&
                        TheBaseStar.SpectralClass == "Class M")
                    {
                        CivTypeByPlanetTypeModifier = -2;
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<GardenWorldMarginal>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 5:    // Rogue Planet
                    PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                    this.gameObject.AddComponent<RoguePlanet>();
                    PlanetaryTypeDetermined = true;
                    break;
                case 6:    // Helium Planet
                    if (TheBaseStar.StellarBodyType == "White Dwarf Star")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<HeliumPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 7:    // Carbon Planet
                    if (TheBaseStar.SpectralClass == "Class S" ||
                        TheBaseStar.SpectralClass == "Class C")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<CarbonPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                case 8:    // Carbon Planet
                    if (TheBaseStar.SpectralClass == "Class S" ||
                        TheBaseStar.SpectralClass == "Class C")
                    {
                        PlanetaryType = OuterPlanetaryTypes [PlanetaryTypeValue + 8];
                        this.gameObject.AddComponent<CarbonPlanet>();
                        PlanetaryTypeDetermined = true;
                    }
                    break;
                default:
                    break;
            }
            if (PlanetaryTypeDetermined == false)
            {
                Invoke("FindPlanetaryType", 0.01f);
            }
        }

        if (PlanetaryTypeDetermined == true)
        {
            FindCivilizationType();
        }
    }

    void FindCivilizationType()
    {
        this.gameObject.AddComponent<BaseCivilization>();
        CivilizationTypeValue = RollTheDice.RollFourDice() + CivTypeByPlanetTypeModifier; 
        switch (TheSliderSetting)
        {
            case 0:                             // The Core Worlds
                switch (CivilizationTypeValue)
                {
                    case -8:                                        // Closed World/Prison Planet
                        int x = Random.Range(1, 3);
                        if (x == 1)                                             // Closed World
                        {
                            CivilizationType = CivilizationTypes [3];
                            this.gameObject.AddComponent<ClosedWorld>();
                        }
                        if (x == 2)                                             // Prison Planet
                        {
                            CivilizationType = CivilizationTypes [18];
                            this.gameObject.AddComponent<PrisonPlanet>();
                        }
                        break;
                    case -7:                                        // Instrumentality Hub
                        CivilizationType = CivilizationTypes [17];
                        this.gameObject.AddComponent<InstrumentalityHub>();
                        break;
                    case -6:                                        // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case -5:                                        // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case -4:                                         // Depot
                        CivilizationType = CivilizationTypes [10];
                        this.gameObject.AddComponent<Depot>();
                        break;
                    case -3:                                         // Industrial World
                        CivilizationType = CivilizationTypes [14];
                        this.gameObject.AddComponent<IndustrialWorld>();
                        break;
                    case -2:                                         // Industrial World
                        CivilizationType = CivilizationTypes [14];
                        this.gameObject.AddComponent<IndustrialWorld>();
                        break;
                    case -1:                                         // Core World
                        CivilizationType = CivilizationTypes [6];
                        this.gameObject.AddComponent<CoreWorld>();
                        break;
                    case 0:                                          // Core World
                        CivilizationType = CivilizationTypes [6];
                        this.gameObject.AddComponent<CoreWorld>();
                        break;
                    case 1:                                          // Core World
                        CivilizationType = CivilizationTypes [6];
                        this.gameObject.AddComponent<CoreWorld>();
                        break;
                    case 2:                                          // Agri World
                        CivilizationType = CivilizationTypes [0];
                        this.gameObject.AddComponent<AgriWorld>();
                        break;
                    case 3:                                          // Agri World
                        CivilizationType = CivilizationTypes [0];
                        this.gameObject.AddComponent<AgriWorld>();
                        break;
                    case 4:                                          // Quarantined World
                        CivilizationType = CivilizationTypes [19];
                        this.gameObject.AddComponent<QuarantinedWorld>();
                        break;
                    case 5:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 6:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 7:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 8:                                          // Core Worlds Hub
                        CivilizationType = CivilizationTypes [7];
                        this.gameObject.AddComponent<CoreWorldsHub>();
                        break;
                    default:
                        break;
                }
                break;
            case 1:                             // Commonality Space
                switch (CivilizationTypeValue)
                {
                    case -8:                                        // Failing World
                        CivilizationType = CivilizationTypes [11];
                        this.gameObject.AddComponent<Failing>();
                        break;
                    case -7:                                        // Instrumentality Hub
                        CivilizationType = CivilizationTypes [17];
                        this.gameObject.AddComponent<InstrumentalityHub>();
                        break;
                    case -6:                                        // Synth Colony
                        CivilizationType = CivilizationTypes [22];
                        this.gameObject.AddComponent<SynthColony>();
                        break;
                    case -5:                                        // Corporacy World
                        CivilizationType = CivilizationTypes [8];
                        this.gameObject.AddComponent<CorporacyWorld>();
                        break;
                    case -4:                                         // Depot
                        CivilizationType = CivilizationTypes [10];
                        this.gameObject.AddComponent<Depot>();
                        break;
                    case -3:                                         // Seed Colony
                        CivilizationType = CivilizationTypes [21];
                        this.gameObject.AddComponent<SeedColony>();
                        break;
                    case -2:                                         // Industrial World
                        CivilizationType = CivilizationTypes [14];
                        this.gameObject.AddComponent<IndustrialWorld>();
                        break;
                    case -1:                                         // Commonality Civilization
                        CivilizationType = CivilizationTypes [4];
                        this.gameObject.AddComponent<CommonalityCivilization>();
                        break;
                    case 0:                                          // Commonality Civilization
                        CivilizationType = CivilizationTypes [4];
                        this.gameObject.AddComponent<CommonalityCivilization>();
                        break;
                    case 1:                                          // Commonality Civilization
                        CivilizationType = CivilizationTypes [4];
                        this.gameObject.AddComponent<CommonalityCivilization>();
                        break;
                    case 2:                                          // Corporacy World
                        CivilizationType = CivilizationTypes [8];
                        this.gameObject.AddComponent<CorporacyWorld>();
                        break;
                    case 3:                                          // Agri World
                        CivilizationType = CivilizationTypes [0];
                        this.gameObject.AddComponent<AgriWorld>();
                        break;
                    case 4:                                          // Quarantined World
                        CivilizationType = CivilizationTypes [19];
                        this.gameObject.AddComponent<QuarantinedWorld>();
                        break;
                    case 5:                                          // Instrumentality Hub
                        CivilizationType = CivilizationTypes [17];
                        this.gameObject.AddComponent<InstrumentalityHub>();
                        break;
                    case 6:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 7:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 8:                                          // Commonality Hub
                        CivilizationType = CivilizationTypes [5];
                        this.gameObject.AddComponent<CommonalityHub>();
                        break;
                    default:
                        break;
                }
                break;
            case 2:                             // The Fringe Worlds
                switch (CivilizationTypeValue)
                {
                    case -8:                                        // Failing World
                        CivilizationType = CivilizationTypes [11];
                        this.gameObject.AddComponent<Failing>();
                        break;
                    case -7:                                        // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case -6:                                        // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case -5:                                        // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case -4:                                         // Holdout World
                        CivilizationType = CivilizationTypes [13];
                        this.gameObject.AddComponent<Holdout>();
                        break;
                    case -3:                                         // Holdout World
                        CivilizationType = CivilizationTypes [13];
                        this.gameObject.AddComponent<Holdout>();
                        break;
                    case -2:                                         // Industrial World
                        CivilizationType = CivilizationTypes [14];
                        this.gameObject.AddComponent<IndustrialWorld>();
                        break;
                    case -1:                                         // Balkanized World
                        CivilizationType = CivilizationTypes [2];
                        this.gameObject.AddComponent<Balkanized>();
                        break;
                    case 0:                                          // United World
                        CivilizationType = CivilizationTypes [23];
                        this.gameObject.AddComponent<UnitedWorld>();
                        break;
                    case 1:                                          // Balkanized World
                        CivilizationType = CivilizationTypes [2];
                        this.gameObject.AddComponent<Balkanized>();
                        break;
                    case 2:                                          // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case 3:                                          // Agri World
                        CivilizationType = CivilizationTypes [0];
                        this.gameObject.AddComponent<AgriWorld>();
                        break;
                    case 4:                                          // Culture World
                        CivilizationType = CivilizationTypes [9];
                        this.gameObject.AddComponent<CultureWorld>();
                        break;
                    case 5:                                          // Culture World
                        CivilizationType = CivilizationTypes [9];
                        this.gameObject.AddComponent<CultureWorld>();
                        break;
                    case 6:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 7:                                          // Interstellar Civilization
                        CivilizationType = CivilizationTypes [15];
                        this.gameObject.AddComponent<InterstellarCivilization>();
                        break;
                    case 8:                                          // Interstellar Hub
                        CivilizationType = CivilizationTypes [16];
                        this.gameObject.AddComponent<InterstellarHub>();
                        break;
                    default:
                        break;
                }
                break;
            case 3:                             // The Outer Worlds
                switch (CivilizationTypeValue)
                {
                    case -8:                                        // Failing World
                        CivilizationType = CivilizationTypes [11];
                        this.gameObject.AddComponent<Failing>();
                        break;
                    case -7:                                        // Failing World
                        CivilizationType = CivilizationTypes [11];
                        this.gameObject.AddComponent<Failing>();
                        break;
                    case -6:                                        // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case -5:                                        // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case -4:                                         // Alien Civilization
                        CivilizationType = CivilizationTypes [1];
                        this.gameObject.AddComponent<AlienCivilization>();
                        break;
                    case -3:                                         // Holdout World
                        CivilizationType = CivilizationTypes [13];
                        this.gameObject.AddComponent<Holdout>();
                        break;
                    case -2:                                         // Industrial World
                        CivilizationType = CivilizationTypes [14];
                        this.gameObject.AddComponent<IndustrialWorld>();
                        break;
                    case -1:                                         // Balkanized World
                        CivilizationType = CivilizationTypes [2];
                        this.gameObject.AddComponent<Balkanized>();
                        break;
                    case 0:                                          // Balkanized World
                        CivilizationType = CivilizationTypes [2];
                        this.gameObject.AddComponent<Balkanized>();
                        break;
                    case 1:                                          // Balkanized World
                        CivilizationType = CivilizationTypes [2];
                        this.gameObject.AddComponent<Balkanized>();
                        break;
                    case 2:                                          // Regressed World
                        CivilizationType = CivilizationTypes [20];
                        this.gameObject.AddComponent<Regressed>();
                        break;
                    case 3:                                          // Agri World
                        CivilizationType = CivilizationTypes [0];
                        this.gameObject.AddComponent<AgriWorld>();
                        break;
                    case 4:                                          // United World
                        CivilizationType = CivilizationTypes [23];
                        this.gameObject.AddComponent<UnitedWorld>();
                        break;
                    case 5:                                          // Failing World
                        CivilizationType = CivilizationTypes [11];
                        this.gameObject.AddComponent<Failing>();
                        break;
                    case 6:                                          // High Population World
                        CivilizationType = CivilizationTypes [12];
                        this.gameObject.AddComponent<HighPopulationWorld>();
                        break;
                    case 7:                                          // Interstellar Civilization
                        CivilizationType = CivilizationTypes [15];
                        this.gameObject.AddComponent<InterstellarCivilization>();
                        break;
                    case 8:                                          // Interstellar Hub
                        CivilizationType = CivilizationTypes [16];
                        this.gameObject.AddComponent<InterstellarHub>();
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void FindAge()
    {
        if (AgeValue < -4)
            AgeValue = -4;
        if (AgeValue > 4)
            AgeValue = 4;
        switch (AgeValue)
        {
            case -4:    // Extremely Young
                Age = Ages [AgeValue + 4];
                DayLengthModifier += 4;
                SatelliteModifier -= 4;
                BiosphereModifier -= 5;
                BiodiversityModifier -= 8;
                break;
            case -3:    // Very Young
                Age = Ages [AgeValue + 4];
                DayLengthModifier += 3;
                SatelliteModifier -= 2;
                BiosphereModifier -= 3;
                BiodiversityModifier -= 6;
                break;
            case -2:    // Young
                Age = Ages [AgeValue + 4];
                DayLengthModifier += 2;
                BiosphereModifier -= 1;
                BiodiversityModifier -= 4;
                break;
            case -1:    // Maturing
                Age = Ages [AgeValue + 4];
                DayLengthModifier += 1;
                BiodiversityModifier -= 2;
                break;
            case 0:     // Mature
                Age = Ages [AgeValue + 4];
                BiosphereModifier ++;
                break;
            case 1:     // Aging
                Age = Ages [AgeValue + 4];
                DayLengthModifier --;
                SatelliteModifier --;
                BiosphereModifier += 3;
                BiodiversityModifier += 2;
                break;
            case 2:     // Old
                Age = Ages [AgeValue + 4];
                DayLengthModifier -= 2;
                SatelliteModifier -= 2;
                BiosphereModifier += 5;
                BiodiversityModifier += 6;
                break;
            case 3:     // Very Old
                Age = Ages [AgeValue + 4];
                DayLengthModifier -= 3;
                SatelliteModifier -= 2;
                BiosphereModifier += 5;
                BiodiversityModifier += 4;
                break;
            case 4:     // Ancient
                Age = Ages [AgeValue + 4];
                DayLengthModifier -= 4;
                SatelliteModifier -= 2;
                BiosphereModifier += 3;
                BiodiversityModifier -= 6;
                break;
            default:
                break;
        }
    }

    public void FindSize()
    {
        switch (SizeValue)
        {
            case -4:                            // Planetesimal
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 0.01f;
                GravityModifier -= 4;
                MaxMoons = 0;
                BiosphereModifier -= 4;
                break;
            case -3:                            // Planetoid
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 0.1f;
                GravityModifier -= 3;
                MaxMoons = 1;
                BiosphereModifier -= 2;
                break;
            case -2:                            // Small
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 0.3f;
                GravityModifier -= 2;
                MaxMoons = 1;
                BiosphereModifier ++;
                break;
            case -1:                            // Small Standard
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 0.5f;
                GravityModifier --;
                MaxMoons = 3;
                BiosphereModifier += 2;
                break;
            case 0:                            // Standard
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 1f;
                MaxMoons = 3;
                BiosphereModifier += 2;
                break;
            case 1:                            // Large Standard
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 1.5f;
                GravityModifier ++;
                MaxMoons = 5;
                BiosphereModifier += 2;
                break;
            case 2:                            // Large
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 3f;
                DensityModifier --;
                GravityModifier += 5;
                MaxMoons = 10;
                BiosphereModifier += 2;
                break;
            case 3:                            // Very Large
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 5f;
                DensityModifier -= 2;
                GravityModifier += 6;
                MaxMoons = 10;
                break;
            case 4:                            // Giant
                Size = Sizes [SizeValue + 4];
                EarthDiameters = 10f;
                DensityModifier -= 3;
                GravityModifier += 8;
                MaxMoons = Random.Range (10, 51);
                BiosphereModifier -= 2;
                break;
            default:
                break;
        }
        DiameterInKilometers = EarthDiameters * 12800f;
    }

    public void FindDensity()
    {
        DensityValue += DensityModifier;
        if (DensityValue < DensityMin)
            DensityValue = DensityMin;
        if (DensityValue > DensityMax)
            DensityValue = DensityMax;
        int x = DensityValue;
        if (x < -4)
            x = -4;
        if (x > 5)
            x = 5;
        if (x >= 4 && x <= 9)
            x = 4;
        switch (x)
        {
            case -4:            // Extremely Low
                Density = Densities [0];
                EarthDensities = 0.05f;
                GravityModifier -= 10;
                BiosphereModifier -= 3;
                break;
            case -3:            // Very Low
                Density = Densities [1];
                EarthDensities = 0.1f;
                GravityModifier -= 5;
                BiosphereModifier --;
                break;
            case -2:            // Low
                Density = Densities [2];
                EarthDensities = 0.25f;
                GravityModifier -= 3;
                BiosphereModifier --;
                break;
            case -1:            // Low Standard
                Density = Densities [3];
                EarthDensities = 0.7f;
                GravityModifier --;
                BiosphereModifier ++;
                break;
            case 0:             // Standard
                Density = Densities [4];
                EarthDensities = 1f;
                BiosphereModifier ++;
                break;
            case 1:             // High Standard
                Density = Densities [5];
                EarthDensities = 1.3f;
                GravityModifier ++;
                BiosphereModifier ++;
                break;
            case 2:             // Dense
                Density = Densities [6];
                EarthDensities = 2f;
                GravityModifier += 2;
                BiosphereModifier ++;
                break;
            case 3:             // Very Dense
                Density = Densities [7];
                EarthDensities = 3f;
                GravityModifier += 3;
                BiosphereModifier ++;
                break;
            case 4:             // Extremely Dense
                Density = Densities [8];
                EarthDensities = 5f;
                GravityModifier += 5;
                BiosphereModifier --;
                break;
            case 5:             // Exotic
                Density = Densities [9];
                EarthDensities = 10f;
                GravityModifier += 10;
                BiosphereModifier -= 3;
                break;
            default:
                break;
        }
    }

    public void FindGravity()
    {
        SurfaceGravityValue += GravityModifier;
        if (SurfaceGravityValue < GravityMin)
            SurfaceGravityValue = GravityMin;
        if (SurfaceGravityValue > GravityMax)
            SurfaceGravityValue = GravityMax;
        int x = SurfaceGravityValue;
        if (x < -4)
            x = -4;
        if (x > 5)
            x = 5;
        if (x >= 4 && x <= 9)
            x = 4;
        switch (x)
        {
            case -4:            // Microgravity
                SurfaceGravity = Gravities [0];
                EarthGravities = 0;
                DayLengthModifier -= 4;
                AtmosphericPressureModifier -= 15;
                BiosphereModifier -= 3;
                break;
            case -3:            // Very Low
                SurfaceGravity = Gravities [1];
                EarthGravities = Random.Range(0.05f, 0.1f);
                DayLengthModifier -= 3;
                AtmosphericPressureModifier -= 10;
                BiosphereModifier -= 2;
                break;
            case -2:            // Low
                SurfaceGravity = Gravities [2];
                EarthGravities = Random.Range(0.1f, 0.5f);
                DayLengthModifier -= 2;
                AtmosphericPressureModifier -= 5;
                BiosphereModifier --;
                break;
            case -1:            // Low Standard
                SurfaceGravity = Gravities [3];
                EarthGravities = Random.Range(0.5f, 1f);
                DayLengthModifier --;
                AtmosphericPressureModifier -= 2;
                break;
            case 0:             // Standard
                SurfaceGravity = Gravities [4];
                EarthGravities = 1;
                BiosphereModifier ++;
                break;
            case 1:             // High Standard
                SurfaceGravity = Gravities [5];
                EarthGravities = Random.Range(1f, 1.5f);
                DayLengthModifier ++;
                BiosphereModifier ++;
                break;
            case 2:             // High
                SurfaceGravity = Gravities [6];
                EarthGravities = Random.Range(2f, 3f);
                DayLengthModifier += 2;
                AtmosphericPressureModifier += 2;
                break;
            case 3:             // Very High
                SurfaceGravity = Gravities [7];
                EarthGravities = Random.Range(4f, 5f);
                DayLengthModifier += 3;
                AtmosphericPressureModifier += 5;
                break;
            case 4:             // Extremely High
                SurfaceGravity = Gravities [8];
                EarthGravities = Random.Range(6f, 10f);
                DayLengthModifier += 4;
                AtmosphericPressureModifier += 10;
                BiosphereModifier -= 2;
                break;
            case 5:             // Exotic
                SurfaceGravity = Gravities [9];
                EarthGravities = Random.Range(10f, 20f);
                DayLengthModifier += 5;
                AtmosphericPressureModifier += 15;
                BiosphereModifier -= 3;
                break;
            default:
                break;
        }
        EarthGravities = Mathf.Round(EarthGravities * 100) / 100;
    }

    public void FindDayLength()
    {
        int x = OrbitValue;
        if (OrbitValue == -3)
            x = -5;
        x += DayLengthModifier;
        if (x < -5)
            x = -5;
        if (x > 8)
            x = 8;
        if (x < DayLengthMin)
            x = DayLengthMin;
        if (x > DayLengthMax)
            x = DayLengthMax;
        switch (x)
        {
            case -5:        // Tidal Lock
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = YearLength;
                BiosphereModifier -= 3;
                break;
            case -4:        // Extremely Slow
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round(Random.Range(100f, 200f) * 100) / 100;
                BiosphereModifier -= 2;
                break;
            case -3:        // Very Slow
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round(Random.Range(50f, 100f) * 100) / 100;
                BiosphereModifier --;
                break;
            case -2:        // Slow
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round(Random.Range(10f, 50f) * 100) / 100;
                break;
            case -1:        // Reduced
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round(Random.Range(2f, 10f) * 100) / 100;
                BiosphereModifier ++;
                break;
            case 0:         // Standard
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = 1;
                BiosphereModifier += 2;
                break;
            case 1:         // Increased
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((22f / 24f) * 100) / 100;
                break;
            case 2:         // Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((20f / 24f) * 100) / 100;
                BiosphereModifier --;
                break;
            case 3:         // Very Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((18f / 24f) * 100) / 100;
                BiosphereModifier -= 2;
                break;
            case 4:         // Extremely Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((16f / 24f) * 100) / 100;
                BiosphereModifier -= 3;
                break;
            case 5:         // Extremely Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((14f / 24f) * 100) / 100;
                BiosphereModifier -= 5;
                break;
            case 6:         // Extremely Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((12f / 24f) * 100) / 100;
                BiosphereModifier -= 5;
                break;
            case 7:         // Extremely Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((10f / 24f) * 100) / 100;
                BiosphereModifier -= 5;
                break;
            case 8:         // Extremely Rapid
                DayLength = DayLengths [x + 5];
                DayLengthValue = x;
                LengthInDays = Mathf.Round((8f / 24f) * 100) / 100;
                BiosphereModifier -= 5;
                break;
            default:
                break;
        }
    }

    public void FindAtmosphericPressure()
    {
        AtmosphericPressureValue += AtmosphericPressureModifier;
        if (AtmosphericPressureValue < AtmosphericPressureMin)
            AtmosphericPressureValue = AtmosphericPressureMin;
        if (AtmosphericPressureValue > AtmosphericPressureMax)
            AtmosphericPressureValue = AtmosphericPressureMax;
        int x = AtmosphericPressureValue;
        switch (x)
        {
            case -10:
                x = 0;
                break;
            case -9:
                x = 1;
                break;
            case -8:
                x = 1;
                break;
            case -7:
                x = 1;
                break;
            case -6:
                x = 1;
                break;
            case -5:
                x = 1;
                break;
            case -4:
                x = 1;
                break;
            case -3:
                x = 2;
                break;
            case -2:
                x = 2;
                break;
            case -1:
                x = 3;
                break;
            case -0:
                x = 3;
                break;
            case 1:
                x = 3;
                break;
            case 2:
                x = 4;
                break;
            case 3:
                x = 4;
                break;
            case 4:
                x = 5;
                break;
            case 5:
                x = 5;
                break;
            case 6:
                x = 5;
                break;
            case 7:
                x = 6;
                break;
            case 8:
                x = 6;
                break;
            case 9:
                x = 6;
                break;
            case 10:
                x = 7;
                break;
            default:
                break;
        }
        switch (x)
        {
            case 0:                                     // Trace
                AtmosphericPressure = Pressures [x];
                TemperatureModifier -= 3;
                SurfaceLiquidModifier -= 10;
                BiosphereModifier -= 5;
                HabitabilityModifier -= 10;
                break;
            case 1:                                     // Very Low
                AtmosphericPressure = Pressures [x];
                TemperatureModifier -= 2;
                SurfaceLiquidModifier -= 3;
                BiosphereModifier -= 3;
                HabitabilityModifier -= 3;
                break;
            case 2:                                     // Low
                AtmosphericPressure = Pressures [x];
                TemperatureModifier --;
                SurfaceLiquidModifier --;
                BiosphereModifier --;
                HabitabilityModifier --;
                break;
            case 3:                                     // Standard
                AtmosphericPressure = Pressures [x];
                SurfaceLiquidModifier ++;
                BiosphereModifier ++;
                HabitabilityModifier += 2;
                break;
            case 4:                                     // High
                AtmosphericPressure = Pressures [x];
                TemperatureModifier ++;
                SurfaceLiquidModifier ++;
                BiosphereModifier ++;
                HabitabilityModifier --;
                break;
            case 5:                                     // Very High
                AtmosphericPressure = Pressures [x];
                TemperatureModifier += 3;
                SurfaceLiquidModifier += 3;
                BiosphereModifier ++;
                HabitabilityModifier -= 2;
                break;
            case 6:                                     // Hazardous
                AtmosphericPressure = Pressures [x];
                TemperatureModifier += 4;
                SurfaceLiquidModifier += 6;
                BiosphereModifier -= 3;
                HabitabilityModifier -= 3;
                break;
            case 7:                                     // Insidious
                AtmosphericPressure = Pressures [x];
                TemperatureModifier += 5;
                SurfaceLiquidModifier += 9;
                BiosphereModifier -= 5;
                HabitabilityModifier -= 3;
                break;
            default:
                break;
        }
    }

    public void FindSurfaceTemp()
    {
        int TempK = 0;
        SurfaceTemperatureValue += TemperatureModifier;
        if (SurfaceTemperatureValue < SurfaceTempMin)
            SurfaceTemperatureValue = SurfaceTempMin;
        if (SurfaceTemperatureValue > SurfaceTempMax)
            SurfaceTemperatureValue = SurfaceTempMax;

        int x = SurfaceTemperatureValue;
        switch (x)
        {
            case -4:                                        // Frozen
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 30;
                BiosphereModifier -= 2;
                HabitabilityModifier -= 10;
                break;
            case -3:                                        // Frigid
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 100;
                BiosphereModifier --;
                HabitabilityModifier -= 4;
                break;
            case -2:                                        // Cold
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 200;
                HabitabilityModifier -= 2;
                break;
            case -1:                                        // Cool
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 283;
                BiosphereModifier ++;
                HabitabilityModifier ++;
                break;
            case 0:                                         // Standard
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 287;
                BiosphereModifier ++;
                HabitabilityModifier += 2;
                break;
            case 1:                                         // Warm
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 293;
                BiosphereModifier ++;
                HabitabilityModifier ++;
                break;
            case 2:                                         // Hot
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 370;
                BiosphereModifier --;
                HabitabilityModifier -= 2;
                break;
            case 3:                                         // Furnace
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 450;
                BiosphereModifier -= 2;
                HabitabilityModifier -= 3;
                break;
            case 4:                                         // Inferno
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 750;
                BiosphereModifier -= 3;
                HabitabilityModifier -= 3;
                break;
            case 5:                                         // Inferno
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 1500;
                BiosphereModifier -= 3;
                HabitabilityModifier -= 5;
                break;
            case 6:                                         // Inferno
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 3000;
                BiosphereModifier -= 5;
                HabitabilityModifier -= 5;
                break;
            case 7:                                         // Chthonian
                SurfaceTemperature = Temperatures [x + 4];
                TempK = 6000;
                BiosphereModifier -= 5;
                HabitabilityModifier -= 5;
                break;
            default:
                break;
        }
        TemperatureInCelsius = TempK - 273;
    }

    public void AqueousPlanetDetermination()
    {
        if (HabitabilityModifier > 0)                   // Aqueous
        {
            AqueousPlanetType = AqueousPlanetTypes [0];
        }
        if (HabitabilityModifier < 0)                   // Non-Aqueous
        {
            AqueousPlanetType = AqueousPlanetTypes [1];
        }
        if (HabitabilityModifier == 0)
        {
            int x = Random.Range(1, 3);
            if (x == 1)                                 // Aqueous
            {
                AqueousPlanetType = AqueousPlanetTypes [0];

            }
            if (x == 2)                                 // Non-Aqueous
            {
                AqueousPlanetType = AqueousPlanetTypes [1];
            }
        }
        switch (AqueousPlanetType)
        {
            case "Aqueous":
                if (AgeValue <= -3)                     // Unbreathable
                {
                    AtmosphericBreathability = Breathabilities [0];
                    if (HabitabilityModifier > -1)
                    {
                        HabitabilityModifier = -1;
                        Aspects.Add("Terraforming Candidate");
                    }
                }
                if (AgeValue >= -1 && AgeValue <= 1)    // Breathable
                {
                    AtmosphericBreathability = Breathabilities [1];
                    if (HabitabilityModifier < 0)
                    {
                        HabitabilityModifier = 0;
                    }
                }
                if (AgeValue == -2 || AgeValue >= 2)    // Tainted
                {
                    AtmosphericBreathability = Breathabilities [2];
                    if (HabitabilityModifier > 0)
                    {
                        HabitabilityModifier = 0;
                    }
                }
                break;
            case "Non-Aqueous":
                switch (SurfaceTemperatureValue)
                {
                    case -4:
                        HabitabilityModifier -= 3;
                        break;
                    case -3:
                        HabitabilityModifier --;
                        break;
                    case -2:
                        HabitabilityModifier --;
                        break;
                    case -1:
                        HabitabilityModifier -= 4;
                        break;
                    case 0:
                        HabitabilityModifier -= 4;
                        break;
                    case 1:
                        HabitabilityModifier -= 4;
                        break;
                    case 2:
                        HabitabilityModifier --;
                        break;
                    case 3:
                        HabitabilityModifier --;
                        break;
                    case 4:
                        HabitabilityModifier -= 2;
                        break;
                    case 5:
                        HabitabilityModifier -= 2;
                        break;
                    case 6:
                        HabitabilityModifier -= 2;
                        break;
                    case 7:
                        HabitabilityModifier -= 4;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void FindSurfaceLiquidExtent()
    {
        if (AqueousPlanetType == AqueousPlanetTypes [0])
        {
            SurfaceLiquidExtentValue += SurfaceLiquidModifier;
            if (SurfaceLiquidExtentValue < SurfaceLiquidMin)
                SurfaceLiquidExtentValue = SurfaceLiquidMin;
            if (SurfaceLiquidExtentValue > SurfaceLiquidMax)
                SurfaceLiquidExtentValue = SurfaceLiquidMax;
            switch (SurfaceLiquidExtentValue)
            {
                case -4:            // None
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = 0f;
                    BiosphereModifier -= 5;
                    break;
                case -3:            // Trace
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(0.01f, 1f) * 100) / 100;
                    BiosphereModifier -= 3;
                    break;
                case -2:            // Very Low
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(1f, 5f) * 100) / 100;
                    BiosphereModifier --;
                    break;
                case -1:            // Low
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(5f, 25f) * 100) / 100;
                    break;
                case -0:            // Average
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(25f, 50f) * 100) / 100;
                    BiosphereModifier += 2;
                    break;
                case 1:             // High
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(50f, 65f) * 100) / 100;
                    BiosphereModifier += 2;
                    break;
                case 2:             // Very High
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(65f, 80f) * 100) / 100;
                    BiosphereModifier += 3;
                    break;
                case 3:             // Almost Total
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(80f, 90f) * 100) / 100;
                    BiosphereModifier += 5;
                    break;
                case 4:             // Oceanworld
                    SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
                    SurfaceLiquidPercentage = Mathf.Round(Random.Range(90f, 100f) * 100) / 100;
                    BiosphereModifier += 5;
                    break;
                default:
                    break;
            }
        }
        if (AqueousPlanetType == AqueousPlanetTypes [1])
        {
            SurfaceLiquidExtentValue = -4;
            SurfaceLiquidExtent = LiquidExtents [SurfaceLiquidExtentValue + 4];
        }
    }

    public void FindSeasonality()
    {
        SeasonalityValue += SeasonalityModifier;
        if (SeasonalityValue < SeasonalityMin)
            SeasonalityValue = SeasonalityMin;
        if (SeasonalityValue > SeasonalityMax)
            SeasonalityValue = SeasonalityMax;
        switch (SeasonalityValue)
        {
            case -10:                           // No Seasonality
                Seasonality = Seasonalities [0];
                BiosphereModifier -= 4;
                break;
            case -9:                           // Little Seasonality
                Seasonality = Seasonalities [1];
                BiosphereModifier -= 2;
                break;
            case -8:                           // Little Seasonality
                Seasonality = Seasonalities [1];
                BiosphereModifier -= 2;
                break;
            case -7:                           // Little Seasonality
                Seasonality = Seasonalities [1];
                BiosphereModifier -= 2;
                break;
            case -6:                           // Little Seasonality
                Seasonality = Seasonalities [1];
                BiosphereModifier -= 2;
                break;
            case -5:                           // Little Seasonality
                Seasonality = Seasonalities [1];
                BiosphereModifier -= 2;
                break;
            case -4:                           // Very Low
                Seasonality = Seasonalities [2];
                break;
            case -3:                           // Low
                Seasonality = Seasonalities [3];
                break;
            case -2:                           // Low
                Seasonality = Seasonalities [3];
                break;
            case -1:                           // Low Standard
                Seasonality = Seasonalities [4];
                break;
            case 0:                            // Standard
                Seasonality = Seasonalities [5];
                break;
            case 1:                            // High Standard
                Seasonality = Seasonalities [6];
                break;
            case 2:                            // High
                Seasonality = Seasonalities [7];
                break;
            case 3:                            // High
                Seasonality = Seasonalities [7];
                break;
            case 4:                            // Very High
                Seasonality = Seasonalities [8];
                BiosphereModifier -= 2;
                break;
            case 5:                            // Extreme Seasonality
                Seasonality = Seasonalities [9];
                BiosphereModifier -= 4;
                break;
            case 6:                            // Extreme Seasonality
                Seasonality = Seasonalities [9];
                BiosphereModifier -= 4;
                break;
            case 7:                            // Extreme Seasonality
                Seasonality = Seasonalities [9];
                BiosphereModifier -= 4;
                break;
            case 8:                            // Extreme Seasonality
                Seasonality = Seasonalities [9];
                BiosphereModifier -= 4;
                break;
            case 9:                            // Extreme Seasonality
                Seasonality = Seasonalities [9];
                BiosphereModifier -= 4;
                break;
            case 10:                           // Twin Climates
                Seasonality = Seasonalities [10];
                BiosphereModifier -= 8;
                break;
            default:
                break;
        }
    }

    public void DetermineNumberOfSatellites()
    {
        for (int x = 0; x < MaxMoons; x++)
        {
            int z = RollTheDice.RollFourDice();
            z = (z += SatelliteModifier);
            if (z <= -3)    // No Satellite
            {
                BiosphereModifier -= 2;
            }
            if (z > -3)     // Satellite Exists
            {
                TheSatelliteType = z;
                if (z >= 4)
                {
                    z = 4;
                }
                if ((z - 4) <= SizeValue)
                {
                    Satellites++;
                    AddTheSatelliteType();
                }
                // if random satellite number indicating satellite size is equal to the size of the planet, the satellite becomes a binary planet
                if ((z - 4) == SizeValue)   // Binary Planet
                {
                
                }
                // if random satellite number indicating satellite size is greater than the size of the planet, roll again
                if ((z - 4) > SizeValue)
                {
                    x--;
                }
            }
        }
    }

    void AddTheSatelliteType()
    {
        int z = TheSatelliteType;
        switch (z)
        {
            case -2:
                SatelliteTypes.Add("Ring System");
                BiosphereModifier --;
                break;
            case -1:
                SatelliteTypes.Add("Planetesimal");
                BiosphereModifier --;
                break;
            case 0:
                SatelliteTypes.Add("Planetesimal");
                break;
            case 1:
                SatelliteTypes.Add("Planetoid");
                BiosphereModifier ++;
                break;
            case 2:
                SatelliteTypes.Add("Small");
                BiosphereModifier += 2;
                break;
            case 3:
                SatelliteTypes.Add("Small Standard");
                BiosphereModifier += 2;
                break;
            case 4:
                SatelliteTypes.Add("Standard");
                BiosphereModifier -= 2;
                break;
        }
    }

    public void FindBiosphere()
    {
        BiosphereValue += BiosphereModifier;
        int x = BiosphereValue;
        if (x <= -1)
            x = -1;
        if (x >= 0 && x <= 3)
            x = 0;
        if (x >= 4)
            x = 1;
        switch (x)
        {
            case -1:
                Biosphere = "No Biosphere";
                break;
            case 0:
                Biosphere = "Simple Biosphere";
                break;
            case 1:
                Biosphere = "Biosphere";
                break;
            default:
                break;
        }
    }

    public void FindHabitability()
    {
        HabitabilityValue = HabitabilityModifier;
        int x = HabitabilityValue;
        if (x < HabitabilityMin)
            x = HabitabilityMin;
        if (x > HabitabilityMax)
            x = HabitabilityMax;
        switch(x)
        {
            case -4:                                // Deadly
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Requires Extreme Habitat Protective Measures");
                Aspects.Add("Requires Extreme Environment Adaptation");
                break;
            case -3:                                // Lethal
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Will Defeat Vac Sealing & P-Suits");
                Aspects.Add("Armor & Shields Will Protect Against Damage");
                break;
            case -2:                                // Hostile
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Requires Vac Sealing, P-Suits, etc. To Avoid Harm");
                break;
            case -1:                                // Inimical
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Requires Vac Sealing, P-Suits, etc. To Avoid Harm");
                break;
            case 0:                                // Marginal
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Requires Breathers To Avoid Harm");
                break;
            case 1:                                // Challenging
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Immediately Survivable But Severe In The Long Term");
                break;
            case 2:                                // Adequate
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Sufficient For Log Term Survival");
                break;
            case 3:                                // Agreeable
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Favorable For Long Term Habitation");
                break;
            case 4:                                // Benign
                Habitability = Habitabilities[x + 4];
                Aspects.Add("Ideal For Long Term Habitation");
                break;
            default:
                break;
        }
    }
}

// print(this.gameObject.transform.parent.name + ": \n" + this.gameObject.name + " - " + AqueousPlanetType);

