using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/AlienStats")]
public class AlienStats : ScriptableObject
{
    public enum EndCondition { NoSatisfaction, FailedHarvest, HarvestComplete}

    public int metalCount;
    public int energyCount;
    public int foodCount;

    public float population;
    public float satisfaction;

    public EndCondition gameEndCondition;

    public void OnGameStart()
    {
        metalCount = 5;
        energyCount = 5;
        foodCount = 5;
        population = 1;
        satisfaction = 0.5f;
    }

    public void OnDayEnd()
    {
        if (foodCount >= Mathf.FloorToInt(population))
        {
            foodCount -= Mathf.FloorToInt(population);
            population += 0.4f;
            satisfaction += 0.05f;
        }
        else
        {
            population -= 0.5f;
            satisfaction -= 0.2f;
        }

        metalCount += Mathf.FloorToInt(population);
        energyCount += Mathf.FloorToInt(population);
    }
}
