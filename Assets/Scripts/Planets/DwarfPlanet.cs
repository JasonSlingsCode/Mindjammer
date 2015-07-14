using UnityEngine;
using System.Collections;

/*
Aspects: Asteroid Belt World; Frozen Wanderer in the Outer System.
Stellar Body: Any star.
Age: Any.
Orbit: Any.
Size: Planetoid.
Density: Low to Dense.
Gravity: Microgravity to Low Standard.
Day Length: No Rotation to Reduced.
Atmospheric Pressure: Trace to High.
Temperature: Any.
Liquid: Any.
Seasonality: Any.
Biosphere: Any.
Habitability: Any.
Resources: As protoplanet.
*/
public class DwarfPlanet : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    
    // Planetary Age restrictions; range is -4 to 4
    private int PlanetaryAgeMinimum = -4;
    private int PlanetaryAgeMaximum = 4;
    
    // Planetary Size restrictions; range is -4 to 4
    private int PlanetarySizeMinimum = -3;
    private int PlanetarySizeMaximum = -3;
    
    // Planetary Density restrictions; range is -4 to 10
    private int PlanetaryDensityMinimum = -2;
    private int PlanetaryDensityMaximum = 2;
    
    // Planetary Gravity restrictions; range is -4 to 10
    private int PlanetaryGravityMinimum = -4;
    private int PlanetaryGravityMaximum = -1;
    
    // Day Length restrictions; range is -5 to 8
    private int PlanetaryDayLengthMininum = -5;
    private int PlanetaryDayLengthMaximum = -1;
    
    // Atmospheric Pressure restrictions; range is -10 to 10
    private int AtmosphericPressureMinimum = -10;
    private int AtmosphericPressureMaximum = 3;
    
    // Surface Temperature restrictions; range is -4 to 7
    private int SurfaceTemperatureMinimum = -4;
    private int SurfaceTemperatureMaximum = 7;
    
    // Surface Liquid Extent restrictions; range is -4 to 4
    private int SirfaceLiquidMinimum = -4;
    private int SurfaceLiquidMaximum = 4;
    
    // Seasonality restrictions; range is -10 to 10
    private int SeasonalityMinimum = -10;
    private int SeasonalityMaximum = 10;
    
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

        TheBasePlanetarySystem.Aspects.Add("Asteroid Belt World");
        TheBasePlanetarySystem.Aspects.Add("Frozen Wanderer in the Outer System");
        
        // Add Description
        TheBasePlanetarySystem.PlanetaryDescription = "Dwarf planets are closer to planets than asteroids, their spherical shapes created by gravity. They’re derived from protoplanets, cooler and with fewer radioactives, which have not managed to clear their orbits of other bodies.";
        
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
