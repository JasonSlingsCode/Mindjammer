using UnityEngine;
using System.Collections;

/*
Aspects: Chaotic Crashing Rocks; Fiery Radioactive Progenitors of Worlds.
Stellar Body: Any protostar; optionally any very young main sequence star.
Age: Protoplanet.
Orbit: Any.
Size: Planetesimal to Planetoid.
Density: Low to Dense.
Gravity: Microgravity to Low Standard.
Day Length: Extremely Slow to Extremely Rapid.
Atmospheric Pressure: Trace to Standard.
Temperature: Frozen to Inferno.
Liquid: Usually only magma.
Seasonality: Any, but usually low.
Biosphere: Usually too young; Maintained, Transplant, T-Congruent possible.
Habitability: Inimical to Deadly.
Resources: Plentiful: heavy elements, radioactives, zanthrium.
*/

public class Protoplanet : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    
    // Planetary Age restrictions; range is -4 to 4
    private int PlanetaryAgeMinimum = -4;
    private int PlanetaryAgeMaximum = -4;
    
    // Planetary Size restrictions; range is -4 to 4
    private int PlanetarySizeMinimum = -4;
    private int PlanetarySizeMaximum = -3;
    
    // Planetary Density restrictions; range is -4 to 10
    private int PlanetaryDensityMinimum = -2;
    private int PlanetaryDensityMaximum = 2;
    
    // Planetary Gravity restrictions; range is -4 to 10
    private int PlanetaryGravityMinimum = -4;
    private int PlanetaryGravityMaximum = -1;
    
    // Day Length restrictions; range is -5 to 8
    private int PlanetaryDayLengthMininum = -4;
    private int PlanetaryDayLengthMaximum = 8;
    
    // Atmospheric Pressure restrictions; range is -10 to 10
    private int AtmosphericPressureMinimum = -10;
    private int AtmosphericPressureMaximum = 1;
    
    // Surface Temperature restrictions; range is -4 to 7
    private int SurfaceTemperatureMinimum = -4;
    private int SurfaceTemperatureMaximum = 6;
    
    // Surface Liquid Extent restrictions; range is -4 to 4
    private int SirfaceLiquidMinimum = -4;
    private int SurfaceLiquidMaximum = 4;
    
    // Seasonality restrictions; range is -10 to 10
    private int SeasonalityMinimum = -10;
    private int SeasonalityMaximum = 10;
    
    // Habitability restrictions; range is -4 to 4
    private int HabitabilityMinimum = -4;
    private int HabitabilityMaximum = -1;
    
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
        
        TheBasePlanetarySystem.Aspects.Add("Chaotic Crashing Rocks");
        TheBasePlanetarySystem.Aspects.Add("Fiery Radioactive Progenitors of Worlds");
        TheBasePlanetarySystem.Aspects.Add("Smouldering Lakes of Magma");
        
        // Add Description
        TheBasePlanetarySystem.PlanetaryDescription = "Formed by planetesimal collisions in accretion disks (page 332) fusing into a single body, proto-planets have layered interiors and abundant radioactives. Early accretion disks may contain hundreds of protoplanets up to a few thousand kilometres in diameter, reducing in number and increasing in size as collisions continue. Eventually protoplanets become large enough to be classified as dwarf planets or planets; the remainder become asteroids.";
        
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
