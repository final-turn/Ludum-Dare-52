using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabManager : MonoBehaviour
{
    public GameObject optionsTab;
    public GameObject historyTab;

    [Header("UI Properties")]
    public TMP_Text aware;
    public TMP_Text susceptibility;
    public TMP_Text politicalText;
    public TMP_Text hostilityText;
    public TMP_Text healthText;
    public TMP_Text populationText;
    public TMP_Text productionText;

    public void OnOptionSelect()
    {
        optionsTab.SetActive(true);
        historyTab.SetActive(false);
    }

    public void OnHistorySelect()
    {
        optionsTab.SetActive(false);
        historyTab.SetActive(true);
    }

    public void SetPlanet(Planet planet)
    {
        string party = planet.startingTraits.leftPolitics;

        if (Mathf.Abs(planet.politicalDichotomy) < 3)
        {
            party = "50/50";
        }
        else if (planet.politicalDichotomy > 0) {
            party = planet.startingTraits.rightPolitics;
        }

        if (Mathf.Abs(planet.politicalDichotomy) > 8)
        {
            party += "+";
        }

        susceptibility.text = "Susceptibility: " + (planet.susceptibility * 100f) +"%";

        politicalText.text = "Politics: " + party;
        hostilityText.text = "Hostility: " + planet.hostility + "%";
        healthText.text = "Health: " + planet.health;
        populationText.text = "Population: " + planet.population + "m";
        productionText.text = "Production: " + planet.production;
        aware.text = "Sees You: " + (planet.aware ? "Yes" : "No");
    }
}
