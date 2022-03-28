using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureBarHandler : MonoBehaviour
{
    private static Image TreasureBarImage;

    /// Initialize the variable
    private void Start()
    {
        TreasureBarImage = GetComponent<Image>();
    }

    // Sets the treasure bar value
    // 'value' should be between 0 and 1
    public static void SetTreasureBarValue(float value)
    {
        TreasureBarImage.fillAmount = value;
        if (TreasureBarImage.fillAmount < 0.2f)
        {
            SetTreasureBarColor(Color.red);
        }
        else if (TreasureBarImage.fillAmount < 0.4f)
        {
            SetTreasureBarColor(Color.yellow);
        }
        else
        {
            SetTreasureBarColor(Color.green);
        }
    }

    public static float GetTreasureBarValue()
    {
        return TreasureBarImage.fillAmount;
    }

    // Sets the treasure bar color
    public static void SetTreasureBarColor(Color treasureColor)
    {
        TreasureBarImage.color = treasureColor;
    }
}
