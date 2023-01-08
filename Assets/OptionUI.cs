using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionUI : MonoBehaviour
{
    public TMP_Text costText;
    public TMP_Text descriptionText;

    public int optionIndex;

    public void SetUI(int index, PlanetOption option)
    {
        optionIndex = index;
        costText.text = $"Cost: {option.metalCost} Metal {option.energyCost} Energy";
        descriptionText.text = option.description;
    }
}
