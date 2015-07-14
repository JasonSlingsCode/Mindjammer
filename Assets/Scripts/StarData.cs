// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu(SgtHelper.ComponentMenuPrefix + "Custom Starfield")]
public class StarData : SgtStarfield
{
    public List<SgtStarfieldStar> Stars = new List<SgtStarfieldStar>();
    
    public static StarData CreateCustomStarfield(Transform parent = null)
    {
        return CreateCustomStarfield(parent, Vector3.zero, Quaternion.identity, Vector3.one);
    }
    
    public static StarData CreateCustomStarfield(Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
    {
        var gameObject = SgtHelper.CreateGameObject("Custom Starfield", parent, localPosition, localRotation, localScale);
        var starfield  = gameObject.AddComponent<StarData>();
        
        return starfield;
    }
    
    protected override void CalculateStars(out List<SgtStarfieldStar> stars, out bool pool)
    {
        stars = Stars;
        pool  = false;
    }
    
    #if UNITY_EDITOR
    [UnityEditor.MenuItem(SgtHelper.GameObjectMenuPrefix + "Custom Starfield", false, 10)]
    private static void CreateCustomStarfieldMenuItem()
    {
        var starfield = CreateCustomStarfield(null);
        
        SgtHelper.SelectAndPing(starfield);
    }
    #endif
}