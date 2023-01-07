using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTraits : ScriptableObject
{
    [Header("Properties")]
    public float susceptibility; // Main one, used to gauge harvestability
    public float politicalDichotomy;
    public float hostility;
    public float health;
    public float population;
    public float production;

    public float aggression;
    public float selflessness;
    public float agreeableness;
    public float relationship;
    public bool aware;
}
