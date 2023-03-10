using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Planet")]
public class PlanetTraits : ScriptableObject
{
    public string leftPolitics;
    public string rightPolitics;

    [Header("Static Properties")]
    public float aggression;
    public float selflessness;
    public float agreeableness;

    [Header("Dynamic Properties")]
    public float politicalDichotomy;
    public float hostility;
    public float health;
    public float population;
    public float production;

    public float relationship;
    public bool aware;
}
