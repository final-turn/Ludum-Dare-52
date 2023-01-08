using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public AlienStats myStats;
    public PlanetTraits startingTraits;

    [HideInInspector] public float susceptibility; // Main one, used to gauge harvestability
    [HideInInspector] public float politicalDichotomy;
    [HideInInspector] public float hostility;
    [HideInInspector] public float health;
    [HideInInspector] public float population;
    [HideInInspector] public float production;

    [HideInInspector] public float relationship;
    [HideInInspector] public bool aware;

    private Image backgroundImg;

    [HideInInspector] public List<int> dayOptions;

    public void OnGameStart()
    {
        politicalDichotomy = startingTraits.politicalDichotomy;
        hostility = startingTraits.hostility;
        health = startingTraits.health;
        population = startingTraits.population;
        production = startingTraits.production;

        dayOptions = new List<int>();
        dayOptions.Add(UnityEngine.Random.Range(0, 5));
        dayOptions.Add(UnityEngine.Random.Range(0, 5));
        dayOptions.Add(UnityEngine.Random.Range(0, 5));

        backgroundImg = GetComponent<Image>();
        ComputeSusceptibility();
    }

    public void OnDayEnd()
    {
        dayOptions.Clear();
        dayOptions.Add(UnityEngine.Random.Range(0, 5));
        dayOptions.Add(UnityEngine.Random.Range(0, 5));
        dayOptions.Add(UnityEngine.Random.Range(0, 5));
    }

    public void OnOptionSelected(int index)
    {
        dayOptions.RemoveAt(index);
        ComputeSusceptibility();
    }

    public void ComputeSusceptibility()
    {
        float relationshipFactor = 0;
        if (aware)
        {
            relationshipFactor = relationship / 10;
        }

        float politicalFactor = politicalDichotomy / 10;
        politicalFactor = politicalFactor * politicalFactor;

        float aggrFactor = 1 - startingTraits.aggression;
        float hostileFactor = 1 - hostility;

        susceptibility = aggrFactor + hostileFactor + relationshipFactor - politicalFactor;

        // Debug.Log($"a{aggrFactor} * h{hostileFactor} + r{relationshipFactor} - p{politicalFactor}");

        susceptibility = Mathf.Clamp01(susceptibility);

        if (susceptibility > 0.8f)
            backgroundImg.color = Color.green;
        else if (susceptibility > 0.4f)
            backgroundImg.color = Color.yellow;
        else
            backgroundImg.color = Color.red;
    }

    public bool Harvest()
    {
        float success = Random.Range(0f, 1f);

        Debug.Log(success);

        if (success < (1 - susceptibility))
            return false;

        myStats.energyCount += Mathf.FloorToInt(production);
        myStats.foodCount += Mathf.FloorToInt(population);
        myStats.metalCount += Mathf.FloorToInt(health);

        return true;
    }
}
