using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AlienStats myStats;

    [Header("Screen")]
    public TMP_Text header;
    public TMP_Text reason;
    public TMP_Text score;

    void Start()
    {
        if (myStats.gameEndCondition == AlienStats.EndCondition.HarvestComplete)
        {
            header.text = "Congrats!";
            reason.text = "You've successfully harvested all other lifeforms in the universe :)";
        }
        else if (myStats.gameEndCondition == AlienStats.EndCondition.FailedHarvest)
        {
            header.text = "GAME OVER";
            reason.text = "You failed to successfully harvest the planet. They retaliated and defeated you guys :(";
        }
        score.text = "Your final score is: " + ((myStats.metalCount + myStats.foodCount + myStats.energyCount + myStats.population) * myStats.satisfaction);
    }

    public void OnTryAgain()
    {
        SceneManager.LoadScene("Gameplay Scene");
    }
}
