// Script by Jason Miller
// psyaxismundi@gmail.com
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SystemGenerator : MonoBehaviour
{
    public GameObject Target;
    public RollDice RollTheDice;
    private bool StarGen;
    private bool SystemFound;
    private bool PreStellarObject = false;
    private bool Star = false;
    private bool PostStellarObject = false;
    private bool ExoticStellarObject = false;
    private bool SpectralClassDetermined = false;
    public int StarCount = 0;
    public List<GameObject> StarArray;
    public bool SPRITES____________________;
    public Sprite StarSprite01;
    public Sprite StarSprite02;
    public Sprite StarSprite03;
    public Sprite StarSprite04;
    public Sprite StarSprite05;
    public Sprite StarSprite06;
    public bool MATERIALS___________________;
    public bool CONTROLS___________________;
    public Toggle HeavyDistribution;
    private Vector3 StarCoordinates;
    private Vector3 Grid;
    public string[] StellarBodyTypes;
    public string[] SpectralClasses;
    private bool CalculateScriptAdded;

    // HII variables
    float HIIBaseX;
    float HIIBaseY;
    float HIIBaseZ;

    // Molecular Cloud variables
    float MolecularCloudBaseX;
    float MolecularCloudBaseY;
    float MolecularCloudBaseZ;

    void Start()
    {
        StarCount = 0;
        StarCoordinates = new Vector3();
        Grid = new Vector3();
        StarArray = new List<GameObject>();

        StellarBodyTypes = new string[]
        {
            "Interstellar Cloud",
            "H II Region",
            "Molecular Cloud",
            "Protostar",
            "Eruptive Variable",
            "Hot Subdwarf",
            "Pre-Main Sequence",
            "Cool Subdwarf",
            "Substellar Object",
            "Main Sequence Star",
            "Subgiant",
            "Giant",
            "Supergiant",
            "Stellar Core",
            "Collapsing Star",
            "Planetary Nebula",
            "White Dwarf",
            "Neutron Star",
            "Electroweak Star",
            "Stellar Black Hole",
            "Dark Matter Star",
            "Asymptotic Giant",
            "Pulsating Variable",
            "Black Star"
        };

        SpectralClasses = new string[]
        {
            "O",
            "B",
            "A",
            "F",
            "G",
            "K",
            "M",
            "S",
            "C",
            "L",
            "T",
            "Y"
        };
    }

    public void StartSystemGeneration()
    {
        StarCount = 0;

        if (StarGen)
        {
            GameObject[] StarsToKill;
            StarsToKill = GameObject.FindGameObjectsWithTag("BasicStar");
            for (var i = 0; i < StarsToKill.Length; i++)
            {
                Destroy(StarsToKill [i]);
                StarCount = 0;
            }
            StarGen = !StarGen;
        }
        AddStars();
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void AddStars()
    {
        StarCount = 0;

        Grid.x = 0;
        Grid.y = 0;
        Grid.z = 0;

        StarCoordinates.x = 0;
        StarCoordinates.y = 0;
        StarCoordinates.z = 0;

        StarArray = new List<GameObject>();

        while (Grid.z > -100)
        {
            while (Grid.x < 100)
            {
                SystemFound = false;
                // check to see if a system is present or not
                int x = RollTheDice.RollOneDie();
                if (HeavyDistribution.isOn)
                {
                    if (x == -1 || x == 1)
                    {
                        SystemFound = true;
                    }
                } 
                if (!HeavyDistribution.isOn)
                {
                    if (x == 1)
                    {
                        SystemFound = true;
                    }
                }

                DetermineSystemExistence();

                // Move to next grid space
                Grid.x = Grid.x + 10;
                StarCoordinates = Grid;
            }

            // Move to next row
            Grid.z = Grid.z - 10;
            StarCoordinates = Grid;
            Grid.x = 0;
            StarCoordinates = Grid;
        }

        StarGen = true;
    } // End AddStars()

    void DetermineSystemExistence()
    {
        if (SystemFound)
        {
            CreateASystem();
        }
    }
    
    void CreateASystem()
    {
        // randomize the system's x, y, z coodinate origins
        StarCoordinates.x = StarCoordinates.x - RollTheDice.RollFourDice();
        StarCoordinates.y = (RollTheDice.RollFourDice() * 10) + Random.Range(-5, 6);
        StarCoordinates.z = StarCoordinates.z - RollTheDice.RollFourDice();
        CheckForMultiples();
    }

    void CheckForMultiples()
    {
        // check for binary/multiple stars in the system
        switch (RollTheDice.RollFourDice())
        {
            case -4:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case -3:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case -2:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case -1:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case 0:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case 1:
                CreateASingleSystem();
                StarCoordinates = Grid;
                break;
            case 2:
                CreateABinarySystem();
                StarCoordinates = Grid;
                break;
            case 3:
                CreateABinarySystem();
                StarCoordinates = Grid;
                break;
            case 4:
                CreateAMultipleSystem();
                StarCoordinates = Grid;
                break;
            default:
                break;
        }
    }

    void CreateASingleSystem()
    {
        // create a system of interest
        StarCount++;
        GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
        SystemOfInterest.name = "Single ";
        
        StarArray.Add(SystemOfInterest);
        StartConfigureSystem();
    }
    
    void CreateABinarySystem()
    {
        for (int i = 1; i <= 2; i++)
        {
            // randomly generate a distance offset for the companion star
            StarCoordinates.x = StarCoordinates.x - (RollTheDice.RollFourDice() * 0.2f);
            StarCoordinates.y = StarCoordinates.y - (RollTheDice.RollFourDice() * 0.2f);
            StarCoordinates.z = StarCoordinates.z - (RollTheDice.RollFourDice() * 0.2f);
            StarCount++;
            GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
            SystemOfInterest.name = "Binary ";

            StarArray.Add(SystemOfInterest);
            StartConfigureSystem();
        }
    }

    void CreateAMultipleSystem()
    {
        // Determine how many stars in the system
        int rand = Random.Range(3, 5);
        for (int i = 1; i <= rand; i++)
        {
            // randomly generate a distance offset for the companion star
            StarCoordinates.x = StarCoordinates.x - (RollTheDice.RollFourDice() * 0.3f);
            StarCoordinates.y = StarCoordinates.y - (RollTheDice.RollFourDice() * 0.3f);
            StarCoordinates.z = StarCoordinates.z - (RollTheDice.RollFourDice() * 0.3f);
            StarCount++;
            GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
            SystemOfInterest.name = "Multiple ";

            StarArray.Add(SystemOfInterest);
            StartConfigureSystem();
        }
    }

    void CreateAnHIICluster()
    {
        // Determine how many stars in the system
        int rand = Random.Range(3, 10);
        for (int i = 1; i <= rand; i++)
        {
            CalculateScriptAdded = false;
            HIIBaseX = StarCoordinates.x;
            HIIBaseY = StarCoordinates.y;
            HIIBaseZ = StarCoordinates.z;

            // randomly generate a distance offset for the companion star
            StarCoordinates.x = StarCoordinates.x - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCoordinates.y = StarCoordinates.y - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCoordinates.z = StarCoordinates.z - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCount++;
            GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
            SystemOfInterest.name = "Multiple ";
            
            StarArray.Add(SystemOfInterest);

            StarCoordinates.x = HIIBaseX;
            StarCoordinates.y = HIIBaseY;
            StarCoordinates.z = HIIBaseZ;
            
            SpectralClassDetermined = true;
            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Main Sequence Star " + StarCount;
            GameObject StarToType = StarArray [StarCount - 1];
            
            StarToType.gameObject.AddComponent<MainSequenceStar>();

            int randX = Random.Range(1, 3);
            if (randX == 1)
            {
                // Type O
                StarArray [StarCount - 1].name = "Class " + SpectralClasses [0] + " " + StarArray [StarCount - 1].name;
                GameObject StarToColor = StarArray [StarCount - 1];
                
                Text TextToChange;
                TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                TextToChange.text = StarArray [StarCount - 1].name;
                
                StarToColor.gameObject.AddComponent<ClassO>();
            }
            
            if (randX == 2)
            {
                // Type B
                StarArray [StarCount - 1].name = "Class " + SpectralClasses [1] + " " + StarArray [StarCount - 1].name;
                GameObject StarToColor = StarArray [StarCount - 1];
                
                Text TextToChange;
                TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                TextToChange.text = StarArray [StarCount - 1].name;
                
                StarToColor.gameObject.AddComponent<ClassB>();
            }
            Calculate();
            CalculateScriptAdded = true;
        }
    }

    void CreateAMolecularCloudCluster()
    {
        // Determine how many stars in the system
        int rand = Random.Range(3, 10);
        for (int i = 1; i <= rand; i++)
        {
            CalculateScriptAdded = false;
            MolecularCloudBaseX = StarCoordinates.x;
            MolecularCloudBaseY = StarCoordinates.y;
            MolecularCloudBaseZ = StarCoordinates.z;
            
            // randomly generate a distance offset for the companion star
            StarCoordinates.x = StarCoordinates.x - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCoordinates.y = StarCoordinates.y - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCoordinates.z = StarCoordinates.z - (RollTheDice.RollFourDice() * Random.Range(0.1f, 1f));
            StarCount++;
            GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
            SystemOfInterest.name = "Multiple ";
            
            StarArray.Add(SystemOfInterest);

            StarCoordinates.x = MolecularCloudBaseX;
            StarCoordinates.y = MolecularCloudBaseY;
            StarCoordinates.z = MolecularCloudBaseZ;
            
            SpectralClassDetermined = true;

            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Protostar " + StarCount;
            GameObject StarToType = StarArray [StarCount - 1];
            StarToType.gameObject.AddComponent<Protostar>();
            Calculate();
            CalculateScriptAdded = true;
        }
    }

    void CreateAWhiteDwarfCompanion()
    {
        StarCoordinates.x = StarCoordinates.x - (RollTheDice.RollFourDice() * 0.2f);
        StarCoordinates.y = StarCoordinates.y - (RollTheDice.RollFourDice() * 0.2f);
        StarCoordinates.z = StarCoordinates.z - (RollTheDice.RollFourDice() * 0.2f);
        // create a system of interest
        StarCount++;
        GameObject SystemOfInterest = Instantiate(Target, new Vector3(StarCoordinates.x, StarCoordinates.y, StarCoordinates.z), Quaternion.identity) as GameObject;
        SystemOfInterest.name = "Companion ";
        
        StarArray.Add(SystemOfInterest);
        SpectralClassDetermined = true;
        //"White Dwarf"
        StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "White Dwarf " + StarCount;
        GameObject StarToType = StarArray [StarCount - 1];
        
        StarToType.gameObject.AddComponent<WhiteDwarf>();
        Calculate();
        CalculateScriptAdded = true;
    }

    void StartConfigureSystem()
    {
        CalculateScriptAdded = false;
        StellarBodyType();
        StellarBodyDetermination();

        if (SpectralClassDetermined == false)
        {
            SpectralClassification();
        }
        if (CalculateScriptAdded == false)
        {
            Calculate();
            CalculateScriptAdded = true;
        }
    }

    void StellarBodyType()
    {
        switch (RollTheDice.RollFourDice())
        {
            case -4:
                PreStellarObject = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite01;
                break;
            case -3:
                PreStellarObject = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite01;
                break;
            case -2:
                Star = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite02;
                break;
            case -1:
                Star = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite02;
                break;
            case 0:
                Star = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite02;
                break;
            case 1:
                Star = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite02;
                break;
            case 2:
                Star = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite02;
                break;
            case 3:
                PostStellarObject = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite03;
                break;
            case 4:
                ExoticStellarObject = true;
                StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite04;
                break;
            default:
                break;
        }
    }
    
    void StellarBodyDetermination()
    {
        SpectralClassDetermined = false;
        switch (RollTheDice.RollFourDice())
        {
            case -4:
                if (PreStellarObject)
                {
                    // "Interstellar Cloud"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Interstellar Cloud " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<InterstellarCloud>();
                    SpectralClassDetermined = true;
                }
                if (Star)
                {
                    // "Hot Subdwarf"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Hot Subdwarf " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<HotSubdwarf>();
                    int randX = Random.Range(1, 3);
                    if (randX == 1)
                    {
                        // Type O
                        StarArray [StarCount - 1].name = "Class " + SpectralClasses [0] + " " + StarArray [StarCount - 1].name;
                        GameObject StarToColor = StarArray [StarCount - 1];
                        
                        Text TextToChange;
                        TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                        TextToChange.text = StarArray [StarCount - 1].name;
                        
                        StarToColor.gameObject.AddComponent<ClassO>();
                    }
                    
                    if (randX == 2)
                    {
                        // Type B
                        StarArray [StarCount - 1].name = "Class " + SpectralClasses [1] + " " + StarArray [StarCount - 1].name;
                        GameObject StarToColor = StarArray [StarCount - 1];
                        
                        Text TextToChange;
                        TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                        TextToChange.text = StarArray [StarCount - 1].name;
                        
                        StarToColor.gameObject.AddComponent<ClassB>();
                    }
                    Calculate();
                    CalculateScriptAdded = true;
                    SpectralClassDetermined = true;
                    RollTheDice.RollOneDie();
                    if (RollTheDice.RollOneDie() == 1)
                    {
                        CreateAWhiteDwarfCompanion();
                    }
                }
                if (PostStellarObject)
                {
                    // "Stellar Core"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Stellar Core " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<StellarCore>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    // "Dark Matter Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Dark Matter Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<DarkMatterStar>();

                    SpectralClassDetermined = true;
                }
                break;
            case -3:
                if (PreStellarObject)
                {
                    // "H II Region"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "H II Region " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<HIIRegion>();
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite05;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.5f;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 10;

                    HIIBaseX = StarCoordinates.x;
                    HIIBaseY = StarCoordinates.y;
                    HIIBaseZ = StarCoordinates.z;
                    Calculate();
                    CalculateScriptAdded = true;
                    CreateAnHIICluster();
                }
                if (Star)
                {
                    // "Pre-Main Sequence"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Pre-Main Sequence " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PreMainSequence>();
                }
                if (PostStellarObject)
                {
                    // "Collapsing Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Collapsing Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<CollapsingStar>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    // "Asymptotic Giant"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Asymptotic Giant " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<AsymptoticGiant>();
                    Text TextToChange;
                    int rand = Random.Range(1, 3);
                    switch (rand)
                    {
                        case 1:
                            StarToType.gameObject.AddComponent<ClassS>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [7] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 2:
                            StarToType.gameObject.AddComponent<ClassC>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [8] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        default:
                            break;
                    }
                    SpectralClassDetermined = true;
                }
                break;
            case -2:
                if (PreStellarObject)
                {
                    // "Molecular Cloud"
                    GameObject StarToType = StarArray [StarCount - 1];

                    StarToType.gameObject.AddComponent<MolecularCloud>();
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite06;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.5f;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 10;

                    RollTheDice.RollOneDie();
                    Text TextToChange;
                    switch (RollTheDice.RollOneDie())
                    {
                        case -1:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Stellar Nursery " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [0];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [0];
                            break;
                        case 0:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Bok Globule " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [1];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [1];
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.3f;
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 1;
                            break;
                        case 1:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Giant Molecular Cloud " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [2];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [0];
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 30;
                            break;
                        default:
                            break;
                    }

                    MolecularCloudBaseX = StarCoordinates.x;
                    MolecularCloudBaseY = StarCoordinates.y;
                    MolecularCloudBaseX = StarCoordinates.z;
                    Calculate();
                    CalculateScriptAdded = true;
                    CreateAMolecularCloudCluster();
                            
                    SpectralClassDetermined = true;
                }
                if (Star)
                {
                    // "Cool Subdwarf"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Cool Subdwarf " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<CoolSubdwarf>();
                    Text TextToChange;
                    int rand = Random.Range(1, 4);
                    switch (rand)
                    {
                        case 1:
                            StarToType.gameObject.AddComponent<ClassG>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [4] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 2:
                            StarToType.gameObject.AddComponent<ClassK>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [5] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 3:
                            StarToType.gameObject.AddComponent<ClassM>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [6] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        default:
                            break;
                    }
                    SpectralClassDetermined = true;
                }
                if (PostStellarObject)
                {
                    // "Planetary Nebula"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Planetary Nebula " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PlanetaryNebula>();
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite05;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.5f;

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    // "Asymptotic Giant" 
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Asymptotic Giant " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<AsymptoticGiant>();
                    Text TextToChange;
                    int rand = Random.Range(1, 3);
                    switch (rand)
                    {
                        case 1:
                            StarToType.gameObject.AddComponent<ClassS>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [7] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 2:
                            StarToType.gameObject.AddComponent<ClassC>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [8] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        default:
                            break;
                    }
                    SpectralClassDetermined = true;
                }
                break;
            case -1:
                if (PreStellarObject)
                {
                    // "Molecular Cloud"
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<MolecularCloud>();
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite06;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.5f;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 10;
                    
                    RollTheDice.RollOneDie();
                    Text TextToChange;
                    switch (RollTheDice.RollOneDie())
                    {
                        case -1:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Stellar Nursery " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [0];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [0];
                            break;
                        case 0:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Bok Globule " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [1];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [1];
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.2f;
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 1;
                            break;
                        case 1:
                            StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Giant Molecular Cloud " + StarCount;
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitle = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypes [2];
                            StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudSubtitleDescription = StarToType.gameObject.GetComponent<MolecularCloud>().MolecularCloudTypeDescriptions [0];
                            StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Radius = 30;
                            break;
                        default:
                            break;
                    }
                    Calculate();
                    CalculateScriptAdded = true;
                    CreateAMolecularCloudCluster();
                    
                    SpectralClassDetermined = true;
                }
                if (Star)
                {
                    //"Substellar Object"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Substellar Object " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<SubstellarObject>();
                    Text TextToChange;
                    RollTheDice.RollOneDie();
                    switch (RollTheDice.RollOneDie())
                    {
                        case -1:
                            StarToType.gameObject.AddComponent<ClassL>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [9] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 0:
                            StarToType.gameObject.AddComponent<ClassT>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [10] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        case 1:
                            StarToType.gameObject.AddComponent<ClassY>();
                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [11] + " " + StarArray [StarCount - 1].name;
                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                            TextToChange.text = StarArray [StarCount - 1].name;
                            break;
                        default:
                            break;
                    }
                    SpectralClassDetermined = true;
                }
                if (PostStellarObject)
                {
                    // "Planetary Nebula"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Planetary Nebula " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PlanetaryNebula>();
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Stars [0].Sprite = StarSprite05;
                    StarArray [StarCount - 1].gameObject.GetComponent<SgtCustomStarfield>().Brightness = 0.5f;

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    // "Eruptive Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Eruptive Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<EruptiveVariable>();
                }
                break;
            case 0:
                if (PreStellarObject)
                {
                    //"Protostar"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Protostar " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    StarToType.gameObject.AddComponent<Protostar>();

                    SpectralClassDetermined = true;
                }
                if (Star)
                {
                    // "Main Sequence Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Main Sequence Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<MainSequenceStar>();
                }
                if (PostStellarObject)
                {
                    //"White Dwarf"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "White Dwarf " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<WhiteDwarf>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    //"Pulsating Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Pulsating Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PulsatingVariable>();
                }
                break;
            case 1:
                if (PreStellarObject)
                {
                    //"Protostar"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Protostar " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    StarToType.gameObject.AddComponent<Protostar>();

                    SpectralClassDetermined = true;
                }
                if (Star)
                {
                    // "Main Sequence Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Main Sequence Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<MainSequenceStar>();
                }
                if (PostStellarObject)
                {
                    //"White Dwarf"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "White Dwarf " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<WhiteDwarf>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    //"Pulsating Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Pulsating Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PulsatingVariable>();
                }
                break;
            case 2:
                if (PreStellarObject)
                {
                    // "Eruptive Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Eruptive Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<EruptiveVariable>();
                }
                if (Star)
                {
                    // "Subgiant"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Subgiant " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<Subgiant>();
                }
                if (PostStellarObject)
                {
                    //"Neutron Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Neutron Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<NeutronStar>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    //"Pulsating Variable"   
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Pulsating Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<PulsatingVariable>();
                }
                break;
            case 3:
                if (PreStellarObject)
                {
                    // "Eruptive Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Eruptive Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<EruptiveVariable>();
                }
                if (Star)
                {
                    // "Giant"
                    GameObject StarToType = StarArray [StarCount - 1];
                    Text TextToChange;
                    int rand;
                    switch (RollTheDice.RollOneDie())
                    {
                        case -1:
                            rand = Random.Range(1, 5);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassK>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [5] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Red";

                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassM>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [6] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Red";
                                    break;
                                case 3:
                                    StarToType.gameObject.AddComponent<ClassS>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [7] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Red";
                                    break;
                                case 4:
                                    StarToType.gameObject.AddComponent<ClassC>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [8] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Red";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 0:
                            rand = Random.Range(1, 4);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassG>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [4] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Yellow";
                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassF>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [3] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Yellow";
                                    break;
                                case 3:
                                    int randA = Random.Range(1, 3);
                                    switch (randA)
                                    {
                                        case 1:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Giant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Yellow";
                                            break;
                                        case 2:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Giant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Blue";
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 1:
                            rand = Random.Range(1, 4);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassO>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [0] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Blue";
                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassB>();
                                    StarToType.gameObject.AddComponent<Giant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [1] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Blue";
                                    break;
                                case 3:
                                    int randA = Random.Range(1, 3);
                                    switch (randA)
                                    {
                                        case 1:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Giant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Yellow";
                                            break;
                                        case 2:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Giant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Giant>().GiantSubtitle = "Blue";
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + StarToType.gameObject.GetComponent<Giant>().GiantSubtitle + " Giant " + StarCount;
                    SpectralClassDetermined = true;
                }
                if (PostStellarObject)
                {
                    //"Electroweak Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Electroweak Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<ElectroweakStar>();

                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    // "Eruptive Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Eruptive Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<EruptiveVariable>();
                }
                break;
            case 4:
                if (PreStellarObject)
                {
                    // "Eruptive Variable"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Eruptive Variable " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<EruptiveVariable>();
                }
                if (Star)
                {
                    // "Supergiant"
                    GameObject StarToType = StarArray [StarCount - 1];

                    Text TextToChange;
                    int rand;
                    switch (RollTheDice.RollOneDie())
                    {
                        case -1:
                            rand = Random.Range(1, 5);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassK>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [5] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Red";
                                    
                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassM>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [6] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Red";
                                    break;
                                case 3:
                                    StarToType.gameObject.AddComponent<ClassS>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [7] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Red";
                                    break;
                                case 4:
                                    StarToType.gameObject.AddComponent<ClassC>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [8] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Red";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 0:
                            rand = Random.Range(1, 4);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassG>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [4] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Yellow";
                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassF>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [3] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Yellow";
                                    break;
                                case 3:
                                    int randA = Random.Range(1, 3);
                                    switch (randA)
                                    {
                                        case 1:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Supergiant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Yellow";
                                            break;
                                        case 2:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Supergiant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Blue";
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 1:
                            rand = Random.Range(1, 4);
                            switch (rand)
                            {
                                case 1:
                                    StarToType.gameObject.AddComponent<ClassO>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [0] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Blue";
                                    break;
                                case 2:
                                    StarToType.gameObject.AddComponent<ClassB>();
                                    StarToType.gameObject.AddComponent<Supergiant>();
                                    StarArray [StarCount - 1].name = "Class " + SpectralClasses [1] + " " + StarArray [StarCount - 1].name;
                                    TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                    TextToChange.text = StarArray [StarCount - 1].name;
                                    StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Blue";
                                    break;
                                case 3:
                                    int randA = Random.Range(1, 3);
                                    switch (randA)
                                    {
                                        case 1:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Supergiant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Yellow";
                                            break;
                                        case 2:
                                            StarToType.gameObject.AddComponent<ClassA>();
                                            StarToType.gameObject.AddComponent<Supergiant>();
                                            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
                                            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
                                            TextToChange.text = StarArray [StarCount - 1].name;
                                            StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle = "Blue";
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + StarToType.gameObject.GetComponent<Supergiant>().GiantSubtitle + " Supergiant " + StarCount;
                    SpectralClassDetermined = true;
                }
                if (PostStellarObject)
                {
                    //"Stellar Black Hole"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Stellar Black Hole " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<StellarBlackHole>();
                    
                    SpectralClassDetermined = true;
                }
                if (ExoticStellarObject)
                {
                    //"Black Star"
                    StarArray [StarCount - 1].name = StarArray [StarCount - 1].name + "Black Star " + StarCount;
                    GameObject StarToType = StarArray [StarCount - 1];
                    
                    StarToType.gameObject.AddComponent<BlackStar>();
                    
                    SpectralClassDetermined = true;
                }
                break;
            default:
                break;
        }
        // reset important variables
        PreStellarObject = false;
        Star = false;
        PostStellarObject = false;
        ExoticStellarObject = false;
    }
    
    void SpectralClassification()
    {
        int ValX = RollTheDice.RollFourDice();
        int ValY = RollTheDice.RollFourDice();
        
        if (ValX == -4 && ValY == -4)
        {
            // Type O
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [0] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassO>();
        }

        if (ValX == -3 && ValY == -4)
        {
            // Type B
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [1] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassB>();
        }

        if (ValX == -2 && ValY == -4 || 
            ValX == -3 && ValY == -3 ||
            ValX == -4 && ValY == -2)
        {
            // Type F
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [3] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassF>();
        }

        if (ValX == -1 && ValY == -4 ||
            ValX == 0 && ValY == -4 ||
            ValX == -1 && ValY == -3 ||
            ValX == -1 && ValY == -2 ||
            ValX == -1 && ValY == -1 ||
            ValX == -1 && ValY == 0 ||
            ValX == -2 && ValY == 0 ||
            ValX == -3 && ValY == 0 ||
            ValX == -4 && ValY == 0 ||
            ValX == -4 && ValY == 1)
        {
            // Type K
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [5] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassK>();
        }

        if (ValX == -4 && ValY == 2 ||
            ValX == -4 && ValY == 3 ||
            ValX == -4 && ValY == 4 ||
            ValX == -3 && ValY == 1 ||
            ValX == -3 && ValY == 2 ||
            ValX == -3 && ValY == 3 ||
            ValX == -3 && ValY == 4 ||
            ValX == -2 && ValY == 1 ||
            ValX == -2 && ValY == 2 ||
            ValX == -2 && ValY == 3 ||
            ValX == -2 && ValY == 4 ||
            ValX == -1 && ValY == 1 ||
            ValX == -1 && ValY == 2 ||
            ValX == -1 && ValY == 3 ||
            ValX == -1 && ValY == 4 ||
            ValX == 0 && ValY == -3 ||
            ValX == 0 && ValY == -2 ||
            ValX == 0 && ValY == -1 ||
            ValX == 0 && ValY == 0 ||
            ValX == 0 && ValY == 1 ||
            ValX == 0 && ValY == 2 ||
            ValX == 0 && ValY == 3 ||
            ValX == 0 && ValY == 4 ||
            ValX == 1 && ValY == -4 ||
            ValX == 1 && ValY == -3 ||
            ValX == 1 && ValY == -2 ||
            ValX == 1 && ValY == -1 ||
            ValX == 1 && ValY == 0 ||
            ValX == 1 && ValY == 1 ||
            ValX == 1 && ValY == 2 ||
            ValX == 1 && ValY == 3 ||
            ValX == 1 && ValY == 4 ||
            ValX == 2 && ValY == -4 ||
            ValX == 2 && ValY == -3 ||
            ValX == 2 && ValY == -2 ||
            ValX == 2 && ValY == -1 ||
            ValX == 2 && ValY == 0 ||
            ValX == 2 && ValY == 1 ||
            ValX == 2 && ValY == 2 ||
            ValX == 2 && ValY == 3 ||
            ValX == 3 && ValY == -4 ||
            ValX == 3 && ValY == -3 ||
            ValX == 3 && ValY == -2 ||
            ValX == 3 && ValY == -1 ||
            ValX == 3 && ValY == 0 ||
            ValX == 3 && ValY == 1 ||
            ValX == 3 && ValY == 2 ||
            ValX == 4 && ValY == -4 ||
            ValX == 4 && ValY == -3 ||
            ValX == 4 && ValY == -2 ||
            ValX == 4 && ValY == -1 ||
            ValX == 4 && ValY == 0 ||
            ValX == 4 && ValY == 1)
        {
            // Type M
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [6] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;

            StarToColor.gameObject.AddComponent<ClassM>();
        }

        if (ValX == -4 && ValY == -3)
        {
            // Type A
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [2] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassA>();
        }

        if (ValX == -4 && ValY == -1 ||
            ValX == -3 && ValY == -2 ||
            ValX == -3 && ValY == -1 ||
            ValX == -2 && ValY == -3 ||
            ValX == -2 && ValY == -2 ||
            ValX == -2 && ValY == -1)
        {
            // Type G
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [4] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassG>();
        }

        if (ValX == 3 && ValY == 3)
        {
            // Type S
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [7] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassS>();
        }

        if (ValX == 2 && ValY == 4 ||
            ValX == 4 && ValY == 2)
        {
            // Type C
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [8] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassC>();
        }

        if (ValX == 4 && ValY == 3)
        {
            // Type T
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [10] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassT>();
        }

        if (ValX == 3 && ValY == 4)
        {
            // Type L
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [9] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassL>();
        }

        if (ValX == 4 && ValY == 4)
        {
            // Type Y
            StarArray [StarCount - 1].name = "Class " + SpectralClasses [11] + " " + StarArray [StarCount - 1].name;
            GameObject StarToColor = StarArray [StarCount - 1];

            Text TextToChange;
            TextToChange = StarArray [StarCount - 1].GetComponentInChildren<Text>();
            TextToChange.text = StarArray [StarCount - 1].name;
            
            StarToColor.gameObject.AddComponent<ClassY>();
        }
        SpectralClassDetermined = true;
    }

    void Calculate()
    {
        GameObject StarToCalculate = StarArray [StarCount - 1];
        StarToCalculate.gameObject.AddComponent<Calculator>();
    }
}
