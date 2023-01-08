using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionUI : MonoBehaviour
{
    public TMP_Text costText;
    public TMP_Text descriptionText;

    public void SetUI(PlanetOptions option)
    {
        costText.text = $"Cost: {option.metalCost} Metal {option.energyCost} Energy";
        descriptionText.text = option.description;
    }
}
