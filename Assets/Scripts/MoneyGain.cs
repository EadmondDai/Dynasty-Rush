using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyGain : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyUI;

    private int gold;
    private const string plusString = "+";

    public void ShowMoneyGain(int fund)
    {
        gold = fund;
        moneyUI.text = plusString + gold.ToString();
    }
}
