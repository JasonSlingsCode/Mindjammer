using UnityEngine;
using System.Collections;

/*
Example Aspects: Desperate Need of Food and Medicine;
Outside Rescue Plan; Riots and Scapegoats; The Doom Trade.
Designation: Commonality Aligned or lower.
Population: Any.
Government: Any.
Societal Dev: Any.
Openness: Self-centred or lower.
Control: Any.
Trade: Limited or lower, except passengers (page 446).
Tech: Any.
Starport: D-class or lower.
Mindscape: Any.
*/

public class Failing : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    private BaseCivilization TheBaseCivilization;
    
    // Designation restrictions; range is -5 to 3
    private int CivDesignationMinimum = -5;
    private int CivDesignationMaximum = 0;
    
    // Population restrictions; range is -5 to 5
    private int CivPopulationMinimum = -5;
    private int CivPopulationMaximum = 5;
    
    // Government restrictions; range is -5 to 4
    private int CivGovernmentMinimum = -5;
    private int CivGovernmentMaximum = 4;
    
    // Societal Development restrictions; range is -5 to 5
    private int CivSocietalDevMinimum = -5;
    private int CivSocietalDevMaximum = 5;
    
    // Openness restrictions; range is -5 to 5
    private int CivOpennessMinimum = -5;
    private int CivOpennessMaximum = -2;
    
    // Control Index restrictions; range is -5 to 5
    private int ControlIndexMinimum = -5;
    private int ControlIndexMaximum = 5;
    
    // Trade Index restrictions; range is -5 to 4
    private int TradeIndexMinimum = -5;
    private int TradeIndexMaximum = -2;
    
    // Tech Index restrictions; range is -5 to 5
    private int TechIndexMinimum = -5;
    private int TechIndexMaximum = 5;
    
    // Starport restrictions; range is -5 to 9
    private int StarportMinimum = -5;
    private int StarportMaximum = 2;
    
    // Mindscape restrictions; range is -4 to 4
    private int MindscapeMinimum = -4;
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
        TheBaseCivilization.Aspects.Add("Desperate Need of Food and Medicine");
        TheBaseCivilization.Aspects.Add("Outside Rescue Plan");
        TheBaseCivilization.Aspects.Add("Riots and Scapegoats");
        TheBaseCivilization.Aspects.Add("The Doom Trade");
        
        // Add Description
        TheBaseCivilization.CivilizationDescription = "A failing world is on a downward spiral to extinction. This may be due to overpopulation, underpopulation, adverse planetary conditions, disease, economic or societal collapse, or natural disaster; it may be happening swiftly or slowly. Failing worlds in the Commonality are treated or evacuated; those outside may be desperate for a solution.";
        
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
