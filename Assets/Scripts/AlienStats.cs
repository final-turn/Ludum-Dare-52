using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/AlienStats")]
public class AlienStats : ScriptableObject
{
    public int metalCount;
    public int energyCount;
    public int foodCount;

    public int population;
    public float satisfaction;

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
        foodCount += -population;
    }
}
