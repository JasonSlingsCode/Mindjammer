using UnityEngine;
using System.Collections;

public class Calculator : MonoBehaviour
{
    private BaseStar TheBaseStar;


    void Awake()
    {
        TheBaseStar = this.gameObject.GetComponent<BaseStar>();
    }

    // Use this for initialization
    void Start()
    {
        TheBaseStar.FindAge();                      // Step 1
        TheBaseStar.FindHabitableZoneDistance();    // Step 2
        TheBaseStar.FindHabitableZonePeriod();      // Step 3
        TheBaseStar.FindPlanetarySystemType();      // Step 4
        TheBaseStar.FindBiosphereModifier();        // Step 5
        TheBaseStar.FindHabitabilityModifier();     // Step 6
        TheBaseStar.AddAspects();                   // Step 7
        TheBaseStar.AddPlentifulResources();        // Step 8
        TheBaseStar.AddScarceResources();
        TheBaseStar.AddPlanetarySystems();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
