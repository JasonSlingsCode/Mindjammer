// Script by Jason Miller
// psyaxismundi@gmail.com
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCivilization : MonoBehaviour
{
    [Header("Civilization Type")]
    public string
        CivilizationType;
    public string CivilizationDescription;
    [Header("Aspects")]
    public List<string>
        Aspects;
    [Header("Designation")]
    public string
        Designation;
    public int DesignationValue;
    private string[] Designations = new string[]
    {
        "Lost Colony / Alien World",
        "Independent: No Embassy",
        "Commonality Outpost",
        "Independent: Embassy",
        "Commonality Quarantine",
        "Commonality Aligned",
        "Culture World",
        "Commonality Autonomous",
        "Commonality Member"
    };
    [Header("Population")]
    public string
        Population;
    public int PopulationValue;
    public string Numbers;
    private string[] Populations = new string[]
    {
        "Negligible",
        "Sparse",
        "Very Low",
        "Low",
        "Low Standard",
        "Standard",
        "High Standard",
        "High",
        "Very High",
        "Dense",
        "Hyperdense"
    };
    private string[] PopulationNumbers = new string[]
    {
        "Hundreds",
        "Thousands",
        "Tens of Thousands",
        "Hundreds of Thousands",
        "Millions",
        "Tens of Millions",
        "Hundreds of Millions",
        "Billions",
        "Tens of Billions",
        "Hundreds of Billions",
        "Trillions"
    };
    [Header("Government")]
    public string
        Government;
    public int GovernmentValue;
    private string[] Governments = new string[]
    {
        "Anarchy",
        "Feudal",
        "Monarchy",
        "Representative",
        "Mercantilist Oligarchy",
        "Dictatorship",
        "Oligarchy",
        "Corporacy",
        "Corporacy",
        "Commonality-Controlled (Oligarchy)"
    };
    [Header("Societal Development")]
    public string
        SocietalDevelopment;
    public int SocietalDevValue;
    private string[] SocietalDevs = new string[]
    {
        "Hunter-Gatherer",
        "Small-Scale Communities",
        "Labour Service",
        "Confiscation",
        "Taxation and Representation",
        "Early Redistributive Model",
        "Consensus Redistribution Model",
        "Selfless Redistribution Model",
        "Widespread Intrusive Collective",
        "Widespread Unintrusive Collective",
        "Sentience Coordinated Collective"
    };
    [Header("Openness")]
    public string
        Openness;
    public int OpennessValue;
    private string[] Opennesses = new string[]
    {
        "Closed",
        "Conservative",
        "Resistant",
        "Self-Centered",
        "Equivocal",
        "Guarded",
        "Self-Critical",
        "Self-Improving",
        "Outgoing",
        "Constant Change",
        "Open"
    };
    [Header("Control Index")]
    public string
        ControlIndex;
    public int ControlIndexValue;
    private string[] ControlIndexes = new string[]
    {
        "No Control",
        "Mass Destruction",
        "Personal",
        "Property",
        "Speech",
        "Laissez-Faire",
        "Influenced",
        "Surveilled",
        "Restricted",
        "Repressive",
        "Total"
    };
    [Header("Trade Index")]
    public string
        TradeIndex;
    public int TradeIndexValue;
    private string[] TradeIndexes = new string[]
    {
        "No Trade",
        "Inconsequential",
        "Very Limited",
        "Limited",
        "Low Moderate",
        "Moderate",
        "High Moderate",
        "Extensive",
        "Very Extensive",
        "Ubiquitous"
    };
    [Header("Embargo")]
    public string
        Embargo;
    public int EmbargoValue;
    [Header("Tech Index")]
    public string
        TechIndex;
    public int TechIndexValue;
    private string[] TechIndexes = new string[]
    {
        "T0 - Post-Animal",
        "T1 - Stone Age",
        "T2 - Metal Age",
        "T3 - Age of Enlightenment",
        "T4 - Industrial Age",
        "T5 - Computer Age",
        "T6 - Age of Genurgy",
        "T7 - First Age of Space",
        "T8 - Age of Ubiquitous Intelligence",
        "T9 - Second Age of Space",
        "T10 - Age of 3-Space"
    };
    [Header("Starport")]
    public string
        StarportClass;
    public int StarportValue;
    private string[] StarportFacilities = new string[]
    {
        "X",
        "Uncategorized Facility",
        "Uncategorized Facility",
        "Uncategorized Facility",
        "Uncategorized Facility",
        "Uncategorized Facility",
        "E-Class Starport",
        "D-Class Starport",
        "C-Class Starport",
        "B-Class Starport",
        "A-Class Octant Hub",
        "A2-Class Subsector Hub",
        "A3-Class Sector Hub",
        "A4-Class Core Hub",
        "A5-Class Manhome Terminus"
    };
    [Header("Mindscape")]
    public string
        Mindscape;
    public int MindscapeValue;
    private string[] MindscapeFacilities = new string[]
    {
        "Temple of Universal Mind",
        "Local Node",
        "Global Mindscape",
        "Global Mindscape",
        "Systemwide Mindscape",
        "Systemwide Mindscape",
        "Mindscape Hub",
        "Mindscape Hub",
        "Mindscape Nexus"
    };

    // private variables
    private RollDice RollTheDice;
    private int TheSliderSetting;
    private BaseStar TheBaseStar;
    private BasePlanetarySystem TheBasePlanetarySystem;
    private int GovernmentTypeModifier;
    private int SocietalDevtModifier;
    private int OpennessModifier;
    private int StarportModifier;
    private int ControlIndexModifier;
    private int TradeIndexModifier;
    private int TechIndexModifier;
    private int EmbargoModifier;
    private int MindscapeModifier;
    [HideInInspector]
    public int
        GovernmentMin;
    [HideInInspector]
    public int
        GovernmentMax;
    [HideInInspector]
    public int
        SocietalDevMin;
    [HideInInspector]
    public int
        SocietalDevMax;
    [HideInInspector]
    public int
        OpennessMin;
    [HideInInspector]
    public int
        OpennessMax;
    [HideInInspector]
    public int
        ControlIndexMin;
    [HideInInspector]
    public int
        ControlIndexMax;
    [HideInInspector]
    public int
        TradeIndexMin;
    [HideInInspector]
    public int
        TradeIndexMax;
    [HideInInspector]
    public int
        TechIndexMin;
    [HideInInspector]
    public int
        TechIndexMax;
    [HideInInspector]
    public int
        StarportMin;
    [HideInInspector]
    public int
        StarportMax;
    [HideInInspector]
    public int
        MindscapeMin;
    [HideInInspector]
    public int
        MindscapeMax;

    void Awake()
    {

        Aspects = new List<string>();
        RollTheDice = GameObject.Find("Dice").GetComponent<RollDice>();
        TheBaseStar = GetComponentInParent<BaseStar>();
        TheBasePlanetarySystem = this.gameObject.GetComponent<BasePlanetarySystem>();
        TheSliderSetting = Mathf.FloorToInt(GameObject.Find("Slider").GetComponent<SliderController>().TheValue);
    }

    // Use this for initialization
    void Start()
    {
        CivilizationType = this.gameObject.GetComponent<BasePlanetarySystem>().CivilizationType;
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void FindDesignation()
    {
        int SliderMod = TheSliderSetting;
        switch (TheSliderSetting)
        {
            case 0:                             // The Core Worlds
                SliderMod = 4;
                break;
            case 1:                             // Commonality Space
                SliderMod = 2;
                break;
            case 2:                             // The Fringe Worlds
                SliderMod = 0;
                break;
            case 3:                             // The Outer Worlds
                SliderMod = -4;
                break;
            default:
                break;
        }
        DesignationValue += SliderMod;
        int x = DesignationValue;
        if (x < -5)
            x = -5;
        if (x > 3)
            x = 3;
        switch (x)
        {
            case -5:    // Lost Colony / Alien World
                Designation = Designations [x + 5];
                GovernmentTypeModifier -= 3;
                SocietalDevtModifier --;
                StarportModifier -= 3;
                break;
            case -4:    // Independent: No Embassy
                Designation = Designations [x + 5];
                GovernmentTypeModifier -= 3;
                StarportModifier -= 2;
                break;
            case -3:    // Commonality Outpost
                Designation = Designations [x + 5];
                GovernmentTypeModifier += 2;
                OpennessModifier -= 3;
                StarportModifier ++;
                break;
            case -2:    // Independent: Embassy
                Designation = Designations [x + 5];
                GovernmentTypeModifier -= 3;
                OpennessModifier --;
                break;
            case -1:    // Commonality Quarantine
                Designation = Designations [x + 5];
                GovernmentTypeModifier -= 2;
                SocietalDevtModifier ++;
                OpennessModifier ++;
                StarportModifier ++;
                break;
            case 0:     // Commonality Aligned
                Designation = Designations [x + 5];
                GovernmentTypeModifier -= 2;
                SocietalDevtModifier -= 2;
                OpennessModifier --;
                StarportModifier ++;
                break;
            case 1:     // Culture World
                Designation = Designations [x + 5];
                OpennessModifier -= 3;
                break;
            case 2:     // Commonality Autonomous
                Designation = Designations [x + 5];
                GovernmentTypeModifier += 3;
                SocietalDevtModifier += 2;
                OpennessModifier -= 2;
                StarportModifier ++;
                break;
            case 3:     // Commonality Member
                Designation = Designations [x + 5];
                GovernmentTypeModifier += 5;
                SocietalDevtModifier += 4;
                OpennessModifier --;
                StarportModifier ++;
                break;
            default:
                break;
        }
    }

    public void FindPopulation()
    {
        int x = PopulationValue;
        switch (x)
        {
            case -5:    // Negligible
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier -= 2;
                TradeIndexModifier -= 4;
                break;
            case -4:    // Sparse
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier --;
                TradeIndexModifier -= 3;
                break;
            case -3:    // Very Low
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier --;
                TradeIndexModifier -= 2;
                break;
            case -2:    // Low
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                TradeIndexModifier --;
                break;
            case -1:    // Low Standard
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                break;
            case 0:     // Standard
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                break;
            case 1:     // High Standard
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                break;
            case 2:     // High
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier ++;
                TradeIndexModifier ++;
                break;
            case 3:     // Very High
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier ++;
                TradeIndexModifier += 2;
                break;
            case 4:     // Dense
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier ++;
                TradeIndexModifier += 3;
                break;
            case 5:     // Hyperdense
                Population = Populations [x + 5];
                Numbers = PopulationNumbers [x + 5];
                ControlIndexModifier += 2;
                TradeIndexModifier += 4;
                break;
            default:
                break;
        }
    }

    public void FindGovernment()
    {
        GovernmentValue += GovernmentTypeModifier;
        if (GovernmentValue < GovernmentMin)
            GovernmentValue = GovernmentMin;
        if (GovernmentValue > GovernmentMax)
            GovernmentValue = GovernmentMax;
        int x = GovernmentValue;
        if (x < -5)
            x = -5;
        if (x > 4)
            x = 4;
        switch (x)
        {
            case -5:    // Anarchy
                Government = Governments [x + 5];
                SocietalDevtModifier --;
                ControlIndexModifier -= 4;
                TradeIndexModifier ++;
                break;
            case -4:    // Feudal
                Government = Governments [x + 5];
                OpennessModifier -= 3;
                ControlIndexModifier += 2;
                TradeIndexModifier -= 3;
                break;
            case -3:    // Monarchy
                Government = Governments [x + 5];
                OpennessModifier -= 4;
                ControlIndexModifier += 2;
                TradeIndexModifier --;
                break;
            case -2:    // Representative
                Government = Governments [x + 5];
                OpennessModifier --;
                TradeIndexModifier += 2;
                break;
            case -1:    // Mercantilist Oligarchy
                Government = Governments [x + 5];
                SocietalDevtModifier ++;
                OpennessModifier -= 2;
                ControlIndexModifier ++;
                TradeIndexModifier += 4;
                break;
            case 0:     // Dictatorship
                Government = Governments [x + 5];
                SocietalDevtModifier += 2;
                OpennessModifier -= 3;
                ControlIndexModifier += 3;
                TradeIndexModifier ++;
                break;
            case 1:     // Oligarchy
                Government = Governments [x + 5];
                SocietalDevtModifier += 2;
                OpennessModifier --;
                TradeIndexModifier ++;
                break;
            case 2:     // Corporacy
                Government = Governments [x + 5];
                SocietalDevtModifier += 2;
                OpennessModifier -= 2;
                ControlIndexModifier ++;
                TradeIndexModifier += 4;
                break;
            case 3:     // Corporacy
                Government = Governments [x + 5];
                SocietalDevtModifier += 2;
                OpennessModifier -= 2;
                ControlIndexModifier ++;
                TradeIndexModifier += 4;
                break;
            case 4:     // Commonality-Controlled (Oligarchy)
                Government = Governments [x + 5];
                SocietalDevtModifier += 5;
                OpennessModifier -= 2;
                ControlIndexModifier ++;
                TradeIndexModifier -= 2;
                break;
            default:
                break;
        }
    }

    public void FindSocietalDevelopment()
    {
        SocietalDevValue += SocietalDevtModifier;
        if (SocietalDevValue < SocietalDevMin)
            SocietalDevValue = SocietalDevMin;
        if (SocietalDevValue > SocietalDevMax)
            SocietalDevValue = SocietalDevMax;
        int x = SocietalDevValue;
        if (x < -5)
            x = -5;
        if (x > 5)
            x = 5;
        switch (x)
        {
            case -5:    // Hunter-Gatherer
                SocietalDevelopment = SocietalDevs [x + 5];
                ControlIndexModifier -= 4;
                TradeIndexModifier -= 4;
                TechIndexModifier -= 4;
                EmbargoModifier += 3;
                break;
            case -4:    // Small-Scale Communities
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier -= 2;
                ControlIndexModifier -= 3;
                TradeIndexModifier -= 4;
                TechIndexModifier -= 3;
                EmbargoModifier += 2;
                break;
            case -3:    // Labour Service
                SocietalDevelopment = SocietalDevs [x + 5];
                TradeIndexModifier -= 3;
                TechIndexModifier -= 2;
                EmbargoModifier ++;
                break;
            case -2:    // Confiscation
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 2;
                ControlIndexModifier += 2;
                TradeIndexModifier -= 3;
                TechIndexModifier --;
                EmbargoModifier ++;
                break;
            case -1:    // Taxation and Representation
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 2;
                ControlIndexModifier ++;
                TradeIndexModifier ++;
                break;
            case 0:     // Early Redistributive Model
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier ++;
                ControlIndexModifier ++;
                TradeIndexModifier ++;
                TechIndexModifier ++;
                break;
            case 1:     // Consensus Redistribution Model
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 2;
                ControlIndexModifier ++;
                TradeIndexModifier ++;
                TechIndexModifier += 2;
                EmbargoModifier --;
                break;
            case 2:     // Selfless Redistribution Model
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 5;
                ControlIndexModifier += 2;
                TradeIndexModifier ++;
                TechIndexModifier += 2;
                EmbargoModifier --;
                break;
            case 3:     // Widespread Intrusive Collective
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 4;
                ControlIndexModifier += 3;
                TradeIndexModifier --;
                TechIndexModifier ++;
                EmbargoModifier --;
                break;
            case 4:     // Widespread Unintrusive Collective
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 4;
                TradeIndexModifier ++;
                TechIndexModifier += 2;
                EmbargoModifier -= 2;
                break;
            case 5:     // Sentience Coordinated Collective
                SocietalDevelopment = SocietalDevs [x + 5];
                OpennessModifier += 3;
                ControlIndexModifier ++;
                TechIndexModifier += 4; // minimum T8 Tech Index
                EmbargoModifier -= 3;
                break;
            default:
                break;
        }
    }

    public void FindOpenness()
    {
        OpennessValue += OpennessModifier;
        if (OpennessValue < OpennessMin)
            OpennessValue = OpennessMin;
        if (OpennessValue > OpennessMax)
            OpennessValue = OpennessMax;
        int x = OpennessValue;
        if (x < -5)
            x = -5;
        if (x > 5)
            x = 5;
        switch (x)
        {
            case -5:    // Closed
                Openness = Opennesses [x + 5];
                TradeIndexModifier -= 5;
                TechIndexModifier -= 3;
                StarportModifier -= 3;
                MindscapeModifier -= 4;
                break;
            case -4:    // Conservative
                Openness = Opennesses [x + 5];
                TradeIndexModifier -= 3;
                TechIndexModifier -= 2;
                StarportModifier -= 2;
                MindscapeModifier -= 3;
                break;
            case -3:    // Resistant
                Openness = Opennesses [x + 5];
                TradeIndexModifier -= 2;
                TechIndexModifier --;
                MindscapeModifier -= 2;
                break;
            case -2:    // Self-Centered
                Openness = Opennesses [x + 5];
                TradeIndexModifier --;
                MindscapeModifier --;
                break;
            case -1:    // Equivocal
                Openness = Opennesses [x + 5];
                break;
            case 0:     // Guarded
                Openness = Opennesses [x + 5];
                TradeIndexModifier ++;
                break;
            case 1:     // Self-Critical
                Openness = Opennesses [x + 5];
                TradeIndexModifier += 2;
                break;
            case 2:     // Self-Improving
                Openness = Opennesses [x + 5];
                TradeIndexModifier += 2;
                TechIndexModifier ++;
                StarportModifier ++;
                break;
            case 3:     // Outgoing
                Openness = Opennesses [x + 5];
                TradeIndexModifier += 3;
                TechIndexModifier ++;
                StarportModifier ++;
                break;
            case 4:     // Constant Change
                Openness = Opennesses [x + 5];
                TradeIndexModifier += 3;
                TechIndexModifier += 2;
                StarportModifier ++;
                break;
            case 5:     // Open
                Openness = Opennesses [x + 5];
                TradeIndexModifier += 5;
                TechIndexModifier += 3;
                StarportModifier ++;
                break;
            default:
                break;
        }
    }

    public void FindControlIndex()
    {
        ControlIndexValue += ControlIndexModifier;
        if (ControlIndexValue < ControlIndexMin)
            ControlIndexValue = ControlIndexMin;
        if (ControlIndexValue > ControlIndexMax)
            ControlIndexValue = ControlIndexMax;
        int x = ControlIndexValue;
        if (x < -5)
            x = -5;
        if (x > 5)
            x = 5;
        switch (x)
        {
            case -5:    // No Control
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier ++;
                EmbargoModifier += 3;
                break;
            case -4:    // Mass Destruction
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier += 2;
                EmbargoModifier += 2;
                break;
            case -3:    // Personal
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier += 3;
                EmbargoModifier ++;
                break;
            case -2:    // Property
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier += 2;
                break;
            case -1:    // Speech
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier ++;
                EmbargoModifier --;
                break;
            case 0:     // Laissez-Faire
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier += 3;
                EmbargoModifier --;
                break;
            case 1:     // Influenced
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier ++;
                EmbargoModifier --;
                break;
            case 2:     // Surveilled
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier --;
                break;
            case 3:     // Restricted
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier -= 3;
                break;
            case 4:     // Repressive
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier -= 5;
                break;
            case 5:     // Total
                ControlIndex = ControlIndexes [x + 5];
                TradeIndexModifier -= 6;
                break;
            default:
                break;
        }
    }

    public void FindTradeIndex()
    {
        TradeIndexValue += TradeIndexModifier;
        if (TradeIndexValue < TradeIndexMin)
            TradeIndexValue = TradeIndexMin;
        if (TradeIndexValue > TradeIndexMax)
            TradeIndexValue = TradeIndexMax;
        int x = TradeIndexValue;
        if (x < -5)
            x = -5;
        if (x > 4)
            x = 4;
        switch (x)
        {
            case -5:    // No Trade
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier -= 3;
                break;
            case -4:    // Inconsequential
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier -= 2;
                break;
            case -3:    // Very Limited
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier --;
                break;
            case -2:    // Limited
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier --;
                break;
            case -1:    // Low Moderate
                TradeIndex = TradeIndexes [x + 5];
                break;
            case 0:     // Moderate
                TradeIndex = TradeIndexes [x + 5];
                break;
            case 1:     // High Moderate
                TradeIndex = TradeIndexes [x + 5];
                break;
            case 2:     // Extensive
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier ++;
                break;
            case 3:     // Very Extensive
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier ++;
                break;
            case 4:     // Ubiquitous
                TradeIndex = TradeIndexes [x + 5];
                StarportModifier += 2;
                break;
            default:
                break;
        }
    }
    
    public void FindEmbargo()
    {
        EmbargoValue += EmbargoModifier;
        if (EmbargoValue <= 0)
        {
            Embargo = "No Embargo";
            EmbargoValue = 0;
        }
        if (EmbargoValue > 0)
        {
            Embargo = "Current Embargo";
            TradeIndexValue -= EmbargoValue;
            if (TradeIndexValue < TradeIndexMin)
                TradeIndexValue = TradeIndexMin;
            if (TradeIndexValue > TradeIndexMax)
                TradeIndexValue = TradeIndexMax;
            if (Designation == "Commonality Quarantine")
            {
                TradeIndexValue -= 5;
                TradeIndexMin -= 5;
            }
            if (TradeIndexValue < TradeIndexMin)
                TradeIndexValue = TradeIndexMin;
            if (TradeIndexValue > TradeIndexMax)
                TradeIndexValue = TradeIndexMax;
            int x = TradeIndexValue;
            if (x < -5)
                x = -5;
            if (x > 4)
                x = 4;
            switch (x)
            {
                case -5:    // No Trade
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier -= 3;
                    break;
                case -4:    // Inconsequential
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier -= 2;
                    break;
                case -3:    // Very Limited
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier --;
                    break;
                case -2:    // Limited
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier --;
                    break;
                case -1:    // Low Moderate
                    TradeIndex = TradeIndexes [x + 5];
                    break;
                case 0:     // Moderate
                    TradeIndex = TradeIndexes [x + 5];
                    break;
                case 1:     // High Moderate
                    TradeIndex = TradeIndexes [x + 5];
                    break;
                case 2:     // Extensive
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier ++;
                    break;
                case 3:     // Very Extensive
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier ++;
                    break;
                case 4:     // Ubiquitous
                    TradeIndex = TradeIndexes [x + 5];
                    StarportModifier += 2;
                    break;
                default:
                    break;
            }
        }
    }

    public void FindTechIndex()
    {
        TechIndexValue += TechIndexModifier;
        int SliderMod = TheSliderSetting;
        switch (TheSliderSetting)
        {
            case 0:                             // The Core Worlds
                SliderMod = 5;
                break;
            case 1:                             // Commonality Space
                SliderMod = 4;
                break;
            case 2:                             // The Fringe Worlds
                SliderMod = 4;
                break;
            case 3:                             // The Outer Worlds
                SliderMod = 3;
                break;
            default:
                break;
        }
        TechIndexMax = Mathf.Min(SliderMod, TechIndexMax);
        if (SocietalDevelopment == "Sentience Coordinated Collective")
        {
            TechIndexMin = 3;
        }
        if (TechIndexValue < TechIndexMin)
            TechIndexValue = TechIndexMin;
        if (TechIndexValue > TechIndexMax)
            TechIndexValue = TechIndexMax;
        int x = TechIndexValue;
        if (x < -5)
            x = -5;
        if (x > 5)
            x = 5;
        switch (x)
        {
            case -5:    // T0 - Post-Animal
                TechIndex = TechIndexes [x + 5];
                break;
            case -4:    // T1 - Stone Age
                TechIndex = TechIndexes [x + 5];
                break;
            case -3:    // T2 - Metal Age
                TechIndex = TechIndexes [x + 5];
                break;
            case -2:    // T3 - Age of Enlightenment
                TechIndex = TechIndexes [x + 5];
                break;
            case -1:    // T4 - Industrial Age
                TechIndex = TechIndexes [x + 5];
                break;
            case 0:     // T5 - Computer Age
                TechIndex = TechIndexes [x + 5];
                break;
            case 1:     // T6 - Age of Genurgy
                TechIndex = TechIndexes [x + 5];
                break;
            case 2:     // T7 - First Age of Space
                TechIndex = TechIndexes [x + 5];
                break;
            case 3:     // T8 - Age of Ubiquitous Intelligence
                TechIndex = TechIndexes [x + 5];
                break;
            case 4:     // T9 - Second Age of Space
                TechIndex = TechIndexes [x + 5];
                break;
            case 5:     // T10 - Age of 3-Space
                TechIndex = TechIndexes [x + 5];
                break;
            default:
                break;
        }
    }

    public void FindStarport()
    {
        StarportValue = 0;
        StarportValue += StarportModifier;
        if (StarportValue < StarportMin)
            StarportValue = StarportMin;
        if (StarportValue > StarportMax)
            StarportValue = StarportMax;
        int x = StarportValue;
        if (x < -5)
            x = -5;
        if (x > 9)
            x = 9;
        switch (x)
        {
            case -5:    // X
                StarportClass = StarportFacilities [x + 5];
                // No Mindscape
                break;
            case -4:    // Uncategorized Facility
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue -= 3;
                break;
            case -3:    // Uncategorized Facility / S1 Seed Node
                StarportClass = StarportFacilities [x + 5];
                if (CivilizationType == "Synthetic Colony")
                {
                    StarportClass = "S1 Seed Node";
                }
                MindscapeValue -= 2;
                break;
            case -2:    // Uncategorized Facility / S2 Seed Network
                StarportClass = StarportFacilities [x + 5];
                if (CivilizationType == "Synthetic Colony")
                {
                    StarportClass = "S2 Seed Network";
                }
                MindscapeValue --;
                break;
            case -1:    // Uncategorized Facility / S3 Orbital Multiplicity
                StarportClass = StarportFacilities [x + 5];
                if (CivilizationType == "Synthetic Colony")
                {
                    StarportClass = "S3 Orbital Multiplicity";
                }
                break;
            case -0:    // Uncategorized Facility / S4 Synthport
                StarportClass = StarportFacilities [x + 5];
                if (CivilizationType == "Synthetic Colony")
                {
                    StarportClass = "S4 Synthport";
                }
                MindscapeValue ++;
                break;
            case 1:     // E-Class Starport
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue -= 2;
                break;
            case 2:     // D-Class Starport
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue -= 1;
                break;
            case 3:     // C-Class Starport
                StarportClass = StarportFacilities [x + 5];
                break;
            case 4:     // B-Class Starport
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue ++;
                break;
            case 5:     // A-Class Octant Hub
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue += 2;
                break;
            case 6:     // A2-Class Subsector Hub
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue += 3;
                break;
            case 7:     // A3-Class Sector Hub
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue += 4;
                break;
            case 8:     // A4-Class Core Hub
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue += 4;
                break;
            case 9:     // A5-Class Manhome Terminus
                StarportClass = StarportFacilities [x + 5];
                MindscapeValue += 4;
                break;
            default:
                break;
        }
    }

    public void FindMindscape()
    {
        MindscapeValue += MindscapeModifier;
        if (MindscapeValue < MindscapeMin)
            MindscapeValue = MindscapeMin;
        if (MindscapeValue > MindscapeMax)
            MindscapeValue = MindscapeMax;
        int x = MindscapeValue;
        if (x < -4)
            x = -4;
        if (x > 4)
            x = 4;
        switch (x)
        {
            case -4:    // Temple of Universal Mind
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case -3:    // Local Node
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case -2:    // Global Mindscape
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case -1:    // Global Mindscape
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case 0:     // Systemwide Mindscape
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case 1:     // Systemwide Mindscape
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case 2:     // Mindscape Hub
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case 3:     // Mindscape Hub
                Mindscape = MindscapeFacilities[x + 4];
                break;
            case 4:     // Mindscape Nexus
                Mindscape = MindscapeFacilities[x + 4];
                break;
            default:
                break;
        }
    }
}

