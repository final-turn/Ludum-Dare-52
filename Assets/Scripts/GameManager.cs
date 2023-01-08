using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("State")]
    public AlienStats myStats;

    [Header("Screen")]
    public GameObject startScreen;
    public GameObject gameOverScreen;

    [Header("UI")]
    public TMP_Text populationUI;
    public TMP_Text satisfactionUI;
    public TMP_Text metalCountUI;
    public TMP_Text foodCountUI;
    public TMP_Text energyCountUI;

    [Header("Planets")]
    public Image universe;
    public List<Planet> planets;
    public List<OptionUI> optionUIs;
    public List<PlanetOptions> options;

    // Start is called before the first frame update
    void Start()
    {
        myStats.OnGameStart();
        RenderValues();
    }

    public void GoToNextDay()
    {
        foreach (Planet planet in planets)
        {
            planet.OnDayEnd();
        }

        myStats.OnDayEnd();

        if (myStats.foodCount <= 0)
        {
            gameOverScreen.SetActive(true);
        }

        RenderValues();

    }

    public void SelectPlanet(int index)
    {
        universe.GetComponent<RectTransform>().anchoredPosition = -1 * planets[index].GetComponent<RectTransform>().anchoredPosition;

        List<int> opIndices = planets[index].dayOptions;
        for (int i = 0; i < opIndices.Count; i++) {
            optionUIs[i].SetUI(options[opIndices[i]]);
        }
    }

    public void SelectOption(int index)
    {

    }

    public void RenderValues()
    {
        populationUI.text = "" + myStats.population + "k";
        satisfactionUI.text = "" + (myStats.satisfaction * 100f) + "%";
        metalCountUI.text = "" + myStats.metalCount;
        foodCountUI.text = "" + myStats.foodCount;
        energyCountUI.text = "" + myStats.energyCount;
    }
}
