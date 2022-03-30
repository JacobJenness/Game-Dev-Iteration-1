using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureBarHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text treasure;
    [SerializeField] private GameObject gameOver;

    private void Start()
    {
        SetTreasureValue(100);
    }

    public void Update()
    {
        SetTreasureValue(GetTreasureValue() - 1);
    }

    // Takes an input as positive or negative and updates the value of treasure
    public void SetTreasureValue(int value)
    {
        int currentValue = GetTreasureValue();
        // Possibly implement sanity checks here
        currentValue += value;

        if (currentValue <= 20)
        {
            SetTreasureColor(Color.red);
        }
        else if (currentValue <= 50)
        {
            SetTreasureColor(Color.yellow);
        }
        else
        {
            SetTreasureColor(Color.green);
        }

        // If health is 0 or less, it's game over
        if (currentValue <= 0)
        {
            gameOver.SetActive(true);
        }
    }

    public int GetTreasureValue()
    {
        string tmp = treasure.GetParsedText();
        try
        {
            int i = int.Parse(tmp);
            return i;
        } catch
        {
            // This probably throws an error but idk
            throw;
        }
    }

    // Sets the treasure color
    public void SetTreasureColor(Color treasureColor)
    {
        treasure.color = treasureColor;
    }
}
