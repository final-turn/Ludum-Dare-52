using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
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
    public List<Planet> planets;


    // Start is called before the first frame update
    void Start()
    {
        populationUI.text = "" + population + "k";
        satisfactionUI.text = "" + satisfaction + "%";
        metalCountUI.text = "" + metalCount;
        foodCountUI.text = "" + foodCount;
        energyCountUI.text = "" + energyCount;
    }

    public void GoToNextDay()
    {
        foreach (Planet planet in planets)
        {
            planet.OnDayEnd();
        }

        foodCount += -population;
    }
}
