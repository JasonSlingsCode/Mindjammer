using UnityEngine;
using System.Collections;


/*
Aspects: The Days Are a Week Long; Too Cold for Comfort.
Stellar Body: F- to G-class main sequence stars; others
possible.
Age: Maturing to Aging.
Orbit: Inner H-Zone to Outer H-Zone.
Size: Small Standard to Standard.
Density: Low Standard to High Standard.
Gravity: Standard.
Day Length: Slow to Rapid.
Atmospheric Pressure: Standard.
Temperature: Cool to Warm.
Liquid: Average to Almost Total.
Seasonality: Low to High.
Biosphere: Transplant, T-Congruent; T-Analogue.
Habitability: Adequate to Benign.
Resources: Plentiful: biosphere, hydrocarbons, metals,
organics, water.
*/
public class GardenWorldStandard : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    
    // Planetary Age restrictions; range is -4 to 4
    private int PlanetaryAgeMinimum = -1;
    private int PlanetaryAgeMaximum = 1;
    
    // Planetary Size restrictions; range is -4 to 4
    private int PlanetarySizeMinimum = -1;
    private int PlanetarySizeMaximum = 0;
    
    // Planetary Density restrictions; range is -4 to 10
    private int PlanetaryDensityMinimum = -1;
    private int PlanetaryDensityMaximum = 1;
    
    // Planetary Gravity restrictions; range is -4 to 10
    private int PlanetaryGravityMinimum = 0;
    private int PlanetaryGravityMaximum = 0;
    
    // Day Length restrictions; range is -5 to 8
    private int PlanetaryDayLengthMininum = -2;
    private int PlanetaryDayLengthMaximum = 2;
    
    // Atmospheric Pressure restrictions; range is -10 to 10
    private int AtmosphericPressureMinimum = -1;
    private int AtmosphericPressureMaximum = 1;
    
    // Surface Temperature restrictions; range is -4 to 7
    private int SurfaceTemperatureMinimum = -1;
    private int SurfaceTemperatureMaximum = 1;
    
    // Surface Liquid Extent restrictions; range is -4 to 4
    private int SirfaceLiquidMinimum = 0;
    private int SurfaceLiquidMaximum = 3;
    
    // Seasonality restrictions; range is -10 to 10
    private int SeasonalityMinimum = -3;
    private int SeasonalityMaximum = 3;
    
    // Habitability restrictions; range is -4 to 4
    private int HabitabilityMinimum = 2;
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

        TheBasePlanetarySystem.Aspects.Add("The Days Are a Week Long");
        TheBasePlanetarySystem.Aspects.Add("Too Cold for Comfort");
        
        // Add Description
        TheBasePlanetarySystem.PlanetaryDescription = "Humans can live on standard garden worlds without difficulty; they’re not exactly “Second Earths”, but they’re close.";
        
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
