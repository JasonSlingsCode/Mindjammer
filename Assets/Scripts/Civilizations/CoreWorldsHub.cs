using UnityEngine;
using System.Collections;

/*
Example Aspects: Public Face and Private Person; Put
Your Foot in Your Mouth; Resource Allocation Matrix; Ritual
Migrations.
Designation: Commonality Member.
Population: Dense or higher.
Government: Commonality-controlled.
Societal Dev: Sentience Coordinated Collective.
Openness: Guarded or higher.
Control: Restricted or higher.
Trade: Extensive or higher.
Tech: T10.
Starport: Octant Hub or higher.
Mindscape: Mindscape Hub or higher.
*/

public class CoreWorldsHub : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    private BaseCivilization TheBaseCivilization;
    
    // Designation restrictions; range is -5 to 3
    private int CivDesignationMinimum = 3;
    private int CivDesignationMaximum = 3;
    
    // Population restrictions; range is -5 to 5
    private int CivPopulationMinimum = 4;
    private int CivPopulationMaximum = 5;
    
    // Government restrictions; range is -5 to 4
    private int CivGovernmentMinimum = 4;
    private int CivGovernmentMaximum = 4;
    
    // Societal Development restrictions; range is -5 to 5
    private int CivSocietalDevMinimum = 5;
    private int CivSocietalDevMaximum = 5;
    
    // Openness restrictions; range is -5 to 5
    private int CivOpennessMinimum = 0;
    private int CivOpennessMaximum = 5;
    
    // Control Index restrictions; range is -5 to 5
    private int ControlIndexMinimum = 3;
    private int ControlIndexMaximum = 5;
    
    // Trade Index restrictions; range is -5 to 4
    private int TradeIndexMinimum = 2;
    private int TradeIndexMaximum = 4;
    
    // Tech Index restrictions; range is -5 to 5
    private int TechIndexMinimum = 5;
    private int TechIndexMaximum = 5;
    
    // Starport restrictions; range is -5 to 9
    private int StarportMinimum = 5;
    private int StarportMaximum = 9;
    
    // Mindscape restrictions; range is -4 to 4
    private int MindscapeMinimum = 2;
    private int MindscapeMaximum = 4;
    
    void Awake()
    {
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = GetComponentInParent<BaseStar>();
        TheBasePlanetarySystem = this.gameObject.GetComponent<BasePlanetarySystem>();
        TheBaseCivilization = this.gameObject.GetComponent<BaseCivilization>();
    }
    
    // Use this for initialization
    void Start()
    {
        this.gameObject.name = this.gameObject.name +" - "+ TheBasePlanetarySystem.CivilizationType; 
        TheBaseCivilization.Aspects.Add("Public Face and Private Person");
        TheBaseCivilization.Aspects.Add("Put Your Foot in Your Mouth");
        TheBaseCivilization.Aspects.Add("Resource Allocation Matrix");
        TheBaseCivilization.Aspects.Add("Ritual Migrations");
        
        // Add Description
        TheBaseCivilization.CivilizationDescription = "A pivotal core world, usually an octant or subsector capital. They may be paradoxically more active and yet more controlled than other core worlds.";
        
        AddDesignation();
        AddPopulation();
        AddGovernment();
        AddSocietalDevelopment();
        AddOpenness();
        AddControlIndex();
        AddTradeIndex();
        AddEmbargo();
        AddTechIndex();
        AddStarport();
        AddMindscape();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void AddDesignation()
    {
        int Roll = RollTheDice.RollFourDice();
        if (Roll < CivDesignationMinimum)
            Roll = CivDesignationMinimum;
        if (Roll > CivDesignationMaximum)
            Roll = CivDesignationMaximum;
        TheBaseCivilization.DesignationValue = Roll;
        TheBaseCivilization.FindDesignation();
    }
    
    void AddPopulation()
    {
        int Roll = RollTheDice.RollFourDice();
        Roll += TheBasePlanetarySystem.HabitabilityValue;
        if (Roll < CivPopulationMinimum)
            Roll = CivPopulationMinimum;
        if (Roll > CivPopulationMaximum)
            Roll = CivPopulationMaximum;
        TheBaseCivilization.PopulationValue = Roll;
        TheBaseCivilization.FindPopulation();
    }
    
    void AddGovernment()
    {
        TheBaseCivilization.GovernmentMin = CivGovernmentMinimum;
        TheBaseCivilization.GovernmentMax = CivGovernmentMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.GovernmentValue = Roll;
        TheBaseCivilization.FindGovernment();
    }
    
    void AddSocietalDevelopment()
    {
        TheBaseCivilization.SocietalDevMin = CivSocietalDevMinimum;
        TheBaseCivilization.SocietalDevMax = CivSocietalDevMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.SocietalDevValue = Roll;
        TheBaseCivilization.FindSocietalDevelopment();
    }
    
    void AddOpenness()
    {
        TheBaseCivilization.OpennessMin = CivOpennessMinimum;
        TheBaseCivilization.OpennessMax = CivOpennessMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.OpennessValue = Roll;
        TheBaseCivilization.FindOpenness();
    }
    
    void AddControlIndex()
    {
        TheBaseCivilization.ControlIndexMin = ControlIndexMinimum;
        TheBaseCivilization.ControlIndexMax = ControlIndexMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.ControlIndexValue = Roll;
        TheBaseCivilization.FindControlIndex();
    }
    
    void AddTradeIndex()
    {
        TheBaseCivilization.TradeIndexMin = TradeIndexMinimum;
        TheBaseCivilization.TradeIndexMax = TradeIndexMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.TradeIndexValue = Roll;
        TheBaseCivilization.FindTradeIndex();
    }
    
    void AddEmbargo()
    {
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.EmbargoValue = Roll;
        TheBaseCivilization.FindEmbargo();
    }
    
    void AddTechIndex()
    {
        TheBaseCivilization.TechIndexMin = TechIndexMinimum;
        TheBaseCivilization.TechIndexMax = TechIndexMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.TechIndexValue = Roll;
        TheBaseCivilization.FindTechIndex();
    }
    
    void AddStarport()
    {
        TheBaseCivilization.StarportMin = StarportMinimum;
        TheBaseCivilization.StarportMax = StarportMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.StarportValue = Roll;
        TheBaseCivilization.FindStarport();
    }
    
    void AddMindscape()
    {
        TheBaseCivilization.MindscapeMin = MindscapeMinimum;
        TheBaseCivilization.MindscapeMax = MindscapeMaximum;
        int Roll = RollTheDice.RollFourDice();
        TheBaseCivilization.MindscapeValue += Roll;
        TheBaseCivilization.FindMindscape();
    }
}
