using UnityEngine;
using System.Collections;

/*
Aspects: Deep Space Secrets of the Lowhigh; Hidden Worlds in the Big Empty.
Stellar Body: None.
Age: Very young or older.
Orbit: n/a.
Size: Large to Giant.
Density: Very Low to Dense.
Gravity: Standard to Exotic.
Day Length: Any.
Atmospheric Pressure: Very Low to Corrosive.
Temperature: Frigid to Cool.
Liquid: Any.
Seasonality: n/a.
Biosphere: T-Analogue, Alternate, Parallel, Exotic.
Habitability: Any.
Resources: As gas giant or terrestrial planet.
*/

public class RoguePlanet : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    
    // Planetary Age restrictions; range is -4 to 4
    private int PlanetaryAgeMinimum = -3;
    private int PlanetaryAgeMaximum = 4;
    
    // Planetary Size restrictions; range is -4 to 4
    private int PlanetarySizeMinimum = 2;
    private int PlanetarySizeMaximum = 4;
    
    // Planetary Density restrictions; range is -4 to 10
    private int PlanetaryDensityMinimum = -3;
    private int PlanetaryDensityMaximum = 2;
    
    // Planetary Gravity restrictions; range is -4 to 10
    private int PlanetaryGravityMinimum = 0;
    private int PlanetaryGravityMaximum = 10;
    
    // Day Length restrictions; range is -5 to 8
    private int PlanetaryDayLengthMininum = -5;
    private int PlanetaryDayLengthMaximum = 4;
    
    // Atmospheric Pressure restrictions; range is -10 to 10
    private int AtmosphericPressureMinimum = -9;
    private int AtmosphericPressureMaximum = 10;
    
    // Surface Temperature restrictions; range is -4 to 7
    private int SurfaceTemperatureMinimum = -3;
    private int SurfaceTemperatureMaximum = -1;
    
    // Surface Liquid Extent restrictions; range is -4 to 4
    private int SirfaceLiquidMinimum = -4;
    private int SurfaceLiquidMaximum = 4;
    
    // Seasonality restrictions; range is -10 to 10
    private int SeasonalityMinimum = -10;
    private int SeasonalityMaximum = -10;
    
    // Habitability restrictions; range is -4 to 4
    private int HabitabilityMinimum = -4;
    private int HabitabilityMaximum = 4;
    
    void Awake()
    {
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = GetComponentInParent<BaseStar>();
        TheBasePlanetarySystem = this.gameObject.GetComponent<BasePlanetarySystem>();
    }
    // Use this for initialization
    void Start()
    {
        this.gameObject.name = TheBasePlanetarySystem.PlanetaryType;
        
        TheBasePlanetarySystem.Aspects.Add("Deep Space Secrets of the Lowhigh");
        TheBasePlanetarySystem.Aspects.Add("Hidden World in the Big Empty");

        // Add Description
        TheBasePlanetarySystem.PlanetaryDescription = "Planetary bodies ejected from star systems or forming independently in space (when they’re also called sub-brown dwarfs), there are many more rogue planets drifting between the stars than there are stars in the galaxy. Rogue planets are giant planets, often gas giants with thick hydrogen atmospheres; some have liquid-water oceans, with biospheres powered by vulcanism, radioactive decay, or tidal heating if they have moons. Difficult to detect at distances greater than 1000 AU, in some cases (Exotic Gravity and above) their gravity wells prevent the emergence of the Pulse Dragon Phenomenon (page 92). The alien Lowhigh are said to have extensive data on rogue planets.";
        
        // Add Age
        AddAge();
        AddSize();
        AddDensity();
        AddGravity();
        AddDayLength();
        AddAtmosphericPressure();
        AddSurfaceTemperature();
        DetermineIfAqueous();
        AddSurfaceLiquidExtent();
        AddSeasonality();
        AddSatellites();
        AddBiosphere();
        AddHabitability();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AddAge()
    {
        PlanetaryAgeMaximum = Mathf.Min(TheBaseStar.AgeValue, PlanetaryAgeMaximum);
        int Roll = RollTheDice.RollFourDice();
        if (Roll < PlanetaryAgeMinimum)
            Roll = PlanetaryAgeMinimum;
        if (Roll > PlanetaryAgeMaximum)
            Roll = PlanetaryAgeMaximum;
        TheBasePlanetarySystem.AgeValue = Roll;
        TheBasePlanetarySystem.FindAge();
    }
    
    void AddSize() // restrictions need to be put in place.
    {
        int Roll = RollTheDice.RollFourDice();
        if (Roll < PlanetarySizeMinimum)
            Roll = PlanetarySizeMinimum;
        if (Roll > PlanetarySizeMaximum)
            Roll = PlanetarySizeMaximum;
        TheBasePlanetarySystem.SizeValue = Roll;
        TheBasePlanetarySystem.FindSize();
    }
    
    void AddDensity() // restrictions need to be put in place.
    {
        TheBasePlanetarySystem.DensityMin = PlanetaryDensityMinimum;
        TheBasePlanetarySystem.DensityMax = PlanetaryDensityMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.DensityValue = Roll;
        TheBasePlanetarySystem.FindDensity();
    }
    
    void AddGravity()
    {
        TheBasePlanetarySystem.GravityMin = PlanetaryGravityMinimum;
        TheBasePlanetarySystem.GravityMax = PlanetaryGravityMaximum;
        TheBasePlanetarySystem.FindGravity();
    }
    
    void AddDayLength()
    {
        TheBasePlanetarySystem.DayLengthMin = PlanetaryDayLengthMininum;
        TheBasePlanetarySystem.DayLengthMax = PlanetaryDayLengthMaximum;
        TheBasePlanetarySystem.FindDayLength();
    }
    
    void AddAtmosphericPressure()
    {
        TheBasePlanetarySystem.AtmosphericPressureMin = AtmosphericPressureMinimum;
        TheBasePlanetarySystem.AtmosphericPressureMax = AtmosphericPressureMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.AtmosphericPressureValue = Roll;
        TheBasePlanetarySystem.FindAtmosphericPressure();
    }
    
    void AddSurfaceTemperature()
    {
        TheBasePlanetarySystem.SurfaceTempMin = SurfaceTemperatureMinimum;
        TheBasePlanetarySystem.SurfaceTempMax = SurfaceTemperatureMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.SurfaceTemperatureValue = Roll;
        TheBasePlanetarySystem.FindSurfaceTemp();
    }
    
    void DetermineIfAqueous()
    {
        TheBasePlanetarySystem.AqueousPlanetDetermination();
    }
    
    void AddSurfaceLiquidExtent()
    {
        TheBasePlanetarySystem.SurfaceLiquidMin = SirfaceLiquidMinimum;
        TheBasePlanetarySystem.SurfaceLiquidMax = SurfaceLiquidMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.SurfaceLiquidExtentValue = Roll;
        TheBasePlanetarySystem.FindSurfaceLiquidExtent();
    }
    
    void AddSeasonality()
    {
        TheBasePlanetarySystem.SeasonalityMin = SeasonalityMinimum;
        TheBasePlanetarySystem.SeasonalityMax = SeasonalityMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.SeasonalityValue = Roll;
        TheBasePlanetarySystem.FindSeasonality();
    }
    
    void AddSatellites()
    {
        TheBasePlanetarySystem.DetermineNumberOfSatellites();
    }
    
    void AddBiosphere()
    {
        int Roll = RollTheDice.RollFourDice();
        TheBasePlanetarySystem.BiosphereValue = Roll;
        TheBasePlanetarySystem.FindBiosphere();
    }
    
    void AddHabitability()
    {
        TheBasePlanetarySystem.HabitabilityMin = HabitabilityMinimum;
        TheBasePlanetarySystem.HabitabilityMax = HabitabilityMaximum;
        TheBasePlanetarySystem.FindHabitability();
    }
}
