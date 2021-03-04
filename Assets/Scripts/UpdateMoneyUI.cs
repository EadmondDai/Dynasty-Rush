using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMoneyUI : MonoBehaviour
{
    private const string goldString = "Gold:";

    [SerializeField] TextMeshProUGUI tmpDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Bank.moneyChangeDelegate += OnBankMoneyChanges;
        OnBankMoneyChanges(FindObjectOfType<Bank>().CurrentFunds);
    }

    void OnBankMoneyChanges(int funds)
    {
        tmpDisplay.text = goldString + funds.ToString();
    }
}
