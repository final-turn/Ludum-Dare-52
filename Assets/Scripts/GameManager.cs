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

    [Header("Options")]
    public TMP_Text optionLabel;
    public Image optionsAvatar;
    public GameObject optionsPanel;
    public TabManager tabs;
    [Header("UI")]
    public TMP_Text message;
    public TMP_Text populationUI;
    public TMP_Text satisfactionUI;
    public TMP_Text metalCountUI;
    public TMP_Text foodCountUI;
    public TMP_Text energyCountUI;

    [Header("Planets")]
    public Image universe;
    public List<Planet> planets;
    public List<OptionUI> optionUIs;
    public List<PlanetOption> options;

    private int activePlanetIndex;
    private List<int> activeOpIndices;

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
        optionsPanel.SetActive(false);
        RenderValues();
    }

    public void SelectPlanet(int index)
    {
        optionLabel.text = planets[index].startingTraits.name;
        optionsAvatar.sprite = planets[index].transform.GetChild(0).GetComponent<Image>().sprite;
        optionsPanel.SetActive(true);

        Vector3 anchoredPosition = planets[index].GetComponent<RectTransform>().anchoredPosition - new Vector2(0f, 83f);
        universe.GetComponent<RectTransform>().anchoredPosition = -1 * anchoredPosition;
        
        activePlanetIndex = index;
        activeOpIndices = planets[index].dayOptions;

        tabs.SetPlanet(planets[index]);

        for (int i = 0; i < 3; i++) {
            if (i < activeOpIndices.Count)
            {
                optionUIs[i].gameObject.SetActive(true);
                optionUIs[i].SetUI(activeOpIndices[i], options[activeOpIndices[i]]);
            }
            else
            {
                optionUIs[i].gameObject.SetActive(false);
            }
        }
    }

    public void SelectOption(int index)
    {
        PlanetOption option = options[activeOpIndices[index]];

        if (option.OnOptionSelect(planets[activePlanetIndex]))
        {
            planets[activePlanetIndex].RemoveOption(index);
            SelectPlanet(activePlanetIndex);

            RenderValues();
        }
        else
        {
            message.text = "Not enough resources to execute that option";
        }
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
