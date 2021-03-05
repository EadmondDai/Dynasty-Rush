using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Bank : MonoBehaviour
{
    [SerializeField] int goldNeededToWin = 500;
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

        if(currentFunds >= goldNeededToWin)
        {
            //TODO win, and proceed to next level;
        }

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
