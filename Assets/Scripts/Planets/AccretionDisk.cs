using UnityEngine;
using System.Collections;

/*
Aspects: Birth of a Planetary System; Millions of Kilometres of Colliding Rubble.
Stellar Body: Pre-Main Sequence Star, Protostar;
Black Star, Electroweak Star, Stellar Black Hole, White Dwarf.
Age: Extremely Young.
Orbit: Any.
Size: Planetesimal.
Density: Extremely Low to Standard.
Gravity: Very Low or lower.
Day Length: n/a.
Atmospheric Pressure: Very Low or lower.
Temperature: Any.
Liquid: Any.
Seasonality: n/a.
Biosphere: Alternate.
Habitability: Hostile or worse.
Resources: Plentiful: carbons, dispersed silicates,
organics, zanthrium ore; Scarce: water.
*/

public class AccretionDisk : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    
    // Planetary Age restrictions; range is -4 to 4
    private int PlanetaryAgeMinimum = -4;
    private int PlanetaryAgeMaximum = -3;
    
    // Planetary Size restrictions; range is -4 to 4
    private int PlanetarySizeMinimum = -4;
    private int PlanetarySizeMaximum = -4;
    
    // Planetary Density restrictions; range is -4 to 10
    private int PlanetaryDensityMinimum = -4;
    private int PlanetaryDensityMaximum = 0;
    
    // Planetary Gravity restrictions; range is -4 to 10
    private int PlanetaryGravityMinimum = -4;
    private int PlanetaryGravityMaximum = -3;
    
    // Day Length restrictions; range is -5 to 8
    private int PlanetaryDayLengthMininum = -5;
    private int PlanetaryDayLengthMaximum = -5;
    
    // Atmospheric Pressure restrictions; range is -10 to 10
    private int AtmosphericPressureMinimum = -10;
    private int AtmosphericPressureMaximum = -4;
    
    // Surface Temperature restrictions; range is -4 to 7
    private int SurfaceTemperatureMinimum = -4;
    private int SurfaceTemperatureMaximum = 7;
    
    // Surface Liquid Extent restrictions; range is -4 to 4
    private int SirfaceLiquidMinimum = -4;
    private int SurfaceLiquidMaximum = 4;
    
    // Seasonality restrictions; range is -10 to 10
    private int SeasonalityMinimum = -10;
    private int SeasonalityMaximum = -10;
    
    // Habitability restrictions; range is -4 to 4
    private int HabitabilityMinimum = -4;
    private int HabitabilityMaximum = -2;
    
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

        TheBasePlanetarySystem.Aspects.Add("Birth of a Planetary System");
        TheBasePlanetarySystem.Aspects.Add("Millions of Kilometres of Colliding Rubble");
        
        // Add Description
        TheBasePlanetarySystem.PlanetaryDescription = "The disks of debris and gases at the centre of which protostars kindle, and which may eventually form planets, these are active regions filled with collision hazards but rich in resources. They may contain organic molecules like amino acids.";
        
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