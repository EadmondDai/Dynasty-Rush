using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingFunds = 200;
    [SerializeField] int currentFunds;
    public int CurrentFunds {get { return currentFunds; } }

    public delegate void OnMoneyChangeDelegate(int newFunds);
    public static event OnMoneyChangeDelegate moneyChangeDelegate;

    void Start()
    {
        currentFunds = startingFunds;
    }

    public bool Deposit(int funds)
    {
        if (funds < 0)
        {
            return false;
        }

        currentFunds += funds;

        if (moneyChangeDelegate != null)
            moneyChangeDelegate(currentFunds);

        return true;
    }

    public bool Withdraw(int funds)
    {
        if (funds < 0)
        { 
            return false;
        }

        currentFunds -= funds;

        if(moneyChangeDelegate != null)
            moneyChangeDelegate(currentFunds);

        if (currentFunds < 0)
        {
            ReloadScene();
        }

        return true;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
