using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int goldNeed;

    private Bank playerBank;

    // Start is called before the first frame update
    void Start()
    {
        playerBank = GameObject.FindObjectOfType<Bank>();
    }

    public bool CreateTower(Tower prefab, Vector3 position)
    {
        bool succss = false;
        if(playerBank)
            succss = playerBank.Withdraw(goldNeed);

        if (succss)
        {
            var towObj = Instantiate(prefab, position, Quaternion.identity);
            return true;
        }
        else
        {
            return false;
        }

    }
}
