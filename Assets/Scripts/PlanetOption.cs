using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Options")]
public class PlanetOption : ScriptableObject
{
    public AlienStats myStats;

    [Header("UI Properties")]
    public int metalCost;
    public int energyCost;
    public string description;

    [Header("Planet Delta")]
    public float politics;
    public float hostility;
    public float health;
    public float population;
    public float production;
    public bool aware;
    public float relationship;

    [Header("My Delta")]
    public int metal;
    public int food;
    public int energy;

    public bool OnOptionSelect(Planet planet)
    {
        if (metalCost > myStats.metalCount || energyCost > myStats.energyCount)
        {
            return false;
        }

        myStats.metalCount -= metalCost;
        myStats.energyCount -= energyCost;

        planet.politicalDichotomy += politics;
        planet.hostility += hostility;
        planet.health += health;
        planet.population += population;
        planet.production += production;
        planet.relationship += relationship;
        planet.aware &= aware;

        myStats.metalCount += metal;
        myStats.foodCount += food;
        myStats.energyCount += energy;

        return true;
    }
}
