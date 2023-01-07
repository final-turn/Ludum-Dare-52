using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
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

    void Start()
    {
        backgroundImg = GetComponent<Image>();
    }

    public void OnDayEnd()
    {

    }

    public void ComputeSusceptibility()
    {

    }
}
