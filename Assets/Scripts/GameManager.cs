using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Screen")]
    public GameObject startScreen;
    public GameObject gameOverScreen;

    [Header("My Stats")]
    public int population;
    public int satisfaction;

    [Header("Resource")]
    public int metalCount;
    public int foodCount;
    public int energyCount;

    [Header("UI")]
    public TMP_Text populationUI;
    public TMP_Text satisfactionUI;
    public TMP_Text metalCountUI;
    public TMP_Text foodCountUI;
    public TMP_Text energyCountUI;

    [Header("Planets")]
    public Image universe;
    public List<Planet> planets;


    // Start is called before the first frame update
    void Start()
    {
        RenderValues();
    }

    public void GoToNextDay()
    {
        foreach (Planet planet in planets)
        {
            planet.OnDayEnd();
        }

        foodCount += -population;

        RenderValues();

        if (foodCount <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void SelectPlanet(int index)
    {
        universe.GetComponent<RectTransform>().anchoredPosition = -1 * planets[index].GetComponent<RectTransform>().anchoredPosition;
    }

    public void RenderValues()
    {
        populationUI.text = "" + population + "k";
        satisfactionUI.text = "" + satisfaction + "%";
        metalCountUI.text = "" + metalCount;
        foodCountUI.text = "" + foodCount;
        energyCountUI.text = "" + energyCount;
    }
}
