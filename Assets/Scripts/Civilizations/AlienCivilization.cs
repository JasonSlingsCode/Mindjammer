using UnityEngine;
using System.Collections;

/*
Example Aspects: Alienation Effect; Bizarre Alien Trade
Goods; Hungry for Information; These People Aren’t Human!
Designation: Alien World; others possible.
Population: Any.
Government: Any.
Societal Dev: Any.
Openness: Any.
Control: Any.
Trade: Any.
Tech: Any.
Starport: Any.
Mindscape: Originally none; any after Rediscovery.
*/

public class AlienCivilization : MonoBehaviour
{
    private RollDice RollTheDice;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    private BaseCivilization TheBaseCivilization;
    
    // Designation restrictions; range is -5 to 3
    private int CivDesignationMinimum = -5;
    private int CivDesignationMaximum = -5;
    
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
    private int CivOpennessMaximum = 5;
    
    // Control Index restrictions; range is -5 to 5
    private int ControlIndexMinimum = -5;
    private int ControlIndexMaximum = 5;
    
    // Trade Index restrictions; range is -5 to 4
    private int TradeIndexMinimum = -5;
    private int TradeIndexMaximum = 4;
    
    // Tech Index restrictions; range is -5 to 5
    private int TechIndexMinimum = -5;
    private int TechIndexMaximum = 5;
    
    // Starport restrictions; range is -5 to 9
    private int StarportMinimum = -5;
    private int StarportMaximum = 9;
    
    // Mindscape restrictions; range is -4 to 4
    private int MindscapeMinimum = -4;
    private int MindscapeMaximum = -4;
    
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
        TheBaseCivilization.Aspects.Add("Alienation Effect");
        TheBaseCivilization.Aspects.Add("Bizarre Alien Trade Goods");
        TheBaseCivilization.Aspects.Add("Hungry for Information");
        TheBaseCivilization.Aspects.Add("These People Aren’t Human!");
        
        // Add Description
        TheBaseCivilization.CivilizationDescription = "A lost colony world remodelled by contact with an alien intelligence in the past, it operates on very different principles. The Chembu homeworld is an example.";
        
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
