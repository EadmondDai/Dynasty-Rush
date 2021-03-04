using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    
    private Bank playerBank;

    // Start is called before the first frame update
    void Start()
    {
        playerBank = GameObject.FindObjectOfType<Bank>();    
    }

    public void onDied()
    {
        rewardGold();
    }

    public void onEscaped()
    {
        stealGold();
    }

    private int rewardGold()
    {
        if (!playerBank) return -1;
        playerBank.Deposit(goldReward);
        return goldReward;
    }

    private int stealGold()
    {
        if (!playerBank) return -1;
        playerBank.Withdraw(goldPenalty);
        return goldPenalty;
    }
}
