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
    }

    public void OnTryAgain()
    {
        SceneManager.LoadScene("Gameplay Scene");
    }
}
